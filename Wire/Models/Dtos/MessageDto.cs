using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wire.Models.Dtos
{
    public class MessageDto
    {
       public string Publisher { get; set; }
       public string Message { get; set; }
       public string DateTime { get; set; }
    }
}
