using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesign.TacticalPattern.Repository;
public interface IOrderRepository
{
    Order GetById(int id);
    void Save(Order order);
}


public sealed class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }

    public Order GetById(int id)
    {
        return _context.Orders.Include(p => p.OrderLines).FirstOrDefault();
    }

    public void Save(Order order)
    {
        if(order.Id == 0)
        {
            _context.Orders.Add(order);
        }
        else
        {
            var existingOrder = GetById(order.Id);
            if(existingOrder != null)
            {
                _context.Entry(existingOrder).CurrentValues.SetValues(order);
                existingOrder.OrderLines = order.OrderLines;
            }
        }

        _context.SaveChanges();
    }
}