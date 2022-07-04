using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wire.Models
{
    public class Friend
    {
        public int FriendId { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }

        public virtual AppUser AppUser { get; set; }
    }
}
