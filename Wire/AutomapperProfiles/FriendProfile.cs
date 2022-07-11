using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wire.Models;
using Wire.Models.Dtos;

namespace Wire.AutomapperProfiles
{
    public class FriendProfile : Profile
    {
        public FriendProfile()
        {
            CreateMap<UserChat, FriendDto>()
                .ForMember(dest => dest.Friend, opt => opt.MapFrom(src => src.AppUser));

            CreateMap<FriendDto, string>()
                .ConstructUsing(src => src.Friend.UserName);
        }
    }
}
