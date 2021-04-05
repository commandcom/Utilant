using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UtilantInterviewTest.Models
{
    public record Address
        (
            string Street,
            string Suite,
            string City,
            string ZipCode,
            Dictionary<string, string> Geo
        );
    
}
