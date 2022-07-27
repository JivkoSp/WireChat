﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wire.Data.Repository.Generic;
using Wire.Models;

namespace Wire.Data.Repository.Interfaces
{
    public interface IProfilePictureRepo : IGenericRepo<ProfilePicture>
    {
        IEnumerable<ProfilePicture> GetProfilePictures();
    }
}