using Soat10.TechChallenge.Application.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Soat10.TechChallenge.Application.Entities
{
    public class Product : AuditableEntity<int>
    {
        [Required, MaxLength(50)]
        public string? Name { get; private set; }

        [Required, MaxLength(200)]
        public string? Description { get; private set; }

        [Required]
        public CategoryEnum ProductCategory { get; private set; }

        [Range(0.01, double.MaxValue)]
        public double Price { get; private set; }

        public ProductStatusEnum Status { get; private set; } = ProductStatusEnum.OutOfStock;

        [Range(0, 50)]
        public TimeSpan TimeToPrepare { get; private set; } = TimeSpan.FromMinutes(10);

        public string? Note { get; private set; }

        public bool IsAvailable { get; private set; } = true;

        public int QuantityInStock { get; private set; } = 0;

        [JsonConstructor]
        public Product(int id, string name, CategoryEnum productCategory, double price, TimeSpan timeToPrepare, string? note, int quantityInStock = 0, string? description = "", bool isAvailable = false)
        {
            Id = id;
            SetName(name);
            ProductCategory = productCategory;
            SetPrice(price);
            SetTimeToPrepare(timeToPrepare);
            Note = note;
            QuantityInStock = quantityInStock;
            Status = quantityInStock > 0 ? ProductStatusEnum.InStock : ProductStatusEnum.OutOfStock;
            Description = description;
            IsAvailable = isAvailable;
            MarkAsUnavailable(quantityInStock);

        }

        public Product(string name, string description, CategoryEnum productCategory, double price)
        {
            SetName(name);
            Description = description;
            ProductCategory = productCategory;
            SetPrice(price);
            MarkAsUnavailable();
        }

        public Product(string? name)
        {
            Name = name;
        }

        public void UpdateStatus(ProductStatusEnum status)
        {
            if (status == Status)
                throw new InvalidOperationException("The product is already in the given status.");
            Status = status;
        }

        public void MarkAsUnavailable(int quantityInStock = 0)
        {
            if (quantityInStock == 0)
            {
                IsAvailable = false;
            }
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

        private void SetPrice(double price)
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
