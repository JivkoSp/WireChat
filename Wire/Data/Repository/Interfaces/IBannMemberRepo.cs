using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wire.Data.Repository.Generic;
using Wire.Models;

namespace Wire.Data.Repository.Interfaces
{
    public interface IBannMemberRepo : IGenericRepo<BannMember>
    {
        bool isUserBannedFromGroup(int chadId, string userId);
        bool isUserBannedFromContact(string userId, string issuerId);
        IEnumerable<BannMember> GetBannMembers(string userId);
    } 
}
