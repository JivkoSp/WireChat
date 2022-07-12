using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wire.ExtensionMethods;
using Wire.Models;
using Wire.Models.Dtos;

namespace Wire.AutomapperProfiles
{
    public class PendingRequestProfile : Profile
    {
        public PendingRequestProfile()
        {
            CreateMap<PendingRequest, PendingRequestDto>();
            CreateMap<PendingRequestDto, PendingRequest>();
        }
    }
}
