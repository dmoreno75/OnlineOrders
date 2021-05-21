using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrozenLand.OnlineOrders.Data
{
	[Table("Customers")]
	public class Customer
	{
		public DateTime CreatedAt { get; set; } = DateTime.Now;
		[MaxLength(50)] public string Id { get; set; } = Guid.NewGuid().ToString();
		[MaxLength(50)] public string FirstName { get; set; }
		[MaxLength(50)] public string LastName { get; set; }
		[MaxLength(50)] public string Email { get; set; }
		[MaxLength(15)] public string PhoneNumber { get; set; }
		public string OrderId { get; set; }
		public CustomerAddress Address { get; set; }
	}
}

