using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wire.Models
{
    public class ChatType
    {
        public ChatType()
        {
            Chats = new HashSet<Chat>();
        }

        public int ChatTypeId { get; set; }
        public string ChatName { get; set; }

        public virtual ICollection<Chat> Chats { get; set; }
    }
}
