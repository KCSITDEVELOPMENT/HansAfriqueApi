using HansAfriqueApi.Entities.OrderAggregate;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace HansAfriqueApi.Interface
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethodId, string basketId, AddressEnt shippingAddress);
        Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail);
        Task<Order> GetOrderByIdAsync(int id, string buyerEmail);
        Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync();
    }
}
