using NetElites.Application.Dto.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetElites.Application.Repository
{
    public interface ITokenRepositry
    {
        Task Add(string userId);
        Task<bool> Remove(string refershToken);
        Task<TokenDto> Save(AddTokenDto tokenDt);
        Task<TokenDto> findRefershToken(string refershToken);
        Task<bool> checkExistToken(string token);

    }
}
