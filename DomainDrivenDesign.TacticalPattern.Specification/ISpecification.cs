namespace DomainDrivenDesign.TacticalPattern.Specification;
public class Product
{
    public int Stock { get; set; }
    public bool IsActive { get; set; }
}
public interface ISpecification<T>
{
    bool IsSatisfied(T item);
}

public class ProductIsInStockSpecification : ISpecification<Product>
{
    public bool IsSatisfied(Product item)
    {
        return item.Stock > 0;
    }
}

public class ProductIsActiveSpecivication : ISpecification<Product>
{
    public bool IsSatisfied(Product item)
    {
        return item.IsActive;
    }
}

public class AndSpecification<T> : ISpecification<T>
{
    private ISpecification<T> _spec1;
    private ISpecification<T> _spec2;

    public AndSpecification(ISpecification<T> spec1, ISpecification<T> spec2)
    {
        _spec1 = spec1;
        _spec2 = spec2;
    }

    public bool IsSatisfied(T item)
    {
        return _spec1.IsSatisfied(item) && _spec2.IsSatisfied(item);
    }
}


public class ProductRepository
{
    private List<Product> _products;
    public ProductRepository()
    {
        _products = new List<Product>()
        {
            new Product { Stock = 10, IsActive = true },
            new Product { Stock = 0, IsActive = true },
            new Product { Stock = 5, IsActive = false }
        };
    }

    public IEnumerable<Product> Find(ISpecification<Product> specification)
    {
        return _products.Where(p=> specification.IsSatisfied(p));
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var productRepo = new ProductRepository();

        var activeSpec = new ProductIsActiveSpecivication();
        var inStockSpec = new ProductIsInStockSpecification();

        var activeAndInStockSpec = new AndSpecification<Product>(activeSpec,inStockSpec);

        var products = productRepo.Find(activeAndInStockSpec);

        foreach (var item in products)
        {
            Console.WriteLine($"Stock: {item.Stock}, IsActive: {item.IsActive}");
        }
    }
}