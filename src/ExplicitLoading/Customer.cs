namespace Infrastructure;

public partial class Customer
{
    public override string ToString() => $"{FirstName} {LastName} from {Address.City.City1}";
}
