using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wire.Models.ViewModels
{
    public class ActiveChatViewModel
    {
        public IEnumerable<ActiveChat> ActiveChats { get; set; }
        public IEnumerable<Group> Groups { get; set; }
    }
}
