namespace DomainDrivenDesign.StrategicPattern.BoundedContent.OrderingContent.Models;
public class Order
{
    public int Id { get; set; }    
    public List<OrderItem> Items { get; set; }
}
