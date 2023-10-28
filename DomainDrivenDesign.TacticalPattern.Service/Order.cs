using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.TacticalPattern.Service;
public sealed class Order
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
}

public interface IOrderRepository
{
    void Create(Order order);
}

public sealed class OrderRepository : IOrderRepository
{
    public void Create(Order order)
    {
        //işlemler
    }
}

public sealed class OrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public void CreateOrder(Order order)
    {
        if (string.IsNullOrEmpty(order.CustomerName))
        {
            throw new ArgumentException("Customer name cannot be empty or null");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        IOrderRepository orderRepository = new OrderRepository();

        OrderService orderService = new(orderRepository);

        orderService.CreateOrder(new Order() { CustomerName = "Taner Saydam", Id = 0});
    }
}
