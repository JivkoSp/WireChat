﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wire.Data.Repository.Generic;
using Wire.Models;

namespace Wire.Data.Repository.Interfaces
{
    public interface IPendingRequestRepo : IGenericRepo<PendingRequest>
    {
        IEnumerable<PendingRequest> GetPendingRequests(string userId);
        bool HavePendingRequest(string senderId, string receiverId);
    }
}
