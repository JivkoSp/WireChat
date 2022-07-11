using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wire.Models.ViewModels
{
    public class ChatRoomViewModel
    {
        public string RoomType { get; set; }
        public List<Message> Messages { get; set; }
    }
}
