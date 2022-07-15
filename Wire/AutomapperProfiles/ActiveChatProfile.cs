using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wire.Models;
using Wire.Models.Dtos;

namespace Wire.AutomapperProfiles
{
    public class ActiveChatProfile : Profile
    {
        public ActiveChatProfile()
        {
            CreateMap<ActiveChat, ActiveChatDto>()
                .ForMember(dest => dest.ChatName, opt => opt.MapFrom(src => src.Chat.Group.GroupName));
        }
    }
}
