using FrozenLand.OnlineOrders.Data;

namespace FrozenLand.OnlineOrders.Domain
{
    public class OrderProcessingResult
    {
        public bool Success { get; set; }
        public string Error { get; set; }

        public static OrderProcessingResult BuildUnsuccessfulValidationResult(string errorMessage)
        {
            return new OrderProcessingResult()
            {
                Success = false,
                Error = errorMessage
            };
        }
        public static OrderProcessingResult BuildSuccessfulValidationResult() =>
            new OrderProcessingResult() { Success = true };

        public static OrderProcessingResult BuildFromDbTransactionResult(DbTransactionResult dbResult)
        {
            return new OrderProcessingResult()
            {
                Success = false,
                Error = dbResult.Error
            };
        }
    }
}