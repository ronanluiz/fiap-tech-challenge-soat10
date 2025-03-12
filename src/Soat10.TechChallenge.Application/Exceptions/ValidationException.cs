namespace Soat10.TechChallenge.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public List<string> Errors { get; }

        public ValidationException(string message)
        {
            Errors = [message];
        }

        public ValidationException(IEnumerable<string> errors)
            : base("Um ou mais erros de validação ocorreram.")
        {
            Errors = [.. errors];
        }
    }
}
