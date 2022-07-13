using NetElites.Application.Dto.User;
using NetElites.Domain.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetElites.Application.Repository
{
    public interface IUserRepository
    {
        Task<UserDto> login(UserDto userDto);
        Task<UserDto> registerUser(string mobileNumber);
        Task<SmsCode> getCode(string mobileNumber);
        Task<UserDto> findUserWithPhonenumber(string mobileNumber);
        Task<bool> logout(string userId);
        Task<UserDto> getUser(string userId);
    }
}
