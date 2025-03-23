using Soat10.TechChallenge.Application.Common.Responses;
using Soat10.TechChallenge.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soat10.TechChallenge.Application.Presenters
{
    public class ProductPresenter
    {
        public static IEnumerable<GetProductResponse> ProductsPresenterGeneric (IEnumerable<Product> productsEntity)
        {
            IList<GetProductResponse> productsResponse = new List<GetProductResponse>();

            foreach (var product in productsEntity) 
            {
                productsResponse.Add(new GetProductResponse()
                {
                    Id = product.Id,
                    CreatedAt = product.CreatedAt,
                    Description = product.Description,  
                    IsAvailable = product.IsAvailable,  
                    Name = product.Name,
                    Price = product.Price,
                    ProductCategory = product.ProductCategory,
                    Status = product.Status,
                    TimeToPrepare = product.TimeToPrepare,
                });
            }
            return productsResponse;
        }

        public static IEnumerable<GetProductResponse> ProductsPresenterClient(IEnumerable<Product> productsEntity)
        {
            IList<GetProductResponse> productsResponse = new List<GetProductResponse>();

            foreach (var product in productsEntity)
            {
                productsResponse.Add(new GetProductResponse()
                {
                    Id = product.Id,
                    CreatedAt = product.CreatedAt,
                    Description = product.Description,
                    IsAvailable = product.IsAvailable,
                    Name = product.Name,
                    Price = product.Price,
                    ProductCategory = product.ProductCategory,
                    Status = product.Status,
                    TimeToPrepare = product.TimeToPrepare,
                });
            }
            return productsResponse;
        }

        public static GetProductResponse ProductPresenterClient(Product productEntity)
        {
            return new GetProductResponse()
            {
                Id = productEntity.Id,
                CreatedAt = productEntity.CreatedAt,
                Description = productEntity.Description,
                IsAvailable = productEntity.IsAvailable,
                Name = productEntity.Name,
                Price = productEntity.Price,
                ProductCategory = productEntity.ProductCategory,
                Status = productEntity.Status,
                TimeToPrepare = productEntity.TimeToPrepare,
            };
        }
    }
}
