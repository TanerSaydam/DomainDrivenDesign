namespace DomainDrivenDesign.TacticalPattern.DomainEvent.BasicExample;
public static class DomainEventDispatcher
{
    public static void Dispatch(List<IDomainEvent> events)
    {
        foreach (var domainEvent in events)
        {
            if(domainEvent is OrderCreatedEvent orderCreated)
            {
                Console.WriteLine($"OrderCreatedEvent: Order ID = {orderCreated.OrderId}, Amount: {orderCreated.Amount}");
                // Burada diğer işlemleri yapabilirsiniz (örn: bir mesaj kuyruğuna event eklemek)
            }
            // Diğer domain event tipleri için de benzer işlemler yapılabilir
        }
    }
}


//Örnek Kullanımı
public class Program
{
    public static void Main()
    {
        // Yeni bir sipariş oluşturalım
        var order = new Order(1, 100m);

        // Siparişle ilgili Domain Event'leri işleyelim
        DomainEventDispatcher.Dispatch(order.DomainEvents);
    }
}