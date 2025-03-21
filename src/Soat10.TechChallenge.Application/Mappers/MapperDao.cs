using Soat10.TechChallenge.Application.Common.Daos;
using Soat10.TechChallenge.Application.Entities;

namespace Soat10.TechChallenge.Application.Mappers
{
    public static class MapperDao
    {
        public static CustomerDao? Map(Customer customer)
        {
            if (customer != null)
            {
                return new CustomerDao
                {
                    Id = customer.Id,
                    Name = customer.Name
                };
            }
            return null;
        }

        public static ProductDao Map(Product product)
        {
            return new ProductDao
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                IsAvailable = product.IsAvailable,
                Price = product.Price,
                ProductCategory = product.ProductCategory,
                Status = product.Status,
                TimeToPrepare = product.TimeToPrepare,
                CreatedAt = product.CreatedAt
            };
        }

        public static OrderDao Map(Order order)
        {
            var orderItems = new List<OrderItemDao>();
            foreach (OrderItem item in order.Items)
            {
                orderItems.Add(MapToDao(item));
            }

            return new OrderDao
            {
                Id = order.Id,
                Amount = order.TotalAmount,
                CustomerId = order.CustomerId,
                Items = orderItems,
                Status = order.Status,
                CreatedAt = order.CreatedAt,
                OrderNumber = order.OrderNumber
            };
        }
        public static OrderItemDao MapToDao(OrderItem orderItem)
        {
            return new OrderItemDao
            {
                Id = orderItem.Id,
                Note = orderItem.Note,
                OrderId = orderItem.OrderId,
                Price = orderItem.Price,
                ProductId = orderItem.ProductId,
                Quantity = orderItem.Quantity
            };
        }

        public static PaymentDao Map(Payment payment)
        {
            return new PaymentDao
            {
                Id = payment.Id,
                TotalAmount = payment.TotalAmount,
                OrderId = payment.OrderId,
                CreatedAt = payment.CreatedAt,
                ExternalPaymentId = payment.ExternalPaymentId,
                PaidAt = payment.PaidAt,
                QrData = payment.QrData,
                Status = payment.Status,
                StatusDetail = payment.StatusDetail
            };
        }

        public static CartItemDao Map(CartItem item)
        {
            return new CartItemDao
            {
                Id = item.Id,
                Notes = item.Notes,
                CartId = item.CartId,
                ProductId = item.ProductId,
                Quantity = item.Quantity
            };
        }

        public static CartDao Map(Cart cart)
        {
            var items = new List<CartItemDao>();
            foreach (CartItem item in cart.Items)
            {
                items.Add(Map(item));
            }

            return new CartDao
            {
                Id = cart.Id,
                CustomerId = cart.CustomerId,
                Items = items,
                Status = cart.Status,
                CreatedAt = cart.CreatedAt
            };
        }

        public static QrCodeOrderDao MapToQrCodeOrder(Order order)
        {
            var items = new List<QrCodeOrderItemDao>();
            foreach (OrderItem item in order.Items)
            {
                items.Add(MapToQrCodeOrderItemDao(item));
            }

            return new QrCodeOrderDao
            {
                Description = $"Solicitação de QR Code para o pedido {order.Id}",
                Title = "Solicitação de QR Code",
                ExternalReference = order.Id.ToString(),
                TotalAmount = order.TotalAmount,
                Items = items,
            };
        }
        public static QrCodeOrderItemDao MapToQrCodeOrderItemDao(OrderItem orderItem)
        {
            return new QrCodeOrderItemDao
            {
                Category = orderItem.Product.ProductCategory.ToString(),
                Description = orderItem.Product.Description,
                Quantity = orderItem.Quantity,
                Title = orderItem.Product.Name,
                TotalAmount = orderItem.TotalAmont,
                UnitMeasure = "unit",
                UnitPrice = orderItem.Price
            };
        }        
    }
}
