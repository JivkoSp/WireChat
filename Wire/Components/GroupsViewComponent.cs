using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wire.Data.Repository.UnitOfWork;
using Wire.Models;
using Wire.Models.Dtos;
using Wire.Models.ViewModels;

namespace Wire.Components
{
    public class GroupsViewComponent : ViewComponent
    {
        private IUnitOfWork UnitOfWork;
        private IMapper Mapper;
        private UserManager<AppUser> UserManager;

        public GroupsViewComponent(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
            UserManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            GroupViewModel groupView = new GroupViewModel
            {
                GroupDtos = Mapper.Map<IEnumerable<GroupDto>>(
                    UnitOfWork.UserChatRepo.GetGroups(UserManager.GetUserId(UserClaimsPrincipal))),
                GroupTypes = UnitOfWork.GroupTypeRepo.GetGroupTypes()
            };

            return View(groupView);
        }
    }
}
