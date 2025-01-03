namespace Soat10.TechChallenge.Domain.Exceptions
{
    public class DomainValidationException : Exception
    {
        public List<string> Errors { get; }

        public DomainValidationException(IEnumerable<string> errors)
            : base("Um ou mais erros de validação ocorreram.")
        {
            Errors = new List<string>(errors);
        }
    }

}
