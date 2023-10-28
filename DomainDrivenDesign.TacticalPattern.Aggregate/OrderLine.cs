using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.TacticalPattern.Aggregate;
public sealed class OrderLine
{
    public string ProductName { get; private set; }
    public int Quantity { get; private set; }
    public OrderLine(string productName, int quantity)
    {
        ProductName = productName;
        Quantity = quantity;
    }
}
