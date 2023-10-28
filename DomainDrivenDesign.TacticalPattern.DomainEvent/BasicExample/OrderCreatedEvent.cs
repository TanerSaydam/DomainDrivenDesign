namespace DomainDrivenDesign.TacticalPattern.DomainEvent.BasicExample;
public sealed class OrderCreatedEvent : IDomainEvent
{
    public int OrderId { get; }
    public decimal Amount { get; }

    public OrderCreatedEvent(int orderId, decimal amount)
    {
        OrderId = orderId;
        Amount = amount;
    }
}
