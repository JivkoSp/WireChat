using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wire.Data.Repository.Generic;
using Wire.Models;

namespace Wire.Data.Repository.Interfaces
{
    public interface IFriendRepo : IGenericRepo<Friend>
    {
        bool isFriend(string senderId, string receiverId);
        IEnumerable<Friend> GetFriends(string userId);
        IEnumerable<Friend> GetFriendContact(string senderId, string receiverId);
        IEnumerable<AppUser> GetOnlineFriends(ICollection<AppUser> appUsers, string userId);
    }
}
