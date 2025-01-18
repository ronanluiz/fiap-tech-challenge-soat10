using Soat10.TechChallenge.Domain.Entities;
using Soat10.TechChallenge.Domain.Enums;

namespace Soat10.TechChallenge.Domain.Tests.Entities.Tests
{
    public class ProductTests
    {
        [Fact]
        public void Product_ValidParameters_ShouldCreateSuccessfully()
        {
            var name = "Burger";
            var category = CategoryEnum.Lanche;
            var price = 15.99;
            var timeToPrepare = TimeSpan.FromMinutes(15);
            var note = "Extra cheese";

            var product = new Product(name, category, price);

            Assert.NotNull(product);
            Assert.Equal(name, product.Name);
            Assert.Equal(category, product.ProductCategory);
            Assert.Equal(price, product.Price);
            Assert.False(product.IsAvailable);
            Assert.Equal(ProductStatusEnum.OutOfStock, product.Status); // Default status based on stock
        }

        [Fact]
        public void Product_InvalidName_ShouldThrowArgumentException()
        {
            var category = CategoryEnum.Bebida;
            var price = 15.99;

            Assert.Throws<ArgumentException>(() => new Product("  ", category, price));
            Assert.Throws<ArgumentException>(() => new Product(new string('A', 51), category, price)); // Name too long
        }

        [Fact]
        public void Product_InvalidPrice_ShouldThrowArgumentException()
        {
            var name = "Burger";
            var category = CategoryEnum.Bebida;

            Assert.Throws<ArgumentException>(() => new Product(name, category, 0));
            Assert.Throws<ArgumentException>(() => new Product(name, category, -5.00));
        }

        [Fact]
        public void Product_InvalidTimeToPrepare_ShouldThrowArgumentException()
        {
            var name = "Burger";
            var category = CategoryEnum.Bebida;
            var price = 15.99;

            Assert.Throws<ArgumentException>(() => new Product(Guid.NewGuid(), name, category, price, TimeSpan.FromMinutes(60), "Note", 0));
        }

        [Fact]
        public void UpdateStatus_ValidStatus_ShouldChangeStatus()
        {
            var product = CreateValidProduct();

            product.UpdateStatus(ProductStatusEnum.Discontinued);

            Assert.Equal(ProductStatusEnum.Discontinued, product.Status);
        }

        [Fact]
        public void UpdateStatus_SameStatus_ShouldThrowInvalidOperationException()
        {
            var product = CreateValidProduct();

            Assert.Throws<InvalidOperationException>(() => product.UpdateStatus(product.Status));
        }

        [Fact]
        public void MarkAsUnavailable_ProductAvailable_ShouldSetAsUnavailable()
        {
            var product = CreateValidProduct();

            product.MarkAsUnavailable();

            Assert.False(product.IsAvailable);
        }


        [Fact]
        public void MarkAsAvailable_ProductUnavailable_ShouldSetAsAvailable()
        {
            var product = CreateValidProduct();
            product.MarkAsUnavailable();

            product.MarkAsAvailable();

            Assert.True(product.IsAvailable);
        }

        [Fact]
        public void UpdateTimeToPrepare_ValidTime_ShouldUpdateValue()
        {
            var product = CreateValidProduct();
            var newTimeToPrepare = TimeSpan.FromMinutes(20);

            var expectedTime = (newTimeToPrepare + product.TimeToPrepare) / 2;

            product.UpdateTimeToPrepare(newTimeToPrepare);

            Assert.Equal(expectedTime, product.TimeToPrepare);
        }

        [Fact]
        public void UpdateTimeToPrepare_InvalidTime_ShouldThrowArgumentException()
        {
            var product = CreateValidProduct();
            var invalidTimeToPrepare = TimeSpan.FromMinutes(60);

            Assert.Throws<ArgumentException>(() => product.UpdateTimeToPrepare(invalidTimeToPrepare));
        }

        [Fact]
        public void Product_QuantityInStock_ShouldUpdateStatusCorrectly()
        {
            var product = new Product("Burger", CategoryEnum.Lanche, 10.0);

            Assert.Equal(ProductStatusEnum.OutOfStock, product.Status);

            var productWithStock = new Product(Guid.NewGuid(), "Pizza", CategoryEnum.Lanche, 20.0, TimeSpan.FromMinutes(10), null, 5);

            Assert.Equal(ProductStatusEnum.InStock, productWithStock.Status);
        }

        [Fact]
        public void Product_JsonConstructor_ShouldSetPropertiesCorrectly()
        {
            var id = Guid.NewGuid();
            var name = "Pizza";
            var category = CategoryEnum.Lanche;
            var price = 25.99;
            var timeToPrepare = TimeSpan.FromMinutes(20);
            var note = "No onions";
            var quantityInStock = 10;
            var description = "Delicious pizza";

            var product = new Product(id, name, category, price, timeToPrepare, note, quantityInStock, description, true);

            Assert.Equal(id, product.Id);
            Assert.Equal(name, product.Name);
            Assert.Equal(category, product.ProductCategory);
            Assert.Equal(price, product.Price);
            Assert.Equal(timeToPrepare, product.TimeToPrepare);
            Assert.Equal(note, product.Note);
            Assert.Equal(description, product.Description);
            Assert.Equal(ProductStatusEnum.InStock, product.Status);
            Assert.True(product.IsAvailable);
        }

        private Product CreateValidProduct()
        {
            return new Product(
                Guid.NewGuid(),
                "Burger",
                CategoryEnum.Bebida,
                15.99,
                TimeSpan.FromMinutes(15),
                "Extra cheese",
                10,
                "Delicious burger"
            );
        }
    }
}
