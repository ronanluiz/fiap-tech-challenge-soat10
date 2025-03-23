using Soat10.TechChallenge.Application.Common.Daos;
using Soat10.TechChallenge.Application.Common.Dtos;
using Soat10.TechChallenge.Application.Entities;

namespace Soat10.TechChallenge.Application.Mappers
{
    public static class MapperEntity
    {
        public static Customer MapToEntity(CustomerDto customerDto)
        {
            var customer = new Customer(customerDto.Name);
            customer.SetCpf(customerDto.Cpf);
            customer.SetEmail(customerDto.Email);

            return customer;
        }

        public static Customer MapToEntity(CustomerRegistrationRequest customerRegistrationRequest)
        {
            var customer = new Customer(customerRegistrationRequest.Name);
            customer.SetCpf(customerRegistrationRequest.Cpf);
            customer.SetEmail(customerRegistrationRequest.Email);

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

            return new Order(orderDto.Id, customer, orderItems, orderDto.OrderNumber);
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

        public static Payment MapToEntity(PaymentDao paymentDao)
        {
            Order order = MapToEntity(paymentDao.Order);

            return new Payment
            (
                paymentDao.Id,
                paymentDao.CreatedAt,
                order,
                paymentDao.TotalAmount,
                paymentDao.QrData,
                paymentDao.ExternalPaymentId,
                paymentDao.PaidAt,
                paymentDao.Status,
                paymentDao.StatusDetail
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

            List<OrderItem> orderItems = new();
            foreach (OrderItemDao item in orderDao.Items)
            {
                orderItems.Add(MapToEntity(item));
            }

            return new Order(
                orderDao.Id, 
                orderDao.Status, 
                customer, 
                orderItems, 
                orderDao.OrderNumber,
                orderDao.CreatedAt
             );
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

        public static ProductDao MapToDao(Product product)
        {
            return new ProductDao()
            {
                Id = product.Id,
                Name = product.Name,
                ProductCategory = product.ProductCategory,
                Price = product.Price,
                TimeToPrepare = product.TimeToPrepare,
                Description = product.Description,
                IsAvailable = product.IsAvailable,
                CreatedAt = product.CreatedAt,
                Status = product.Status,
            };
        }
        public static Order MapToOrder(Cart cart)
        {
            Order order = new(cart.Customer);
            foreach (CartItem item in cart.Items)
            {
                var orderItem = new OrderItem(order.Id, item.Product, item.Quantity, item.Price, item.Notes);
                order.AddItem(orderItem);
            }

            return order;
        }        
    }
}
