using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wire.Models
{
    public class GroupPendingRequest
    {
        public int PendingRequestId { get; set; }
        public int ChatId { get; set; }

        public virtual PendingRequest PendingRequest { get; set; }
        public virtual Chat Chat { get; set; }
    }
}
