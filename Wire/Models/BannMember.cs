using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wire.Models
{
    public class BannMember
    {
        public int BannMemberId { get; set; }
        public int ChatId { get; set; }
        public string AppUserId { get; set; }
        public int BannTypeId { get; set; }
        public string IssuedById { get; set; }
        public virtual AppUser AppUser { get; set; }
        public virtual BannType BannType { get; set; }
    }
}
