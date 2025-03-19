namespace Soat10.TechChallenge.Application.Exceptions
{
    public class PaymentServiceException : Exception
    {
        public PaymentServiceException(string message): base(message)
        {
        }

        public PaymentServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
