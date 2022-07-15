using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wire.Models.Dtos
{
    public class MessageProfileDto
    {
        public string UserId { get; set; }
        public int MessageTimeToLife { get; set; }
        public bool DontRemember { get; set; }
    }
}
