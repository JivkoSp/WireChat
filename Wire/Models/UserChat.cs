using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wire.Models
{
    public class UserChat
    {
        public string AppUserId { get; set; }
        public int ChatId { get; set; }
        public string ChatType { get; set; }
        public DateTime JoinDate { get; set; }
        public virtual AppUser AppUser { get; set; }
        public virtual Chat Chat { get; set; }
    }
}
