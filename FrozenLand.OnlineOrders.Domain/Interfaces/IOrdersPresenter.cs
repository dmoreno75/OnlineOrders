using System.Collections.Generic;
using FrozenLand.OnlineOrders.Data;

namespace FrozenLand.OnlineOrders.Domain
{
    public interface IOrdersPresenter
    {
        IList<Order> GetOrders();
        OrderProcessingResult ProcessOrder(string order);
    }
}