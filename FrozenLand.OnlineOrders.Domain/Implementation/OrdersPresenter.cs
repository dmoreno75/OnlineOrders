using FrozenLand.OnlineOrders.Data;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FrozenLand.OnlineOrders.Domain
{
    public class OrdersPresenter : IOrdersPresenter
	{
		private OrdersDbContext context;

		public OrdersPresenter(IOptions<ConnectionStringSettings> settings)
		{
			context = new OrdersDbContext(
                settings.Value.OrdersDb,
                settings.Value.InMemory
			);
		}

		public IList<Order> GetOrders()
		{
			return context.GetAll();
		}

		public OrderProcessingResult ProcessOrder(string rawOrder)
        {
            var (errorDehydrateResult, order) = DehydrateOrder(rawOrder);
            if (errorDehydrateResult != null) return errorDehydrateResult;

            var errorValidationResult = ValidationPipeline.Run(order, context);
            if (errorValidationResult != null && !errorValidationResult.Success) 
                return errorValidationResult;

            var dbTransactionResult = StoreOrder(order);

            return dbTransactionResult.Success
                ? OrderProcessingResult.BuildSuccessfulValidationResult()
                : OrderProcessingResult.BuildFromDbTransactionResult(dbTransactionResult);
        }

        private DbTransactionResult StoreOrder(Order order)
        {
            try
            {
                return context.Add(order);
            }
            catch (Exception ex)
            {
                return DbTransactionResult.BuildUnsuccessfulValidationResult(ex.Message);
            }
        }

        private (OrderValidationResult, Order) DehydrateOrder(string rawOrder)
        {
            try
            {
                return (null, JsonConvert.DeserializeObject<Order>(rawOrder));
            }
            catch (Exception ex)
            {
                return (OrderValidationResult.BuildUnsuccessfulValidationResult(OrderValidationError.NonValidJson, ex.Message), null);
            }
        }
    }
}
