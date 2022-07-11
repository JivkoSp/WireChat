using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wire.Models.ViewModels
{
    public class SideMenuViewModel
    {
        public string RoomType { get; set; }
        public List<UserChat> Contacts { get; set; }
    }
}
