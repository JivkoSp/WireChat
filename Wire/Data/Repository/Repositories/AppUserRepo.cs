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
    public class AppUserRepo : GenericRepo<AppUser>, IAppUserRepo
    {
        private WireChatDbContext WireChatDbContext => Context as WireChatDbContext;

        public AppUserRepo(WireChatDbContext dbContext):base(dbContext)
        {
        }

        public List<string> GetUsersByName(string searchTerm)
        {
            return WireChatDbContext.AppUsers.Where(u => u.UserName.Contains(searchTerm))
                    .Select(u => u.UserName).ToList();
        }
    }
}
