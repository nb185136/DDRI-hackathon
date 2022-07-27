﻿using DDRI.DBObjects;
using DDRI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DDRI.Services
{
    public class OrderService
    {
        private DDRIEntities _db = null;
        string _rewardValue = ConfigurationManager.AppSettings["RewardValue"];
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

        public async Task<List<Order>> GetOrders()
        {
            try
            {
                var result = _db.Orders.Where(t => t.IsCanceled != true).ToList();
                return await Task.FromResult<List<Order>>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while retrieving orders");
                return null;
            }
        }

        public async Task<List<Order>> GetOrderbyCustomerId(int customerId)
        {
            try
            {
                var result = _db.Orders.Where(t => t.IsCanceled != true && t.CustomerId == customerId).ToList();
                return await Task.FromResult<List<Order>>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while retrieving orders");
                return null;
            }
        }

        public async Task<Order> AddRewardtoOrder(int orderId, DateTime deliveredOn)
        {
            try
            {
                var order = _db.Orders.Where(t => t.IsCanceled != true && t.ID == orderId).FirstOrDefault();

                if (order.EstimatedDeliveryDate != null && order.EstimatedDeliveryDate < deliveredOn)
                {
                    var customer = _db.Customers.Where(t => t.Id == order.CustomerId).FirstOrDefault();
                    customer.RewardPoints += int.Parse(_rewardValue);
                    _db.SaveChanges();
                }
                return await Task.FromResult<Order>(order);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while retrieving orders");
                return null;
            }
        }
    }
}