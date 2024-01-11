using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure;

public partial class Customer
{
    public override string ToString() => $"{FirstName} {LastName} is {Active}";
}
