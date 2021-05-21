using System;
using FrozenLand.OnlineOrders.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FrozenLand.OnlineOrders.Website.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersPresenter _ordersPresenter;

        public OrdersController(IOrdersPresenter ordersPresenter)
        {
            this._ordersPresenter = ordersPresenter;
        }

        [HttpPost]
        [Route("process")]
        public async Task<OrderProcessingResult> Orders()
        {
            try
            {
                var rawOrder = "";
                using (var stream = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    rawOrder = await stream.ReadToEndAsync();
                }

                var result = this._ordersPresenter.ProcessOrder(rawOrder);
                return result;
            }
            catch (Exception ex)
            {
                return OrderProcessingResponse.BuildUnsuccessfulResponse(ex);
            }
        }

        [HttpGet]
        [Route("getall")]
        public OrderProcessingResponse GetOrders()
        {
            try
            {
                var result = this._ordersPresenter.GetOrders().Select(x => x.Number).ToList();

                var response = new OrderProcessingResponse()
                {
                    Success = true,
                    Details = string.Join(",", result)
                };

                return response;

            }
            catch (Exception ex)
            {
                return OrderProcessingResponse.BuildUnsuccessfulResponse(ex);
            }
        }
    }
}
