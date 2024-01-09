namespace CodeFirst.Model;

public partial class Customer
{
    public int CustomerId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Email { get; set; }
    public decimal Debit { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? LastModifiedOn { get; set; }
    public bool IsRemoved { get; set; } = false;

    public override string ToString() => $"{FirstName} {LastName} <{Email}> {Debit:C2} created on {CreatedOn}";
}

