using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wire.Data.Repository.Generic;
using Wire.Data.Repository.Interfaces;
using Wire.Models;

namespace Wire.Data.Repository.Repositories
{
    public class ProfilePictureRepo : GenericRepo<ProfilePicture>, IProfilePictureRepo
    {
        private WireChatDbContext WireChatDbContext => Context as WireChatDbContext;

        public ProfilePictureRepo(WireChatDbContext dbContext):base(dbContext)
        {
        }

        public IEnumerable<ProfilePicture> GetProfilePictures()
        {
            return WireChatDbContext.ProfilePictures;
        }
    }
}
