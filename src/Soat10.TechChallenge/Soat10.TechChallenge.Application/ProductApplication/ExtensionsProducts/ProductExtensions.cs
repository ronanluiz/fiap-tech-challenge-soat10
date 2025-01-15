using Soat10.TechChallenge.Application.ProductApplication.Requests;
using Soat10.TechChallenge.Application.ProductApplication.Responses;
using Soat10.TechChallenge.Domain.Entities;

namespace Soat10.TechChallenge.Application.ProductApplication.ExtensionsProducts
{
    public static class ProductExtensions
    {
        public static CreateProductResponse ProductToCreateProductResponse(this Product product)
        {
            return new CreateProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                ProductCategory = product.ProductCategory,
                Price = product.Price,
                Note = product.Note,
                QuantityInStock = product.QuantityInStock,
                TimeToPrepare = product.TimeToPrepare,
                IsAvailable = product.IsAvailable,
                Status = product.Status
            };
        }

        public static Product UpdateProductAttributesToProduct(this Product product)
        {
            return new Product(
                product.Id,
                product.Name ?? "",
                product.ProductCategory,
                product.Price,
                product.TimeToPrepare,
                product.Note,
                product.QuantityInStock,
                product.Description
                );
        }

        public static Product UpdateProductAttributesToCreateProductResponse(this CreateProductResponse product, CreateProductRequest productRequest)
        {
            return new Product(
                product.Id,
                productRequest.Name ?? "",
                productRequest.ProductCategory,
                productRequest.Price,
                productRequest.TimeToPrepare,
                productRequest.Note,
                productRequest.QuantityInStock,
                productRequest.Description
                );
        }

        public static Product UpdateProductAttributesToCreateProductResponse(this CreateProductResponse product)
        {
            return new Product(
                product.Id,
                product.Name ?? "",
                product.ProductCategory,
                product.Price,
                product.TimeToPrepare,
                product.Note,
                product.QuantityInStock,
                product.Description,
                product.IsAvailable
                );
        }

        public static IEnumerable<GetAllProductResponse> ProductToGetAllProductResponse(this IEnumerable<Product> products)
        {
            var productResponse = new List<GetAllProductResponse>();

            foreach (var product in products)
            {
                productResponse.Add(
                    new GetAllProductResponse
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        ProductCategory = product.ProductCategory,
                        Price = product.Price,
                        Note = product.Note,
                        QuantityInStock = product.QuantityInStock,
                        TimeToPrepare = product.TimeToPrepare,
                        IsAvailable = product.IsAvailable,
                        Status = product.Status
                    });
            }
            return productResponse;
        }

        public static Product CreateProductRequestToProduct(this CreateProductRequest productRequest)
        {
            return new Product(productRequest.Name ?? "", productRequest.ProductCategory, productRequest.Price);
        }


    }
}
