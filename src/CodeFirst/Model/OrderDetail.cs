namespace CodeFirst.Model;

public class OrderDetail
{
    public int OrderDetailId { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public decimal Amount { get; set; }

    public override string ToString() => $"{Product} {Quantity} {Amount:C2}";
}

