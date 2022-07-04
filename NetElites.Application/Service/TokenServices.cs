using NetElites.Application.Dto.Token;
using NetElites.Comman.Helper;
using NetElitres.Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using NetElites.Domain.Model.Users;
using AutoMapper;

namespace NetElites.Application.Repository
{
    public class TokenServices : ITokenRepositry
    {
        private readonly IApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public TokenServices(IApplicationDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
        }
        public async Task Add(string userId)
        {
            var claims = new List<Claim>
            {
                new Claim("userId",userId),
                new Claim("role","")
            };
            var key = _configuration["JWtConfig:key"];
            var securtiy = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securtiy, SecurityAlgorithms.HmacSha256);
            var tokenExp = DateTime.Now.AddDays(int.Parse(_configuration["JWtConfig:expires"]));
            var token = new JwtSecurityToken
            (
                issuer: _configuration["JWtConfig:key"],
                audience: _configuration["JWtConfig:audience"],
                claims = claims,
                notBefore: DateTime.Now,
                expires: tokenExp,
                signingCredentials: credentials
            );
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            var refreshToken = GenricCode.code();
            var jwt = await Save(new AddTokenDto
            {
                refreshTokenHash = refreshToken,
                tokenHash = refreshToken,
                userId = userId,
            });
        }

        public async Task<bool> checkExistToken(string token)
        {
            string tokenHash = SecurityHelper.Getsha256Hash(token);
            var userToken = await _context.tokens.Where(t => t.HashToken == tokenHash)
                .FirstOrDefaultAsync();
            return userToken != null ? true : false;
        }

        public async Task<TokenDto> findRefershToken(string refershToken)
        {
            var token = await _context.tokens
                .SingleOrDefaultAsync(t => t.RefreshToken == refershToken);
            var tokenDto = _mapper.Map<TokenDto>(token);
            return token != null ? tokenDto : null;   
        }

        public async Task<bool> Remove(string refershToken)
        {
            var tokenDto = await findRefershToken(refershToken);
            var token = _mapper.Map<Token>(tokenDto);
            if (token != null)
            {
                _context.tokens.Remove(token);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<TokenDto> Save(AddTokenDto tokenDto)
        {
            var token = _mapper.Map<Token>(tokenDto);
            await _context.tokens.AddAsync(token);
            await _context.SaveChangesAsync();
            return new TokenDto
            {
                tokenHash = tokenDto.tokenHash,
                refreshTokenHash = tokenDto.refreshTokenHash,
            };
        }
    }
}
