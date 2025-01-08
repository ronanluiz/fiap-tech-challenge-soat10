using Soat10.TechChallenge.Domain.Base;
using Soat10.TechChallenge.Domain.Exceptions;
using System.Net;
using System.Text.RegularExpressions;

namespace Soat10.TechChallenge.Domain.ValueObjects
{
    public class Email : ValueObject
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
                errors.Add("Email is required.");
            }

            if (!Address.Contains("@") || !Address.Contains("."))
            {
                errors.Add("Invalid email format.");
            }

            if (errors.Any())
            {
                throw new DomainValidationException(errors);
            }
        }
    }
}
