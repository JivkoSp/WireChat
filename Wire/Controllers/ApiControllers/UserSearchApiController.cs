using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wire.Data.Repository.UnitOfWork;

namespace Wire.Controllers.ApiControllers
{
    [ApiController]
    [Route("/api/userSearch")]
    public class UserSearchApiController : ControllerBase
    {
        private IUnitOfWork UnitOfWork;

        public UserSearchApiController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
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
    }
}
