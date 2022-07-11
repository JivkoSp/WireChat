using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wire.Models.Dtos;

namespace Wire.Models.ViewModels
{
    public class GroupViewModel
    {
        public IEnumerable<GroupDto> GroupDtos { get; set; }
        public IEnumerable<GroupType> GroupTypes { get; set; }
    }
}
