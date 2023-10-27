namespace DomainDrivenDesign.TacticalPattern.Entity.Abstractions;
public abstract class Entity : IEquatable<Entity>
{
    public Guid Id { get; private init; }

    public Entity(Guid id)
    {
        Id = id;
    }

    public override bool Equals(object? obj)
    {
        if(obj is null)
        {
            return false;
        }

        if(obj.GetType() != GetType())
        {
            return false;
        }

        if(obj is not Entity entity)
        {
            return false;
        }

        return entity.Id == Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public bool Equals(Entity? other)
    {
        if(other is null)
        {
            return false;
        }

        if(other is not Entity entity)
        {
            return false;
        }

        if(other.GetType() != GetType())
        {
            return false;
        }

        return other.Id == Id;
    }
    

    public static bool operator ==(Entity? first, Entity? second)
    {
        return first is not null && second is not null && first.Equals(second);
    }
    public static bool operator !=(Entity? first, Entity? second)
    {
        return !(first == second);
    }

}
//Equals(object? obj) metodu zaten Entity sınıfında override edilmişti.Bunun yanı sıra, IEquatable<T> arayüzünü uygulamak için Equals(T obj) metodu da tanımlanmış.Her iki metod da bir Entity nesnesinin başka bir Entity nesnesiyle eşit olup olmadığını kontrol eder, ancak farklı senaryolar için tasarlanmışlardır.

//Equals(object? obj): Bu metod, eşitlik kontrolü için.NET'in temel object tipi üzerinde çalışır. Genellikle koleksiyonlar gibi genel veri yapıları tarafından çağrılır.
//Equals(T obj): IEquatable<T>'dan geldiğinde, bu metod daha tip-spesifik eşitlik için kullanılır ve boxing/unboxing gibi performans maliyetlerini önlemeye yardımcı olabilir.
//Her iki metod da varsa, Equals(T obj) genellikle Equals(object? obj)'den daha hızlı çalışacaktır, çünkü tip dönüşümü yapmaya gerek kalmaz. Bu yüzden, genellikle Equals(object? obj) metodunun içinde Equals(T obj)'yi çağırırız, böylece her iki senaryo için de optimize edilmiş eşitlik mantığına sahip oluruz.