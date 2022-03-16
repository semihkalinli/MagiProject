using MagiProject.Application.Business.User;
using MagiProject.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagiProject.Http.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;
        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [HttpGet("List")]
        public async Task<IEnumerable<UserResponseDto>> UserList()
        {
            return await _userBusiness.GetUserList();
        }
    }
}
