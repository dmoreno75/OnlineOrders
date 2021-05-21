using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrozenLand.OnlineOrders.Data
{
	[Table("OrderDeliveries")]
	public class OrderDelivery
	{
		public DateTime CreatedAt { get; set; } = DateTime.Now;
		[MaxLength(50)] public string Id { get; set; } = Guid.NewGuid().ToString();
		public string OrderId { get; set; }
		public DateTime DateSelected { get; set; }
		[MaxLength(15)] public string TimeslotId { get; set; }
		public decimal Price { get; set; }
	}
}

