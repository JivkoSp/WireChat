using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wire.Models
{
    public class Chat
    {

        public Chat()
        {
            UserChats = new HashSet<UserChat>();
            Messages = new HashSet<Message>();
        }

        public int ChatId { get; set; }
        public int ChatTypeId { get; set; }

        public virtual ChatType ChatType { get; set; }
        public virtual ChatTopic ChatTopic { get; set; }
        public virtual Group Group { get; set; }
        public virtual ICollection<UserChat> UserChats { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
