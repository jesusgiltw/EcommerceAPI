using EcommerceAPI.Data;
using EcommerceAPI.Entities;
using EcommerceAPI.Interfaces;

namespace EcommerceAPI.Repositories;

public class OrdersRepository : IOrdersRepository
{
    private readonly DatabaseContext _dbContext;

    public OrdersRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Order> GetAllOrders()
    {
        using var connection = _dbContext.GetConnection();
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM orders";

        var orders = new List<Order>();
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            orders.Add(new Order
            {
                OrderId = reader.GetString(0),
                CustomerId = reader.GetString(1),
                OrderDate = reader.GetDateTime(2)
            });
        }

        return orders;
    }
}