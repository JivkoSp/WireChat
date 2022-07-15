using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wire.Models.Dtos
{
    public class BannMemberDto
    {
        public int BannMemberId { get; set; }
        public string AppUserId { get; set; }
        public string IssuedById { get; set; }
        public string BannType { get; set; }
    }
}
