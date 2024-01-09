namespace CodeFirst.Model;

public class Product
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string Barcode { get; set; }
    public ProductSize? Size { get; set; }
    public string? Color { get; set; }
    public decimal Price { get; set; }
    public ICollection<Category> Categories { get; set; } = new List<Category>();
    public override string ToString() => $"{Name} {Description} {Barcode} {Price:C2}";
}

