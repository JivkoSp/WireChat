using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wire.Models.ViewModels
{
    public class UserProfileViewModel
    {
        public AppUser AppUser { get; set; }
        public IEnumerable<ProfilePicture> ProfilePictures { get; set; }
    }
}
