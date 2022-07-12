using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wire.Data.Repository.UnitOfWork;
using Wire.Models;
using Wire.Models.Dtos;

namespace Wire.Controllers.ApiControllers
{
    [ApiController]
    [Route("/api/userSearch")]
    public class UserSearchApiController : ControllerBase
    {
        private IUnitOfWork UnitOfWork;
        private IMapper Mapper;

        public UserSearchApiController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        [Produces("application/json")]
        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            try
            {
                string SearchTerm = HttpContext.Request.Query["term"];
                var response = UnitOfWork.UserRepo.GetUsersByName(SearchTerm);

                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }         
        }

        [Produces("application/json")]
        [HttpGet("friends")]
        public IActionResult GetFriends(string userId)
        {
            try
            {
                string SearchTerm = HttpContext.Request.Query["term"];

                var response = UnitOfWork.UserChatRepo.GetContactFriends(userId);
                List<FriendDto> friendDtos = Mapper.Map<List<FriendDto>>(response);
                List<string> friendNames = Mapper.Map<List<string>>(friendDtos);

                return Ok(friendNames);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
