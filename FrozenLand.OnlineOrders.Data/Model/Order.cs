using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrozenLand.OnlineOrders.Data
{
	[Table("Orders")]
	public class Order
	{
		public DateTime CreatedAt { get; set; } = DateTime.Now;
		[Key] [MaxLength(50)] public string Id { get; set; } = Guid.NewGuid().ToString();
		//public DateTime Created { get; set; }
		[MaxLength(10)] public string Number { get; set; }
		public decimal TotalPrice { get; set; }
		public decimal TotalDelivery { get; set; }
		public int TotalItemsCount { get; set; }
		public Customer Customer { get; set; }
		public IList<OrderLine> OrderLines { get; set; }
		public OrderPayment Payment { get; set; }
		public OrderDelivery Delivery { get; set; }
	}
}
