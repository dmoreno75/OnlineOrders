using FrozenLand.OnlineOrders.Data;
using FrozenLand.OnlineOrders.Domain.Validation;

namespace FrozenLand.OnlineOrders.Domain
{
    public class PaymentMissingRule : OrderValidationRuleBase
    {
        public override OrderValidationResult Validate(Order order, OrdersDbContext context)
        {
            var payment = order.Payment;

            if (payment != null )
            {
                if (payment.Amount <= 0 || payment.Amount != order.TotalPrice)
                    return OrderValidationResult.BuildUnsuccessfulValidationResult(OrderValidationError.PaymentMismatch);
                
                return OrderValidationResult.BuildSuccessfulValidationResult();
            }

            return OrderValidationResult.BuildUnsuccessfulValidationResult(OrderValidationError.PaymentDetailsMissing);
        }
    }
}