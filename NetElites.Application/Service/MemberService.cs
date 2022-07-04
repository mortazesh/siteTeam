using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetElites.Domain.Model.Members;
using NetElitres.Application.Dto.Member;
using NetElitres.Application.Dto.Seo;
using NetElitres.Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetElitres.Application.Service
{
    public class MemberService: IMemberRespoitory
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public MemberService(IApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task Add(AddMemberDto memberDto)
        {
            var member = _mapper.Map<Member>(memberDto);
            await _context.members.AddAsync(member);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var member = await FindMember(id);
            if (member != null)
            {
                _context.members.Remove(member);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Member> FindMember(int id)
        {
            var member = await _context.members.FindAsync(id);
            return member;
        }

        public async Task<IEnumerable<MemberDto>> GetAllMember()
        {
            var members = await _context.members
                .Select(member => new MemberDto
                {
                    UrlImage = member.UrlImage,
                    Name = member.Name,
                    Level = member.Level
                })
                .ToListAsync();
            return members;
        }

        public async Task<MemberDto> GetMemberById(int id)
        {
            var member = await _context.members.
                Where(a => a.Id == id).
                Include(a => a.Seo).
                FirstOrDefaultAsync();
            return new MemberDto
            {
                Created = member.Created,
                Description = member.Description,
                Level = member.Level,
                Name = member.Name,
                UrlImage = member.UrlImage,
                seo = new SeoDto
                {
                    Description = member.Seo.Description,
                    Title = member.Seo.Title,
                    Created = member.Seo.Created,
                }
            };
        }

        public async Task<bool> Update(int id, MemberDto memberDto)
        {
            var member = await FindMember(id);
            if (member != null)
            {
                var memberModel = _mapper.Map(memberDto, member);
                _context.members.Update(memberModel);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
