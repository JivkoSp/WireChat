using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wire.Data.Repository.UnitOfWork;
using Wire.Models.ViewModels;

namespace Wire.Components
{
    public class GroupMembersViewComponent : ViewComponent
    {
        private IUnitOfWork UnitOfWork;

        public GroupMembersViewComponent(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IViewComponentResult Invoke(int ChatId)
        {
            return View
                (
                    new GroupMemberViewModel
                    { 
                       Members = UnitOfWork.GroupRepo.GetGroupMembers(ChatId)
                    }
                );
        }
    }
}
