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

            var product = new Product(name, category, price, timeToPrepare, note);

            Assert.NotNull(product);
            Assert.Equal(name, product.Name);
            Assert.Equal(category, product.ProductCategory);
            Assert.Equal(price, product.Price);
            Assert.Equal(timeToPrepare, product.TimeToPrepare);
            Assert.Equal(note, product.Note);
            Assert.True(product.IsAvailable);
            Assert.Equal(ProductStatusEnum.Default, product.Status);
        }

        [Fact]
        public void Product_InvalidName_ShouldThrowArgumentException()
        {
            var category = CategoryEnum.Bebida;
            var price = 15.99;
            var timeToPrepare = TimeSpan.FromMinutes(15);

            Assert.Throws<ArgumentException>(() =>
            {
                new Product("  ", category, price, timeToPrepare, null);
            });
        }

        [Fact]
        public void Product_InvalidPrice_ShouldThrowArgumentException()
        {
            var name = "Burger";
            var category = CategoryEnum.Bebida;
            var timeToPrepare = TimeSpan.FromMinutes(15);

            Assert.Throws<ArgumentException>(() =>
            {
                new Product(name, category, -5.00, timeToPrepare, null);
            });
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

            Assert.Throws<InvalidOperationException>(() => product.UpdateStatus(ProductStatusEnum.Default));
        }

        [Fact]
        public void MarkAsUnavailable_ProductAvailable_ShouldSetAsUnavailable()
        {
            var product = CreateValidProduct();

            product.MarkAsUnavailable();

            Assert.False(product.IsAvailable);
        }

        [Fact]
        public void MarkAsUnavailable_ProductAlreadyUnavailable_ShouldThrowInvalidOperationException()
        {
            var product = CreateValidProduct();
            product.MarkAsUnavailable();

            Assert.Throws<InvalidOperationException>(() => product.MarkAsUnavailable());
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
        public void MarkAsAvailable_ProductAlreadyAvailable_ShouldThrowInvalidOperationException()
        {
            var product = CreateValidProduct();

            Assert.Throws<InvalidOperationException>(() => product.MarkAsAvailable());
        }

        [Fact]
        public void SetTimeToPrepare_ValidTime_ShouldUpdateValue()
        {
            var product = CreateValidProduct();
            var newTimeToPrepare = TimeSpan.FromMinutes(20);
            var ArithmeticAverageOfPreparationTime = (newTimeToPrepare + product.TimeToPrepare) / 2;

            product.UpdateTimeToPrepare(newTimeToPrepare);

            Assert.Equal(ArithmeticAverageOfPreparationTime, product.TimeToPrepare);

            newTimeToPrepare = TimeSpan.FromMinutes(30);
            ArithmeticAverageOfPreparationTime = (newTimeToPrepare + product.TimeToPrepare) / 2;

            product.UpdateTimeToPrepare(newTimeToPrepare);

            Assert.Equal(ArithmeticAverageOfPreparationTime, product.TimeToPrepare);

            newTimeToPrepare = TimeSpan.FromMinutes(50);
            ArithmeticAverageOfPreparationTime = (newTimeToPrepare + product.TimeToPrepare) / 2;

            product.UpdateTimeToPrepare(newTimeToPrepare);

            Assert.Equal(ArithmeticAverageOfPreparationTime, product.TimeToPrepare);
        }

        [Fact]
        public void SetTimeToPrepare_InvalidTime_ShouldThrowArgumentException()
        {
            var product = CreateValidProduct();
            var invalidTimeToPrepare = TimeSpan.FromMinutes(60);

            Assert.Throws<ArgumentException>(() => product.UpdateTimeToPrepare(invalidTimeToPrepare));
        }

        private Product CreateValidProduct()
        {
            return new Product(
                name: "Burger",
                productCategory: CategoryEnum.Bebida,
                price: 15.99,
                timeToPrepare: TimeSpan.FromMinutes(15),
                note: "Extra cheese",
                quantityInStock: 10
            );
        }
    }
}
