using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wire.Models
{
    public class ProfilePicture
    {
        public ProfilePicture()
        {
            AppUsers = new HashSet<AppUser>();
        }

        public int ProfilePictureId { get; set; }
        public byte[] Picture { get; set; }

        public virtual ICollection<AppUser> AppUsers { get; set; }
    }
}
