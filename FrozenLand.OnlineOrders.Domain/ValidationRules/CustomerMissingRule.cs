using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using FrozenLand.OnlineOrders.Data;
using FrozenLand.OnlineOrders.Domain.Validation;

namespace FrozenLand.OnlineOrders.Domain
{
    public class CustomerMissingRule : OrderValidationRuleBase
    {
        public override OrderValidationResult Validate(Order order, OrdersDbContext context)
        {
            var customer = order.Customer;

            if (customer != null)
            {

                var isValid = !string.IsNullOrWhiteSpace(customer.Email) &&
                              !string.IsNullOrWhiteSpace(customer.FirstName) &&
                              !string.IsNullOrWhiteSpace(customer.LastName) &&
                              !string.IsNullOrWhiteSpace(customer.PhoneNumber);

                if (isValid) return OrderValidationResult.BuildSuccessfulValidationResult();
            }

            return OrderValidationResult.BuildUnsuccessfulValidationResult(OrderValidationError.CustomerMissing);
        }
    }
}