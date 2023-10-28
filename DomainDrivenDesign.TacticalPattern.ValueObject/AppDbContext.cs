using DomainDrivenDesign.TacticalPattern.ValueObject.ValueObjects;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System.Runtime.ConstrainedExecution;

namespace DomainDrivenDesign.TacticalPattern.ValueObject;
public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Customer> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().Property(customer => customer.FirstName)
            .HasMaxLength(50)
            .HasConversion(firstName => firstName.Value, value => new ValueObjects.FirstName(value));

        modelBuilder.Entity<Customer>().OwnsOne(customer => customer.Address, addresBuilder =>
        {
            addresBuilder.Property(p => p.Country).HasMaxLength(50);
            addresBuilder.Property(p => p.Street).HasMaxLength(50);
            addresBuilder.Property(p => p.City).HasMaxLength(50);
            addresBuilder.Property(p => p.State).HasMaxLength(50);
        });

        modelBuilder.Entity<Customer>().OwnsOne(customer => customer.Price, priceBuilder =>
        {
            priceBuilder.Property(price => price.Currency)
            .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
            priceBuilder.Property(price => price.Amount)
            .HasColumnType("money");
        });
    }
}

//Entity Framework Core(EF Core) ile çalışırken, değer nesneleri(Value Objects) için veritabanında nasıl saklandığını ve nasıl haritalandığını belirtmek için HasConversion ve OwnsOne yöntemleri kullanılır.Bu iki yöntem arasındaki temel farkları aşağıda açıklıyorum:

//HasConversion:
//HasConversion yöntemi, bir özellik değerinin nasıl bir veritabanı sütun değerine dönüştürüleceğini ve bu sütun değerinin nasıl geri bir özellik değerine dönüştürüleceğini belirtmek için kullanılır.
//Bu, kompleks tipleri veya özel tipleri veritabanında basit bir sütun değeri (örneğin bir string veya int) olarak saklamak için kullanılır.
//Örneğinizde, UserId ve FirstName tipindeki değer nesneleri basit bir değere dönüştürülüyor (.Value ile) ve bu basit değer veritabanında saklanıyor.Veritabanından okuma yapıldığında ise bu basit değer tekrar ilgili değer nesnesine dönüştürülüyor.
//OwnsOne:
//OwnsOne yöntemi, bir varlıkta bir değer nesnesi (Value Object) olduğunu belirtmek için kullanılır.
//Bu yöntem ile belirtilen değer nesnesi, ana varlığın bir parçası olarak kabul edilir ve aynı tabloda (veya ilişkisel bir tabloda) saklanır.
//OwnsOne kullanıldığında, değer nesnesindeki tüm özellikler ana varlığın tablosunda sütunlar olarak saklanır.Bu özelliklerin isimleri genellikle değer nesnesinin adı ve özellik adının birleşimi olarak oluşturulur.
//Özetle, HasConversion bir özellik değerini nasıl bir veritabanı sütun değerine dönüştüreceğinizi ve bu sütun değerini nasıl geri bir özellik değerine dönüştüreceğinizi belirtirken, OwnsOne bir varlıkta bir değer nesnesi olduğunu ve bu değer nesnesinin nasıl saklanacağını belirtir.İkisi farklı senaryolar için kullanılır ve genellikle birlikte kullanılmazlar. Ancak, her iki yöntemin de değer nesneleri ile çalışırken kullanılmasının yararları vardır.