using System.Diagnostics.CodeAnalysis;
using FrozenLand.OnlineOrders.Data;

namespace FrozenLand.OnlineOrders.Domain.Validation
{
    public abstract class OrderValidationRuleBase
    {
        public abstract OrderValidationResult Validate([NotNull] Order order, OrdersDbContext context);
    }
}