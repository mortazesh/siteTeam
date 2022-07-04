using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetElites.Application.Repository
{
    public interface ITokenValidator
    {
        Task Execute(TokenValidatedContext context);
    }
}
