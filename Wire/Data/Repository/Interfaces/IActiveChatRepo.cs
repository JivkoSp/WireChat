using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wire.Data.Repository.Generic;
using Wire.Models;

namespace Wire.Data.Repository.Interfaces
{
    public interface IActiveChatRepo : IGenericRepo<ActiveChat>
    {
        IEnumerable<ActiveChat> GetActiveChats(string userId);
        IEnumerable<ActiveChat> GetGroupActiveChats(string userId);
    }
}
