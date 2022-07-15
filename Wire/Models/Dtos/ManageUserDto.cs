using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wire.Models.Dtos
{
    public class ManageUserDto
    {
        public bool TwoFaAuth { get; set; }
        public bool ChangePass { get; set; }
        public string TwoFaCode { get; set; }
        public string TwoFaType { get; set; }
        public bool RememberMe { get; set; }
    }
}
