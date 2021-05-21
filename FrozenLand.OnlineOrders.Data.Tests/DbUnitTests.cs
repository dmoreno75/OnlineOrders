using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace FrozenLand.OnlineOrders.Data.Tests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void CanInsertOrderIntoDatabase()
        {
			var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("OrdersInsertTest");

            using var context = new OrdersDbContext(builder.Options);
            var order = new Order();
            context.Add(order);
            var orderId = order.Id;

            using var contextReader = new OrdersDbContext();
            var orders = context.GetAll();

			Assert.AreEqual(1, orders.Count);
			Assert.AreEqual(orderId, orders[0].Id);
		}
    }
}