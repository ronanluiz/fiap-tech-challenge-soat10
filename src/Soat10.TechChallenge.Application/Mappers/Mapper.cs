using Soat10.TechChallenge.Application.Common.Daos;
using Soat10.TechChallenge.Application.Common.Dtos;
using Soat10.TechChallenge.Application.Entities;

namespace Soat10.TechChallenge.Application.Mappers
{
    public static class Mapper
    {
        public static Customer MapToEntity(CustomerDto customerDto)
        {
            var customer = new Customer(customerDto.Name);
            customer.SetCpf(customerDto.Cpf);
            customer.SetEmail(customerDto.Email);

            return customer;
        }

        public static Product MapToEntity(ProductDto productDto)
        {
            return new Product
             (
                productDto.Name,
                productDto.Description,
                productDto.ProductCategory,
                productDto.Price
             );
        }

        public static Order MapToEntity(OrderDto orderDto)
        {
            Customer customer = MapToEntity(orderDto.Customer);

            List<OrderItem> orderItems = new List<OrderItem>();
            foreach (OrderItemDto item in orderDto.Items)
            {
                orderItems.Add(MapToEntity(item));
            }

            return new Order(orderDto.Id, customer, orderItems);
        }

        public static OrderItem MapToEntity(OrderItemDto orderItemDto)
        {
            var product = MapToEntity(orderItemDto.Product);
            return new OrderItem
            (
                orderItemDto.Id,
                orderItemDto.OrderId,
                orderItemDto.ProductId,
                product,
                orderItemDto.Quantity,
                orderItemDto.Price,
                orderItemDto.Note
            );
        }

        public static Cart MapToEntity(CartDao cartDao)
        {
            Customer customer = MapToEntity(cartDao.Customer);

            var items = new List<CartItem>();
            foreach (CartItemDao item in cartDao.Items)
            {
                items.Add(MapToEntity(item));
            }

            return new Cart(cartDao.Id, customer, items, cartDao.Status, cartDao.CreatedAt);
        }

        public static CartItem MapToEntity(CartItemDao cartItemDao)
        {
            Product product = MapToEntity(cartItemDao.Product);
            return new CartItem
            (
                cartItemDao.Id,
                cartItemDao.CartId,
                cartItemDao.ProductId,
                product,
                cartItemDao.Quantity,
                cartItemDao.Notes
            );
        }

        public static CustomerDao? MapToDao(Customer customer)
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

        public static ProductDao MapToDao(Product product)
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

        public static OrderDao MapToDao(Order order)
        {
            CustomerDao customer = MapToDao(order.Customer);

            var orderItems = new List<OrderItemDao>();
            foreach (OrderItem item in order.Items)
            {
                orderItems.Add(MapToDao(item));
            }

            return new OrderDao
            {
                Amount = order.Amount,
                Id = order.Id,
                Customer = customer,
                CustomerId = customer.Id,
                Items = orderItems,
                Status = order.Status
            };
        }
        public static OrderItemDao MapToDao(OrderItem orderItem)
        {
            var product = MapToDao(orderItem.Product);
            return new OrderItemDao
            {
                Id = orderItem.Id,
                Note = orderItem.Note,
                Product = product,
                OrderId = orderItem.OrderId,
                Price = orderItem.Price,
                ProductId = orderItem.ProductId,
                Quantity = orderItem.Quantity
            };
        }

        public static PaymentDao MapToDao(Payment payment)
        {
            return new PaymentDao
            {
                Amount = payment.Amount,
                Order = MapToDao(payment.Order),
                OrderId = payment.OrderId
            };
        }

        public static CartItemDao MapToDao(CartItem item)
        {
            var product = MapToDao(item.Product);
            return new CartItemDao
            {
                Id = item.Id,
                Notes = item.Notes,
                Product = product,
                CartId = item.CartId,
                ProductId = item.ProductId,
                Quantity = item.Quantity
            };
        }

        public static CartDao MapToDao(Cart cart)
        {
            CustomerDao customer = MapToDao(cart.Customer);

            var items = new List<CartItemDao>();
            foreach (CartItem item in cart.Items)
            {
                items.Add(MapToDao(item));
            }

            return new CartDao
            {
                Id = cart.Id,
                Customer = customer,
                CustomerId = customer.Id,
                Items = items,
                Status = cart.Status,
                CreatedAt = cart.CreatedAt
            };
        }

        public static Customer MapToEntity(CustomerDao customerDao)
        {
            var customer = new Customer(customerDao.Id, customerDao.Name);            
            customer.SetCpf(customerDao.Cpf);
            customer.SetEmail(customerDao.Email);

            return customer;
        }

        public static Order MapToEntity(OrderDao orderDao)
        {
            Customer customer = MapToEntity(orderDao.Customer);

            List<OrderItem> orderItems = new List<OrderItem>();
            foreach (OrderItemDao item in orderDao.Items)
            {
                orderItems.Add(MapToEntity(item));
            }

            return new Order(orderDao.Id, customer, orderItems);
        }

        public static OrderItem MapToEntity(OrderItemDao orderItemDao)
        {
            var product = MapToEntity(orderItemDao.Product);
            return new OrderItem
            (
                orderItemDao.Id,
                orderItemDao.OrderId,
                orderItemDao.ProductId,
                product,
                orderItemDao.Quantity,
                orderItemDao.Price,
                orderItemDao.Note
            );
        }

        public static Product MapToEntity(ProductDao productDao)
        {
            return new Product
             (
                productDao.Id,  
                productDao.Name,
                productDao.ProductCategory,
                productDao.Price,
                productDao.TimeToPrepare,
                productDao.Description,
                productDao.IsAvailable
             );
        }

        public static Order MapToOrder(Cart cart)
        {
            Order order = new(cart.Customer);
            foreach (CartItem item in cart.Items)
            {
                var orderItem = new OrderItem(item.Product, item.Quantity, item.Price, item.Notes);
                order.AddItem(orderItem);
            }

            return order;
        }


        public static OrderDto MapToDto(Order orderEntity)
        {
            CustomerDto customer = MapToDto(orderEntity.Customer);

            List<OrderItemDto> orderItems = new List<OrderItemDto>();
            foreach (OrderItem item in orderEntity.Items)
            {
                orderItems.Add(MapToDto(item));
            }

            return new OrderDto
            {
                Amount = orderEntity.Amount,
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
