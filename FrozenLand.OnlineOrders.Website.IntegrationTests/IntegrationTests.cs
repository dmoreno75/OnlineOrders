using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FrozenLand.OnlineOrders.Data;
using FrozenLand.OnlineOrders.Domain;
using FrozenLand.OnlineOrders.Website.Controllers;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NUnit.Framework;

namespace FrozenLand.OnlineOrders.Website.IntegrationTests
{
    public class ControllerIntegrationTests
    {
        private WebApplicationFactory<Startup> _factory;


        [SetUp]
        public void Setup()
        {
            _factory = new WebApplicationFactory<Startup>();
            var projectDir = Directory.GetCurrentDirectory();
            var configPath = Path.Combine(projectDir, "appsettings.json");

            _factory = _factory.WithWebHostBuilder(x =>
            {
                x.ConfigureAppConfiguration((context, config) =>
                {
                    config.AddJsonFile(configPath);
                });

            });

            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("TestDb");

            using var context = new OrdersDbContext(builder.Options);
            context.Database.EnsureDeleted();
        }

        [Test]
        public async Task ValidOrder_ShouldReturnSuccessResponse()
        {

            var client = _factory.CreateClient();

            var content = new StringContent(OrderSamples.FullValidOrder, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/orders/process", content);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var controllerResponse = JsonConvert.DeserializeObject<OrderProcessingResult>(responseString);

            // Assert 
            Assert.IsTrue(controllerResponse.Success);
        }

        [Test]
        public async Task DuplicatedValidOrder_ShouldReturnOrderNumberAlreadyProcessedResponse()
        {
            var client = _factory.CreateClient();
            var content = new StringContent(OrderSamples.FullValidOrder, Encoding.UTF8, "application/json");

            {
                var response = await client.PostAsync("/orders/process", content);
                response.EnsureSuccessStatusCode();

                var responseString = await response.Content.ReadAsStringAsync();
                var controllerResponse = JsonConvert.DeserializeObject<OrderProcessingResult>(responseString);

                // Assert 
                Assert.IsTrue(controllerResponse.Success);
            }

            {
                var response = await client.PostAsync("/orders/process", content);
                response.EnsureSuccessStatusCode();

                var responseString = await response.Content.ReadAsStringAsync();
                var controllerResponse = JsonConvert.DeserializeObject<OrderValidationResult>(responseString);

                // Assert 
                Assert.IsFalse(controllerResponse.Success);
                Assert.AreEqual(OrderValidationError.OrderNumberAlreadyProcessed, controllerResponse.ValidationFailedReason);
            }
        }

        [Test]
        public async Task OrderWithMissingCustomer_ShouldReturnFailedResponse()
        {
            var client = _factory.CreateClient();

            var content = new StringContent(OrderSamples.OrderWithoutCustomer, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/orders/process", content);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var controllerResponse = JsonConvert.DeserializeObject<OrderValidationResult>(responseString);

            // Assert 
            Assert.IsNotNull(controllerResponse);
            Assert.IsFalse(controllerResponse.Success);

            Assert.AreEqual(OrderValidationError.CustomerMissing, controllerResponse.ValidationFailedReason);
        }


}
}