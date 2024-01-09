namespace CodeFirst.Model;

public class Category
{
    public byte CategoryId { get; set; }
    public string Name { get; set; } = null!;
    public DateTime LastUpdate { get; set; }
    public ICollection<Product> Products { get; set; } = new List<Product>();
    public override string ToString() => $"{Name}";
}

