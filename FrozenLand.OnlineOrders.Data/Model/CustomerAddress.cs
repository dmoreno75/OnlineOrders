using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrozenLand.OnlineOrders.Data
{
	[Table("CustomerAddresses")]
	public class CustomerAddress
	{
		[MaxLength(50)] public string Id { get; set; } = Guid.NewGuid().ToString();
		public DateTime CreatedAt { get; set; } = DateTime.Now;
		[MaxLength(200)] public string FullAddress { get; set; }
		[MaxLength(10)] public string Postcode { get; set; }
        [MaxLength(50)] public string Town { get; set; }
		public string CustomerId { get; set; }
	}
}
