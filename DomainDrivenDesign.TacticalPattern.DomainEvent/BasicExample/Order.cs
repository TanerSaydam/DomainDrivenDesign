namespace DomainDrivenDesign.TacticalPattern.DomainEvent.BasicExample;
public sealed class Order
{
    public int Id { get; set; }
    public decimal Amount { get; set; }

    public List<IDomainEvent> DomainEvents { get; } = new List<IDomainEvent>();

    public Order(int id, decimal amount)
    {
        Id = id;
        Amount = amount;

        DomainEvents.Add(new OrderCreatedEvent(id, amount));
    }
}
