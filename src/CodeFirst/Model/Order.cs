namespace CodeFirst.Model;

public class Order
{
    public int OrderId { get; set; }
    public string Number { get; set; }
    public DateTime OrderDate { get; set; }

    // Shadow Property  // właściwość, która nie jest w modelu
    // public int CustomerId { get; set; }
    public Customer Customer { get; set; } // Navigation Property
    public ICollection<OrderDetail> Details { get; set; } // Navigation Property
    public override string ToString() => $"#{Number} ordered on {OrderDate} by {Customer}";
}

