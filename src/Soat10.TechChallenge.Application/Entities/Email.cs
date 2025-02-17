using Soat10.TechChallenge.Application.Exceptions;
using System.Text.RegularExpressions;

namespace Soat10.TechChallenge.Application.Entities
{
    public class Email 
    {
        public string Address { get; } = string.Empty;
        protected Email()
        {
        }

        public Email(string address)
        {
            if (string.IsNullOrEmpty(address) || address.Length < 5)
                throw new InvalidEmailException();

            Address = address.ToLower().Trim();
            const string pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

            if (!Regex.IsMatch(address, pattern))
                throw new InvalidEmailException();
        }

        public void Validate()
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(Address))
            {
                errors.Add("É preciso preencher o campo 'Email'.");
            }

            if (!Address.Contains("@") || !Address.Contains("."))
            {
                errors.Add("Email informado em um formato incorreto. Deve ser: 'nome@email.com'.");
            }

            if (errors.Any())
            {
                throw new DomainValidationException(errors);
            }
        }
    }
}
