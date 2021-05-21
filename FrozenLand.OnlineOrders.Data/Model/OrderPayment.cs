using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrozenLand.OnlineOrders.Data
{
    public enum PaymentType
    {
        Card = 1,
        PayPal,
        Klarna,
        ApplePay,
        GooglePay
    }

    [Table("OrderPayments")]
    public class OrderPayment
    {
        [MaxLength(50)] public string Id { get; set; } = Guid.NewGuid().ToString();
        public PaymentType PaymentType { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string OrderId { get; set; }
        public CardDetails CardDetails { get; set; }
        public PayPalDetails PayPalDetails { get; set; }
    }

    public abstract class PaymentDetails
    {
        [MaxLength(50)] [Key] public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string OrderId { get; set; }
    }

    [Table("OrderPaymentsCardDetails")]
    public class CardDetails : PaymentDetails
    {
        public int ExpireYear { get; set; }
        public int ExpireMonth { get; set; }
        public string CardHolder { get; set; }
        public string CardNumber { get; set; }
    }

    [Table("OrderPaymentsPayPalDetails")]
    public class PayPalDetails : PaymentDetails
    {
        public string AuthorisationCorrelationId { get; set; }
        public string AuthorisationCode { get; set; }
        public string PayPalUserId { get; set; }
        public string Token { get; set; }
    }
}
