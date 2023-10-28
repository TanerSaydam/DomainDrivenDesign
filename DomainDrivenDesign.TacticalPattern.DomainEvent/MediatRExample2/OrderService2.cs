using DomainDrivenDesign.TacticalPattern.DomainEvent.BasicExample;

namespace DomainDrivenDesign.TacticalPattern.DomainEvent.MediatRExample2;
public sealed class OrderService2
{
    public void CompleteOrder(Order order)
    {
        UpdateStock(order);
        SendEmailToCustomer(order);
        GenerateInvoice(order);
    }

    private void GenerateInvoice(Order order)
    {
        /* ... */
    }

    private void SendEmailToCustomer(Order order)
    {
        /* ... */
    }
    private void UpdateStock(Order order)
    {
        /* ... */
    }
}

//Sorunlar
//Kohesyon: OrderService sınıfı zamanla büyüyebilir ve birçok farklı sorumluluğu olabilir.Bu durum, sınıfın bakımını ve anlaşılabilirliğini zorlaştırır.

//Esneklik: Eğer başka bir işlem (örneğin, müşteriye SMS göndermek) eklemek isterseniz, OrderService'i değiştirmeniz gerekecektir. Bu, Open/Closed prensibine aykırıdır.

//Test Edilebilirlik: Bu tür bir yapıyı test etmek daha karmaşık olabilir.
