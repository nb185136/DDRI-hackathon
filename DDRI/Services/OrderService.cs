using DDRI.DBObjects;
using DDRI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DDRI.Services
{
    public class OrderService
    {
        private DDRIEntities _db = null;
        public OrderService()
        {
            _db = new DDRIEntities();
        }
        public async Task<OrderResponse> Create(int customerId, IList<CartItems> cartItems)
        {
            try
            {
                //get customer
                var customerExist = _db.Customers.Any(t => t.Id == customerId);

                var customer = _db.Customers.Where(t => t.Id == customerId).FirstOrDefault();

                if (customerExist)
                {
                    // create order
                    Order order = new Order()
                    {
                        CustomerId = customerId,
                        EstimatedDeliveryDate = new DateTime(),
                        CreatedOn = DateTime.Now,
                        IsCanceled = false,
                        DeliveredOn = null,
                        UpdatedOn = DateTime.Now
                    };

                    _db.Orders.Add(order);

                    // create order items
                    foreach (var item in cartItems)
                    {
                        var orderItem = _db.OrderItems.Add(new OrderItem
                        {
                            ProductId = item.ProductId,
                            OrderId = order.ID,
                            price = item.Price,
                            CreatedOn = DateTime.Now,
                            Quantity = item.Quantity,
                            UpdatedOn = DateTime.Now
                        });
                    }

                    var dbResult = _db.SaveChanges();

                    if (dbResult > 0)
                    {
                        var result = new OrderResponse()
                        {
                            EstimatedDeliveryDate = DateTime.Now,
                            CartItems = cartItems.ToList(),
                            OrderId = order.ID
                        };

                        return await Task.FromResult<OrderResponse>(result);
                    }
                }

                return null;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while placing an order");
                return null;
            }
        }
    }
}