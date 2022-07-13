using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wire.Data.Repository.Generic;
using Wire.Models;

namespace Wire.Data.Repository.Interfaces
{
    public interface IGroupRepo : IGenericRepo<Group>
    {
        IEnumerable<UserChat> GetGroupMembers(int chatId);
    }
}
