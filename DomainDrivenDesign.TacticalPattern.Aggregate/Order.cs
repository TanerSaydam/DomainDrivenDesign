namespace DomainDrivenDesign.TacticalPattern.Aggregate;
public sealed class Order
{
    public int Id { get; private set; }
    public List<OrderLine> OrderLines { get; private set; }

    public Order()
    {
        OrderLines = new List<OrderLine>();
    }

    public void AddOrderLine(string productName, int quantity)
    {
        if(quantity <= 0)
        {
            throw new ArgumentException("Quantity should be grater than zero");
        }

        OrderLines.Add(new OrderLine(productName, quantity));
    }

    public void RemoveOrderLine(string productName)
    {
        var orderLine = OrderLines.First(ol => ol.ProductName == productName);
        if(orderLine is not null)
        {
            OrderLines.Remove(orderLine);
        }
    }

    //using(var context = new OrderDbContext())
    //{
    //    var order = context.Orders.Include(o => o.OrderLines).FirstOrDefault(o => o.Id == someOrderId);

    //    if(order != null)
    //    {
    //        order.RemoveOrderLine("SomeProductName");
    //        context.SaveChanges();
    //    }
    //}
}


//Bu örnekte Order sınıfı aggregate root'tur ve OrderLine sınıfı ise ona ait bir parçadır.
//İş kuralları (AddOrderLine metodu içinde) aggregate root üzerinden yönetilir.
//Böylece, Order nesnesinin her zaman geçerli ve tutarlı bir durumda olması sağlanır.

//Aggregate, Aggregate Root ve bu Aggregate Root'a bağlı olan diğer nesnelerin bir araya getirilmesiyle oluşan bir bileşiktir.
//Yani Aggregate, bir iş veya iş sürecini temsil eden ve birlikte işlenmesi gereken bir grup nesnenin kombinasyonudur.

//Örneğin, Order(Aggregate Root) ve OrderLine'lar bir "Sipariş" iş sürecini temsil eder.
//Order sınıfı bu Aggregate'in köküdür ve tüm işlemler(ekleme, çıkarma, güncelleme vb.) bu Aggregate Root üzerinden gerçekleştirilir.

//Bu yapı, tüm nesneler arasında iş kurallarının ve veri bütünlüğünün korunmasını sağlar.
//Her bir Aggregate, kendi içinde tutarlı olmalıdır ve Aggregate Root, bu tutarlılığı sağlamak için vardır.

//OrderLine Aggregate değildir; o bir Aggregate parçasıdır.
//Aggregate genellikle bir Aggregate Root ve ona bağlı olan nesnelerin (örneğimizde OrderLine gibi) kombinasyonudur.
//Bu örnekte, Order Aggregate Root'tur ve OrderLine nesneleri bu Aggregate'in bir parçasıdır.
//Tüm işlemler (AddOrderLine, RemoveOrderLine vb.) Aggregate Root(Order) üzerinden yapılır, böylece iş kuralları ve veri bütünlüğü korunur.

//Bu durumda, Order sınıfı Aggregate Root'tur ve OrderLine sınıfı Aggregate'in bir parçasıdır.
//İkisi bir araya geldiğinde bir "Order Aggregate" oluştururlar.
//Yani, "Order Aggregate" bu iki sınıfın (Order ve OrderLine) bir araya gelmesidir.
//Tüm işlemler(AddOrderLine, RemoveOrderLine, vs.) Aggregate Root üzerinden gerçekleştirilir.