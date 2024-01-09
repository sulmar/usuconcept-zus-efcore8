using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawSQL;

internal class CustomerInfo
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}


public record ActorDTO(string firstname, string lastname);