using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wire.Models.ViewModels
{
    public class EditMemberViewModel
    {
        public int ChatId { get; set; }
        public AppUser AppUser { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}
