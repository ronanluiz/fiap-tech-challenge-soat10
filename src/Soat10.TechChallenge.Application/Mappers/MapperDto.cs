using Soat10.TechChallenge.Application.Common.Dtos;
using Soat10.TechChallenge.Application.Entities;

namespace Soat10.TechChallenge.Application.Mappers
{
    public static class MapperDto
    {   
        public static OrderDto Map(Order orderEntity)
        {
            CustomerDto customer = MapToDto(orderEntity.Customer);

            List<OrderItemDto> orderItems = new List<OrderItemDto>();
            foreach (OrderItem item in orderEntity.Items)
            {
                orderItems.Add(MapToDto(item));
            }

            return new OrderDto
            {
                Amount = orderEntity.TotalAmount,
                Id = orderEntity.Id,
                Customer = customer,
                CustomerId = orderEntity.CustomerId,
                Items = orderItems,
                Status = orderEntity.Status
            };
        }

        public static OrderItemDto MapToDto(OrderItem orderItemEntity)
        {
            ProductDto product = MapToDto(orderItemEntity.Product);
            return new OrderItemDto
            {
                Id = orderItemEntity.Id,
                OrderId = orderItemEntity.OrderId,
                ProductId = orderItemEntity.ProductId,
                Product = product,
                Quantity = orderItemEntity.Quantity,
                Price = orderItemEntity.Price,
                Note = orderItemEntity.Note
            };
        }

        public static CustomerDto MapToDto(Customer customerEntity)
        {
            return new CustomerDto()
            {
                Cpf = customerEntity.Cpf.Number,
                CreatedAt = customerEntity.CreatedAt,
                Email = customerEntity.Email.Address,
                Id = customerEntity.Id,
                Name = customerEntity.Name,
                Status = customerEntity.Status
            };
        }

        public static ProductDto MapToDto(Product productEntity)
        {
            return new ProductDto
            {
                CreatedAt = productEntity.CreatedAt,
                Status = productEntity.Status,
                Description = productEntity.Description,
                Id = productEntity.Id,
                IsAvailable = productEntity.IsAvailable,
                Name = productEntity.Name,
                Price = productEntity.Price,
                ProductCategory = productEntity.ProductCategory,
                TimeToPrepare = productEntity.TimeToPrepare
            };
        }
    }
}
