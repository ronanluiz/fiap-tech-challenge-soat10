using Soat10.TechChallenge.Application.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Soat10.TechChallenge.Application.Entities
{
    public class Product : Entity<int>
    {
        [Required, MaxLength(50)]
        public string? Name { get; private set; }

        [Required, MaxLength(200)]
        public string? Description { get; private set; }

        [Required]
        public CategoryEnum ProductCategory { get; private set; }

        public decimal Price { get; private set; }

        public ProductStatusEnum Status { get; private set; } = ProductStatusEnum.OutOfStock;

        [Range(0, 50)]
        public TimeSpan TimeToPrepare { get; private set; } = TimeSpan.FromMinutes(10);

        public bool IsAvailable { get; private set; } = true;

        public DateTime? CreatedAt { get; private set; }

        public Product()
        {
            CreatedAt = DateTime.UtcNow;
            ProductCategory = CategoryEnum.NaoDefinida;
        }

        [JsonConstructor]
        public Product(int id, string name, CategoryEnum productCategory, decimal price, TimeSpan timeToPrepare, string? description = "", bool isAvailable = false) : this()
        {
            Id = id;
            SetName(name);
            ProductCategory = productCategory;
            SetPrice(price);
            SetTimeToPrepare(timeToPrepare);
            Status = ProductStatusEnum.InStock;
            Description = description;
            IsAvailable = isAvailable;
        }

        public Product(string name, string description, CategoryEnum productCategory, decimal price) : this()
        {
            SetName(name);
            Description = description;
            ProductCategory = productCategory;
            SetPrice(price);
        }

        public Product(string? name) : this()
        {
            Name = name;
        }

        public void UpdateStatus(ProductStatusEnum status)
        {
            if (status == Status)
                throw new InvalidOperationException("The product is already in the given status.");
            Status = status;
        }

        public void MarkAsUnavailable()
        {   
            IsAvailable = false;
        }

        public void MarkAsAvailable()
        {
            IsAvailable = true;
        }

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length > 50)
                throw new ArgumentException("Invalid name.");
            Name = name;
        }

        private void SetPrice(decimal price)
        {
            if (price <= 0)
                throw new ArgumentException("Price must be greater than zero.");
            Price = price;
        }

        private void SetTimeToPrepare(TimeSpan timeToPrepare)
        {
            if (timeToPrepare.TotalMinutes > 50)
                throw new ArgumentException("Time to prepare exceeds the limit.");
            TimeToPrepare = timeToPrepare;
        }

        public void UpdateTimeToPrepare(TimeSpan timeToPrepare)
        {
            if (timeToPrepare.TotalMinutes > 50)
                throw new ArgumentException("Time to prepare exceeds the limit.");
            TimeToPrepare = (timeToPrepare + TimeToPrepare) / 2;
        }
    }
}
