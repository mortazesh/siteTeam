using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetElites.Application.Dto.User;
using NetElites.Application.Repository;
using NetElites.Domain.Model.Users;
using NetElites.Infrastucture.Sms;
using NetElitres.Application.Dto.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetElites.EndPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserRepository _user;
        private readonly ITokenRepositry _token;
        private readonly UserManager<User> _userMnager;
        public AccountController(IUserRepository user, ITokenRepositry token, UserManager<User> userMnager)
        {
            _user = user;
            _token = token;
            _userMnager = userMnager;
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> login([FromBody] LoginDto model)
        {
            if (ModelState.IsValid)
            {
                var login = await _user.login(new UserDto
                {
                    mobileNumber = model.mobileNumber,
                    code = model.code
                });
                if (login != null)
                {
                        await _token.Add(login.id);
                        return Ok(new ResponseDto
                        {
                            IsSccees = true,
                            DisplayMessage = "عملیات با موفقیت انجام شد",
                            links = new List<LinksDto>
                            {
                                new LinksDto
                                {
                                    Href = "https://localhost:44397/api/Account/login",
                                    Method = "Post",
                                    Rel = "login"
                                },
                                new LinksDto
                                {
                                    Href = "https://localhost:44397/api/Account/refreshToken",
                                    Method = "Post",
                                    Rel = "refreshToken"
                                },
                                new LinksDto
                                {
                                    Href = "https://localhost:44397/api/Account/GetSmsCode",
                                    Method = "Get",
                                    Rel = "getSms"
                                },
                                new LinksDto
                                {
                                    Href = "https://localhost:44397/api/Account/LogOut",
                                    Method = "Get",
                                    Rel = "logout"
                                }
                            }
                        });
             }
                var user = await _user.findUserWithPhonenumber(model.mobileNumber);
                await _token.Add(user.id);
                return Ok(new ResponseDto
                {
                    IsSccees = true,
                    DisplayMessage = "عملیات با موفقیت انجام شد",
                    links = new List<LinksDto>
                            {
                                new LinksDto
                                {
                                    Href = "https://localhost:44397/api/Account/login",
                                    Method = "Post",
                                    Rel = "login"
                                },
                                new LinksDto
                                {
                                    Href = "https://localhost:44397/api/Account/refreshToken",
                                    Method = "Post",
                                    Rel = "refreshToken"
                                },
                                new LinksDto
                                {
                                    Href = "https://localhost:44397/api/Account/GetSmsCode",
                                    Method = "Get",
                                    Rel = "getSms"
                                },
                                new LinksDto
                                {
                                    Href = "https://localhost:44397/api/Account/LogOut",
                                    Method = "Get",
                                    Rel = "logout"
                                }
                            }
                });
            }
            return BadRequest(model);
        }
        [HttpPost]
        [Route("refreshToken")]
        public async Task<IActionResult> refreshToken(AddRefreshToken model)
        {
            var refreshToken = await _token.findRefershToken(model.refreshTokenHash);
            if (refreshToken.tokenHash == null)
            {
                return BadRequest(new ResponseDto
                {
                    IsSccees = false,
                    ErrorMessage = "عملیات با موفقیت انجام نشد",
                    links = new List<LinksDto>
                    {
                        new LinksDto
                                {
                                    Href = "https://localhost:44397/api/Account/login",
                                    Method = "Post",
                                    Rel = "login"
                                },
                                new LinksDto
                                {
                                    Href = "https://localhost:44397/api/Account/refreshToken",
                                    Method = "Post",
                                    Rel = "refreshToken"
                                },
                                new LinksDto
                                {
                                    Href = "https://localhost:44397/api/Account/GetSmsCode",
                                    Method = "Get",
                                    Rel = "getSms"
                                },
                                new LinksDto
                                {
                                    Href = "https://localhost:44397/api/Account/LogOut",
                                    Method = "Get",
                                    Rel = "logout"
                                }
                    }
                });
            }
            if (refreshToken.refreshTokenExp < DateTime.Now)
            {
                return Unauthorized(new ResponseDto
                {
                    IsSccees = false,
                    ErrorMessage = "مهلت استفاده از رفرش توکن تمام است،لطفا دوباره امتحان کنید",
                    links = new List<LinksDto>
                    {
                        new LinksDto
                                {
                                    Href = "https://localhost:44397/api/Account/login",
                                    Method = "Post",
                                    Rel = "login"
                                },
                                new LinksDto
                                {
                                    Href = "https://localhost:44397/api/Account/refreshToken",
                                    Method = "Post",
                                    Rel = "refreshToken"
                                },
                                new LinksDto
                                {
                                    Href = "https://localhost:44397/api/Account/GetSmsCode",
                                    Method = "Get",
                                    Rel = "getSms"
                                },
                                new LinksDto
                                {
                                    Href = "https://localhost:44397/api/Account/LogOut",
                                    Method = "Get",
                                    Rel = "logout"
                                }
                    }
                });
            }
            var user = await _userMnager.GetUserAsync(HttpContext.User);
            await _token.Add(user.Id);
            return Ok(new ResponseDto
            {
                IsSccees = true,
                DisplayMessage = "توکن با موفقیت رفرش شد",
                links = new List<LinksDto>
                {
                  new LinksDto
                                {
                                    Href = "https://localhost:44397/api/Account/login",
                                    Method = "Post",
                                    Rel = "login"
                                },
                                new LinksDto
                                {
                                    Href = "https://localhost:44397/api/Account/refreshToken",
                                    Method = "Post",
                                    Rel = "refreshToken"
                                },
                                new LinksDto
                                {
                                    Href = "https://localhost:44397/api/Account/GetSmsCode",
                                    Method = "Get",
                                    Rel = "getSms"
                                },
                                new LinksDto
                                {
                                    Href = "https://localhost:44397/api/Account/LogOut",
                                    Method = "Get",
                                    Rel = "logout"
                                }
                }
            });
        }
        [HttpGet]
        [Route("GetSmsCode")]
        public async Task<IActionResult> GetSmsCode(string mobileNumber)
        {
            var smsCode = await _user.getCode(mobileNumber);
            #region smsCode
            try
            {
                string message = $"{smsCode.code}";
                SmsService.Send(smsCode.mobileNumber, message);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto
                {
                    IsSccees = false,
                    ErrorMessage = ex.ToString(),
                    Result = smsCode.code,
                    links = new List<LinksDto>
                    {
                        new LinksDto
                                {
                                    Href = "https://localhost:44397/api/Account/login",
                                    Method = "Post",
                                    Rel = "login"
                                },
                                new LinksDto
                                {
                                    Href = "https://localhost:44397/api/Account/refreshToken",
                                    Method = "Post",
                                    Rel = "refreshToken"
                                },
                                new LinksDto
                                {
                                    Href = "https://localhost:44397/api/Account/GetSmsCode",
                                    Method = "Get",
                                    Rel = "getSms"
                                },
                                new LinksDto
                                {
                                    Href = "https://localhost:44397/api/Account/LogOut",
                                    Method = "Get",
                                    Rel = "logout"
                                }
                    }
                });
            }
            #endregion
            return Ok(new ResponseDto
            {
                IsSccees = true,
                DisplayMessage = "کد با موفقیت ارسال شد",
                Result = smsCode,
                links = new List<LinksDto>
                    {
                        new LinksDto
                                {
                                    Href = "https://localhost:44397/api/Account/login",
                                    Method = "Post",
                                    Rel = "login"
                                },
                                new LinksDto
                                {
                                    Href = "https://localhost:44397/api/Account/refreshToken",
                                    Method = "Post",
                                    Rel = "refreshToken"
                                },
                                new LinksDto
                                {
                                    Href = "https://localhost:44397/api/Account/GetSmsCode",
                                    Method = "Get",
                                    Rel = "getSms"
                                },
                                new LinksDto
                                {
                                    Href = "https://localhost:44397/api/Account/LogOut",
                                    Method = "Get",
                                    Rel = "logout"
                                }
                    }
            });
        }
        [HttpGet]
        [Route("LogOut")]
        public async Task<IActionResult> LogOut(string userId)
        {
            var user = await _user.getUser(userId);
            if (user != null)
            {
                var logout = await _user.logout(user.id);
                if (logout)
                {
                    return Ok(new ResponseDto
                    {
                        DisplayMessage = "عملیات با موفقیت انجام شد",
                        links = new List<LinksDto>
                        {
                           new LinksDto
                                {
                                    Href = "https://localhost:44397/api/Account/login",
                                    Method = "Post",
                                    Rel = "login"
                                },
                                new LinksDto
                                {
                                    Href = "https://localhost:44397/api/Account/refreshToken",
                                    Method = "Post",
                                    Rel = "refreshToken"
                                },
                                new LinksDto
                                {
                                    Href = "https://localhost:44397/api/Account/GetSmsCode",
                                    Method = "Get",
                                    Rel = "getSms"
                                },
                                new LinksDto
                                {
                                    Href = "https://localhost:44397/api/Account/LogOut",
                                    Method = "Get",
                                    Rel = "logout"
                                }
                        }
                    });
                }
                return BadRequest(new ResponseDto
                {
                    IsSccees = false,
                    ErrorMessage = "عمیلات با موفقیت انجا نشد",
                    links = new List<LinksDto>
                    {
                       new LinksDto
                                {
                                    Href = "https://localhost:44397/api/Account/login",
                                    Method = "Post",
                                    Rel = "login"
                                },
                                new LinksDto
                                {
                                    Href = "https://localhost:44397/api/Account/refreshToken",
                                    Method = "Post",
                                    Rel = "refreshToken"
                                },
                                new LinksDto
                                {
                                    Href = "https://localhost:44397/api/Account/GetSmsCode",
                                    Method = "Get",
                                    Rel = "getSms"
                                },
                                new LinksDto 
                                {
                                    Href = "https://localhost:44397/api/Account/LogOut",
                                    Method = "Get",
                                    Rel = "logout"
                                }
                    }
                });
            }
            return BadRequest(new ResponseDto
            {
                ErrorMessage = "عمیلات با موفقیت انجا نشد",
                IsSccees = false,
                links = new List<LinksDto>
                {
                    new LinksDto
                                {
                                    Href = "https://localhost:44397/api/Account/login",
                                    Method = "Post",
                                    Rel = "login"
                                },
                                new LinksDto
                                {
                                    Href = "https://localhost:44397/api/Account/refreshToken",
                                    Method = "Post",
                                    Rel = "refreshToken"
                                },
                                new LinksDto
                                {
                                    Href = "https://localhost:44397/api/Account/GetSmsCode",
                                    Method = "Get",
                                    Rel = "getSms"
                                },
                                new LinksDto
                                {
                                    Href = "https://localhost:44397/api/Account/LogOut",
                                    Method = "Get",
                                    Rel = "logout"
                                }
                }
            });
        }
    }
}
