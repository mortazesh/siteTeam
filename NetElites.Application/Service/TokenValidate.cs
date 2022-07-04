using Microsoft.AspNetCore.Authentication.JwtBearer;
using NetElites.Application.Repository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NetElites.Application.Service
{
    public class TokenValidate : ITokenValidator
    {
        private readonly IUserRepository _user;
        private readonly ITokenRepositry _token;
        public TokenValidate(IUserRepository user, ITokenRepositry token)
        {
            _user = user;
            _token = token;
        }
        public async Task Execute(TokenValidatedContext context)
        {
            var claimsidentity = context.Principal.Identity as ClaimsIdentity;
            if (claimsidentity?.Claims == null || !claimsidentity.Claims.Any())
            {
                context.Fail("claims not found....");
            }

            var userId = claimsidentity.FindFirst("UserId").Value;
            if (!Guid.TryParse(userId, out Guid userGuid))
            {
                context.Fail("claims not found....");
            }

            if (!(context.SecurityToken is JwtSecurityToken Token)
               || !(await _token.checkExistToken(Token.RawData)))
            {
                context.Fail("توکد در دیتابیس وجود ندارد");
            }
        }
    }
}
