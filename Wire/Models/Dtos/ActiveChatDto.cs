using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wire.Models.Dtos
{
    public class ActiveChatDto
    {
        public int ChatId { get; set; }
        public DateTime DateTime { get; set; }
        public string ChatName { get; set; }
    }
}
