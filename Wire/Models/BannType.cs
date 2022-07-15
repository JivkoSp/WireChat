using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wire.Models
{
    public class BannType
    {
        public BannType()
        {
            BannMembers = new HashSet<BannMember>();
        }

        public int BannTypeId { get; set; }
        public string Type { get; set; }

        public virtual ICollection<BannMember> BannMembers { get; set; }
    }
}
