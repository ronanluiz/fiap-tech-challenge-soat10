using Soat10.TechChallenge.Domain.Base;
using Soat10.TechChallenge.Domain.Exceptions;
using Soat10.TechChallenge.Domain.ValueObjects;

namespace Soat10.TechChallenge.Domain.Entities
{
    public class Customer : Entity<int>
    {
        public string Name { get; private set; }
        public Email Email { get; private set; }
        public Cpf Cpf { get; private set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }

        public Customer(string name)
        {
            Name = name;
            Validate();
        }

        public Customer(int id, string name)
        {
            Id = id;
            Name = name;
            Validate();
        }

        public void SetEmail(Email email)
        {
            Email = email;
            Validate();

        }

        public void SetCpf(Cpf cpf)
        {
            Cpf = cpf;
            Validate();
        }

        public void Validate()
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(Name))
            {
                errors.Add("É preciso preencher o campo 'Nome'.");
            }

            if (Name?.Length > 255)
            {
                errors.Add("O campo 'Nome' deve ter até 255 caracteres.");
            }

            try
            {
                Email?.Validate();
                Cpf?.Validate();
            }
            catch (DomainValidationException ex)
            {
                errors.AddRange(ex.Errors);
            }

            if (errors.Any())
            {
                throw new DomainValidationException(errors);
            }
        }

    }
}