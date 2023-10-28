namespace DomainDrivenDesign.TacticalPattern.ValueObject.ValueObjects;
public sealed record Currency
{
    internal static readonly Currency None = new(""); //sadece aynı assembly de ulaşılabilsin diye.
    public static readonly Currency Usd = new("USD");
    public static readonly Currency Try = new("TRY");

    public string Code { get; init; }
    private Currency(string code) => Code = code;

    public static readonly IReadOnlyCollection<Currency> All = new[] { Usd, Try };
    public static Currency FromCode(string code)
    {
        return All.FirstOrDefault(x => x.Code == code) ??
            throw new ArgumentException($"Currency with code {code} not found");
    }

}
