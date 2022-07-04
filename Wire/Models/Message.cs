using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wire.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public string Content { get; set; }
        public DateTime DateTime { get; set; }

        public int ChatId { get; set; }
        public virtual Chat Chat { get; set; }
    }
}
