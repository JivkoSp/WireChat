using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wire.Models
{
    public class PendingRequest
    {
        public int PendingRequestId { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string ChatType { get; set; }

        public virtual AppUser AppUser { get; set; }
    }
}
