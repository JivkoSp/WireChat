using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wire.Models.Dtos
{
    public class EditGroupMemberDto
    {
       public string MemberId { get; set; }
       public int ChatId { get; set; }
       public string RoleName { get; set; }
       public bool Kick { get; set; }
    }
}
