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

        public int? ProfilePictureId { get; set; }

        public virtual MessageTimeToLive MessageTimeToLive { get; set; }
        public virtual AnonymUser AnonymUser { get; set; }
        public virtual ProfilePicture ProfilePicture { get; set; }
        public virtual ICollection<Friend> Friends { get; set; }
        public virtual ICollection<PendingRequest> PendingRequests { get; set; }
        public virtual ICollection<UserChat> UserChats { get; set; }
    }
}
