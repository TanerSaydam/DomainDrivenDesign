using MediatR;

namespace DomainDrivenDesign.TacticalPattern.DomainEvent.MediatRExample1;
public sealed class OrderCompletedEvent1 : INotification
{
    public Guid OrderId { get; set; }
    public DateTime OccurredOn { get; set; }

    public OrderCompletedEvent1(Guid orderId, DateTime occuredOn)
    {
        OrderId = orderId;
        OccurredOn = occuredOn;
    }
}
