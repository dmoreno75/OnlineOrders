using System;
using System.Collections.Generic;
using FrozenLand.OnlineOrders.Data;
using FrozenLand.OnlineOrders.Domain.Validation;

namespace FrozenLand.OnlineOrders.Domain
{
    public class ValidationPipeline
    {
        private static readonly List<OrderValidationRuleBase> Rules = new List<OrderValidationRuleBase>
        {
            new CheckOrderNumberRule(),
            new CustomerMissingRule()
        };

        public static OrderValidationResult Run(Order order, OrdersDbContext context)
        {
            foreach (var rule in Rules)
            {
                var result = rule.Validate(order, context);
                if (!result.Success) return result;
            }

            return OrderValidationResult.BuildSuccessfulValidationResult();
        }
    }
}