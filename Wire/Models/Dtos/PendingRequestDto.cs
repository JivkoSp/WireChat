using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wire.Models.Dtos
{
    public class PendingRequestDto
    {
        public int PendingRequestId { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string ChatType { get; set; }
        public string SenderName { get; set; }
        public string Action { get; set; }
    }
}
