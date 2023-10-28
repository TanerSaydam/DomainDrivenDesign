using MediatR;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.PortableExecutable;
using System.Runtime.ConstrainedExecution;
using System.Transactions;
using System;

namespace DomainDrivenDesign.TacticalPattern.DomainEvent.MediatRExample1;
public sealed class OrderService1
{
    private readonly IMediator _mediator;

    public OrderService1(IMediator mediator)
    {
        _mediator = mediator;
    }

    public void CompleteOrder(Guid orderId)
    {
        //Order işlemleri

        //Domain event yayımla
        var orderCompletedEvent = new OrderCompletedEvent1(orderId, DateTime.Now);
        _mediator.Publish(orderCompletedEvent);
    }
}


//Domain Event'ler ve MediatR gibi araçlar, kodunuzun karmaşıklığını yönetmek ve değişikliklere daha kolay uyum sağlamak için birkaç avantaj sunar:

//Decoupling(Bağımsızlık) : Domain Event'ler sayesinde, bir olayın kaynağı ile bu olaya nasıl tepki verileceği arasındaki bağlantıyı koparabilirsiniz. Bu, değişiklik yapmanız gerektiğinde kodunuzu daha kolay bir şekilde güncellemenizi sağlar.

//Esneklik: Aynı Domain Event'e birden fazla handler tanımlayabilirsiniz. Bu sayede, bir olayın meydana gelmesiyle birlikte birden fazla işlemi kolayca tetikleyebilirsiniz.

//Test Edilebilirlik: Domain Event'ler ve onların handler'ları, unit testlerinde kolaylıkla mock edilebilir ve izole bir şekilde test edilebilir.
//Kod Düzeni: MediatR gibi araçlar sayesinde, kodunuz daha temiz ve okunabilir hale gelir.İşlemler arasındaki akışı anlamak daha kolaydır.
//Cross-Cutting Concerns: Aspect-Oriented Programming (AOP) gibi tekniklerle, logging, caching, transaction yönetimi gibi çapraz kesitli işlemleri daha kolay bir şekilde yönetebilirsiniz.

//Skalabilite ve Dağıtım: Microservices mimarisi kullanıyorsanız, Domain Event'ler sayesinde servisler arası iletişimi daha etkili bir şekilde gerçekleştirebilirsiniz.

//Özetle, bu tarz bir yapıyı kullanmak başlangıçta karmaşık gibi görünse de, büyük ve karmaşık projelerde veya mikroservisler arası etkileşimde avantajlarını gösterir. Ancak, küçük projeler veya prototipler için bu kadar detaylı bir yapıya ihtiyaç duymayabilirsiniz; her şey ihtiyaca ve projenin karmaşıklığına bağlıdır.