using FrozenLand.OnlineOrders.Data;
using FrozenLand.OnlineOrders.Domain.Validation;

namespace FrozenLand.OnlineOrders.Domain
{
    public class CheckOrderNumberRule : OrderValidationRuleBase
    {
        public override OrderValidationResult Validate(Order order, OrdersDbContext context)
        {
            var orderNumber = order.Number;

            if (!string.IsNullOrWhiteSpace(orderNumber))
            {
                var orderPresent = context.Get(x => x.Number == orderNumber);

                return orderPresent != null && orderPresent.Count > 0
                    ? OrderValidationResult.BuildUnsuccessfulValidationResult(OrderValidationError.OrderNumberAlreadyProcessed)
                    : OrderValidationResult.BuildSuccessfulValidationResult();
            }

            return OrderValidationResult.BuildUnsuccessfulValidationResult(OrderValidationError.NonValidJson);
        }
    }
}