using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wire.Data.Repository.Generic;
using Wire.Data.Repository.Interfaces;
using Wire.Models;

namespace Wire.Data.Repository.Repositories
{
    public class FriendRepo : GenericRepo<Friend>, IFriendRepo
    {
        public FriendRepo(WireChatDbContext dbContext):base(dbContext)
        {
        }
    }
}
