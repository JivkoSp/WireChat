using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wire.Models
{
    public class MessageTimeToLive
    {
        public string AppUserId { get; set; }
        public int LifeSpan { get; set; }

        public virtual AppUser AppUser { get; set; }
    }
}
