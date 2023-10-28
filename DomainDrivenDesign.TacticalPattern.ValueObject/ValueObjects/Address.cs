namespace DomainDrivenDesign.TacticalPattern.ValueObject.ValueObjects;
public sealed record Address(
    string Country,
    string State,
    string ZipCode,
    string City,
    string Street);
