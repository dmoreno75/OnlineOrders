using System;
using FrozenLand.OnlineOrders.Domain;

namespace FrozenLand.OnlineOrders.Website.Controllers
{
    public class OrderProcessingResponse: OrderProcessingResult
    {
        public string Details { get; set; }

        public static OrderProcessingResponse BuildFromProcessingResult(OrderProcessingResult processingResult)
        {
            return new OrderProcessingResponse()
            {
                Success = processingResult.Success,
                Error = processingResult.Error
            };
        }

        public static OrderProcessingResponse BuildUnsuccessfulResponse(Exception ex)
        {
            return new OrderProcessingResponse()
            {
                Success = false,
                Error = ex.Message
            };
        }
    }
}