using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesign.TacticalPattern.Repository;
public sealed class Order
{
    public int Id { get; set; }
    public List<OrderLine> OrderLines { get; set; }

    public Order()
    {
        OrderLines = new();
    }
}

public sealed class OrderLine
{
    public int Id { get; set; }
    public string Product { get; set; }
    public int Quantity { get; set; }
}

public sealed class AppDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderLine> OrderLines { get; set; }
}
