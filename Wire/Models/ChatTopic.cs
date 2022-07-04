using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wire.Models
{
    public class ChatTopic
    {
        public int ChatTopicId { get; set; }
        public string TopicName { get; set; }

        public int ChatId { get; set; }
        public virtual Chat Chat { get; set; }
    }
}
