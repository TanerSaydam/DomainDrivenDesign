using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DomainDrivenDesign.TacticalPattern.DomainEvent.MediatRExample1;
public sealed class OrderCompletedEventHandler1 : INotificationHandler<OrderCompletedEvent1>
{
    public Task Handle(OrderCompletedEvent1 notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Order completed: {notification.OrderId} at {notification.OccurredOn}");
        return Task.CompletedTask;
    }
}

//Dependency Injection
//public void ConfigureServices(IServiceCollection services)
//{
//    services.AddMediatR(typeof(Startup));
//    // ... diğer yapılandırmalar
//}