namespace DomainDrivenDesign.TacticalPattern.Factory;
public static class OrderFactory
{
    public static Order CreateNewOrder(int id, string customerName, decimal amount)
    {
        return Order.CreateOrder(id, customerName, amount);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Order newOrder = OrderFactory.CreateNewOrder(1, "Jhon Doe", 100.50m);
        Console.WriteLine($"Order Created: Id = {newOrder.Id}, CustomerName = {newOrder.CustomerName}, Amount = {newOrder.Amount}");
    }
}
