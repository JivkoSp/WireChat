using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wire.Models
{
    public class ChatType
    {
        public int ChatTypeId { get; set; }
        public string ChatName { get; set; }

        public virtual Chat Chat { get; set; }
    }
}
