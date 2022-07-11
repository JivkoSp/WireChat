using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wire.Models
{
    public class GroupType
    {
        public GroupType()
        {
            Groups = new HashSet<Group>();
        }

        public int GroupTypeId { get; set; }
        public string GroupTypeName { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}
