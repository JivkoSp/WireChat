using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wire.Models.ViewModels
{
    public class GroupSideMenuViewModel
    {
        public string UserId { get; set; }
        public IEnumerable<ChatTopic> ChatTopics { get; set; }
        public List<UserChat> Contacts { get; set; }
    }
}
