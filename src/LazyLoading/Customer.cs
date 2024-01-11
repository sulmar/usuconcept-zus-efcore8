using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure;

public partial class Customer
{
    private readonly ILazyLoader _lazyLoader;

    private Address _address;
    public Address Address 
    {
        get => _lazyLoader.Load(this, ref _address);
        set => _address = value;
    } 

    public Customer() { }
    
    private Customer(ILazyLoader lazyLoader)
    {
        this._lazyLoader = lazyLoader;
    }

    public override string ToString() => $"{FirstName} {LastName} from {Address.City.City1}";
}
