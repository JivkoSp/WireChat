using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wire.Models
{
    public class BannGroupMember
    {
        public int BannGroupMemberId { get; set; }
        public int ChatId { get; set; }
        public string AppUserId { get; set; }
        
        public virtual Chat Chat { get; set; }
    }
}
