namespace DomainDrivenDesign.TacticalPattern.Factory;
public sealed class Order
{
    public int Id { get; private set; }
    public string CustomerName { get; private set; }
    public decimal Amount { get; private set; }

    private Order() {}

    public static Order CreateOrder(int id, string customerName, decimal amount)
    {
        if(string.IsNullOrEmpty(customerName))
        {
            throw new ArgumentException("CustomerName cannot be null or empty.");
        }
        if(amount <= 0)
        {
            throw new ArgumentException("Amounth must be greater than zero.");
        }

        return new Order
        {
            Id = id,
            CustomerName = customerName,
            Amount = amount
        };
    }
}
