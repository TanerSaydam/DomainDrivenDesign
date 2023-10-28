using DomainDrivenDesign.TacticalPattern.ValueObject.ValueObjects;

namespace DomainDrivenDesign.TacticalPattern.ValueObject;
public sealed class Customer : DomainDrivenDesign.TacticalPattern.Entity.Abstractions.Entity
{
    public Customer(
        Guid id,
        FirstName firstName,
        Address address,
        Money price) : base(id)
    {
        FirstName = firstName;
        Address = address;
        Price = price;
    }

    public FirstName FirstName { get; private set; }//private set ile bu sadece burada ayarlanabilir - init ile sadece bir kez ayarlanabilir
    public Address Address { get; private set; }
    public Money Price { get; private set; }
}
