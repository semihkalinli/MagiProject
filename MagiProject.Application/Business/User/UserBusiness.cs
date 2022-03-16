using MagiProject.Data.Abstract;
using MagiProject.Domain.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagiProject.Application.Business.User
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserBusiness(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<UserResponseDto>> GetUserList()
        {
            List<UserResponseDto> _userList = new List<UserResponseDto>();
            var response = await _unitOfWork.UserRepository.GetAllAsync();
            // AutoMapper kullanarak daha az kod ile mapleme işlemi yapılabilir.
            foreach (var user in response)
                _userList.Add(
                         new UserResponseDto
                        {
                            Id = user.Id,
                            FullName = user.FullName,
                            CityName = user.CityName
                        }
                    );
            return _userList;
        }
    }
}
