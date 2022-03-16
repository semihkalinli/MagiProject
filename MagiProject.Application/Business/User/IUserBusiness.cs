using MagiProject.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagiProject.Application.Business.User
{
    public interface IUserBusiness
    {
        Task<List<UserResponseDto>> GetUserList();
    }
}
