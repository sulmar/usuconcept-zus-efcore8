namespace CodeFirst.Model;

public class Order
{
    public int OrderId { get; set; }
    public string Number { get; set; }
    public DateTime OrderDate { get; set; }

    // Shadow Property
    // public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public ICollection<OrderDetail> Details { get; set; }
    public override string ToString() => $"#{Number} ordered on {OrderDate} by {Customer}";
}

