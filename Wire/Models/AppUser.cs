using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wire.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            Friends = new HashSet<Friend>();
            PendingRequests = new HashSet<PendingRequest>();
            UserChats = new HashSet<UserChat>();
        }

        public virtual ICollection<Friend> Friends { get; set; }
        public virtual ICollection<PendingRequest> PendingRequests { get; set; }
        public virtual ICollection<UserChat> UserChats { get; set; }
    }
}
