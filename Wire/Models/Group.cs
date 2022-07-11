using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wire.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }

        public int GroupTypeId { get; set; }
        public virtual GroupType GroupType { get; set; }

        public int ChatId { get; set; }
        public virtual Chat Chat { get; set; }
    }
}
