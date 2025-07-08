using EcommerceAPI.Entities;

namespace EcommerceAPI.Interfaces;

public interface IOrdersRepository
{
    List<Order> GetAllOrders();
}