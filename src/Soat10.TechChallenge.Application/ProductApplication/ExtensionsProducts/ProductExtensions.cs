using Soat10.TechChallenge.Application.ProductApplication.Requests;
using Soat10.TechChallenge.Application.ProductApplication.Responses;
using Soat10.TechChallenge.Domain.Entities;
using Soat10.TechChallenge.Domain.Enums;

namespace Soat10.TechChallenge.Application.ProductApplication.ExtensionsProducts
{
    public static class ProductExtensions
    {
        public static ProductResponse ProductToCreateProductResponse(this Product product)
        {
            return new ProductResponse
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

        public static Product UpdateProductAttributesToCreateProductResponse(this ProductResponse product, ProductRequest productRequest)
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

        public static Product UpdateProductAttributesToCreateProductResponse(this ProductResponse product)
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


        public static IEnumerable<ProductResponse> ProductToProductResponse(this IEnumerable<Product> products)
        {
            var productResponse = new List<ProductResponse>();

            foreach (var product in products)
            {
                productResponse.Add(
                    new ProductResponse
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

        public static Product CreateProductRequestToProduct(this ProductRequest productRequest)
        {
            return new Product(productRequest.Name ?? "" , productRequest.Description ?? "", productRequest.ProductCategory, productRequest.Price);
        }

        public static Product UpdateProductRequestToProduct(this ProductRequest productRequest, int id)
        {
            return new Product(
                id, 
                productRequest.Name ?? "", 
                productRequest.ProductCategory,
                productRequest.Price,
                productRequest.TimeToPrepare,
                productRequest.Note,
                productRequest.QuantityInStock,
                productRequest.Description ?? ""
            );
        }
    }
}
