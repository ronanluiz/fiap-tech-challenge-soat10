using Soat10.TechChallenge.Application.Exceptions;

namespace Soat10.TechChallenge.Application.Entities
{
    public class Customer : Entity<Guid>
    {
        public string Name { get; private set; }
        public Email Email { get; private set; }
        public Cpf Cpf { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public string Status { get; private set; } = "active";

        public Customer(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Validate();
        }

        public Customer(Guid id, string name)
        {
            Id = id;
            Name = name;
            Validate();
        }

        public void SetEmail(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                Email = new(email);
            }
            Validate();
        }

        public void SetCpf(string cpf)
        {
            if (!string.IsNullOrEmpty(cpf))
            {
                Cpf = new(cpf);
            }
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