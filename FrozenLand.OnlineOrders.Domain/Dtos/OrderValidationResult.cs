using System.Text.Json.Serialization;

namespace FrozenLand.OnlineOrders.Domain
{
    public enum OrderValidationError
    {
        UnknownError,
        NonValidJson,
        OrderNumberAlreadyProcessed,
        CustomerMissing,
        AddressMissing,
        PaymentDetailsMissing,
        PaymentMismatch,
        OrderTotalIsZero,
        NoLinesInOrder
    }

    public class OrderValidationResult: OrderProcessingResult
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OrderValidationError ValidationFailedReason { get; set; }

        public static OrderValidationResult BuildUnsuccessfulValidationResult(OrderValidationError reason,
            string errorMessage = "")
        {
            return new OrderValidationResult()
            {
                Success = false,
                ValidationFailedReason = reason
            };
        }

        public new static OrderValidationResult BuildSuccessfulValidationResult() =>
            new OrderValidationResult() {Success = true};
    }
}