using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wire.Models
{
    public class ActiveChat
    {
        public int ChatId { get; set; }
        public DateTime DateTime { get; set; }

        public virtual Chat Chat { get; set; }
    }
}
