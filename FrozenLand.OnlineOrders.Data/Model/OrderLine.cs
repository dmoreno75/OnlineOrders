using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrozenLand.OnlineOrders.Data
{
	[Table("OrderLines")]
	public class OrderLine
	{
		public DateTime CreatedAt { get; set; } = DateTime.Now;
		[MaxLength(50)] public string Id { get; set; } = Guid.NewGuid().ToString();
		[MaxLength(15)] public string SkuVariant { get; set; }
		[MaxLength(20)] public string Sku { get; set; }
		public string OrderId { get; set; }
		public decimal Price { get; set; }
		public decimal Discount { get; set; }
		[MaxLength(10)] public string AppliedPromotion { get; set; }
	}
}
