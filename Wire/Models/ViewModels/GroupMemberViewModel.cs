﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wire.Models.ViewModels
{
    public class GroupMemberViewModel
    {
       public IEnumerable <UserChat> Members { get; set; }
    }
}
