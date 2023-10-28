using DomainDrivenDesign.TacticalPattern.DomainEvent.BasicExample;
using MediatR;
using System.Runtime.ConstrainedExecution;

namespace DomainDrivenDesign.TacticalPattern.DomainEvent.MediatRExample2;

//Domain Event
public sealed class OrderCompletedEvent2 : INotification
{
    public Order Order { get; }

    public OrderCompletedEvent2(Order order)
    {
        Order = order;
    }
}

//Handlers
public class StockUpdateHandler : INotificationHandler<OrderCompletedEvent2>
{
    public Task Handle(OrderCompletedEvent2 notification, CancellationToken cancellationToken)
    {
        /* ... */
        return Task.CompletedTask;
    }
}

public class CustomerEmailHandler : INotificationHandler<OrderCompletedEvent2>
{
    public Task Handle(OrderCompletedEvent2 notification, CancellationToken cancellationToken)
    {
        /* ... */
        return Task.CompletedTask;
    }
}


public class InvoiceGenerationHandler : INotificationHandler<OrderCompletedEvent2>
{
    public Task Handle(OrderCompletedEvent2 notification, CancellationToken cancellationToken)
    {
        /* ... */
        return Task.CompletedTask;
    }
}

//Service
public class OrderService3
{
    private readonly IMediator _mediatR;

    public OrderService3(IMediator mediatR)
    {
        _mediatR = mediatR;
    }

    public void CompleteOrder(Order order)
    {
        // Do something with order
        _mediatR.Publish(new OrderCompletedEvent2(order));
    }
}

//Avantajlar
//Decoupling: Her bir işlem(StockUpdateHandler, CustomerEmailHandler, InvoiceGenerationHandler) kendi sınıfında ve bu sayede değişiklikler izole bir şekilde yapılabilir.

//Esneklik: Yeni bir işlem eklemek istediğinizde, yalnızca yeni bir handler sınıfı oluşturmanız yeterlidir.Mevcut kodu değiştirmenize gerek yoktur.

//Test Edilebilirlik: Her bir handler'ı bağımsız olarak test edebilirsiniz.

//Bu örnekte görüldüğü gibi, Domain Event yaklaşımı belirli senaryolar için daha uygun olabilir.Ancak her zaman için en iyi çözüm olmayabilir. Projenin ihtiyaçlarına ve karmaşıklığına bağlı olarak en uygun yaklaşımı seçmek önemlidir.