using NetElites.Application.Dto.User;
using NetElites.Application.Repository;
using NetElitres.Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using NetElites.Comman.Helper;
using NetElites.Domain.Model.Users;

namespace NetElites.Application.Service
{
    public class UserServices: IUserRepository
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public UserServices(IApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDto> findUserWithPhonenumber(string mobileNumber)
        {
            var user = await _context.users.SingleOrDefaultAsync(u => u.PhoneNumber == mobileNumber);
            if (user != null)
            {
                var userDto = _mapper.Map<UserDto>(user);
                return userDto;
            }
            return null;
        }

        public async Task<SmsCode> getCode(string mobileNumber)
        {
            var smsCode = GenricCode.smsCode();
            SmsCode sms = new SmsCode()
            {
                Code = smsCode,
                MobileNumber = mobileNumber,
            };
            await _context.smsCodes.AddAsync(sms);
            await _context.SaveChangesAsync();
            return sms;
        }

        public async Task<UserDto> getUser(string userId)
        {
            var user = await _context.users.SingleOrDefaultAsync(u => u.Id == userId);
            if (user != null)
            {
                var userDto = _mapper.Map<UserDto>(user);
            }
            return null;
        }

        public async Task<UserDto> login(UserDto userDto)
        {
            var smsCode = await _context.smsCodes.Where(s => s.MobileNumber == userDto.mobileNumber && s.Code == userDto.code)
                .FirstOrDefaultAsync();
            if (smsCode != null)
            {
                if (smsCode.Used == true)
                {
                    return null;
                }
                else
                {
                    smsCode.RequertCount++; 
                    var user = await findUserWithPhonenumber(smsCode.MobileNumber);
                    if (user != null)
                    {
                        return user;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            return null;
        }

        public async Task<bool> logout(string userId)
        {
            var token = await _context.tokens.Where(u => u.UserId == userId).ToListAsync();
            if (token != null)
            {
                _context.tokens.RemoveRange(token);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<UserDto> registerUser(string mobileNumber)
        {
            var user = await findUserWithPhonenumber(mobileNumber);
            if (user == null)
            {
                User newUser = new User
                {
                    Id = GenricCode.code(),
                    PhoneNumber = user.mobileNumber,
                    IsActive = true
                }; 
                await _context.users.AddAsync(newUser);
                await _context.SaveChangesAsync();
                var userDto = _mapper.Map<UserDto>(user);
                return userDto;
            }
            return null;
        }
    }
}
