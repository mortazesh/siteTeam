using NetElites.Domain.Model.Members;
using NetElitres.Application.Dto.Member;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetElitres.Application.Repository
{
    public interface IMemberRespoitory
    {
        Task<MemberDto> GetMemberById(int id);
        Task<IEnumerable<MemberDto>> GetAllMember();
        Task Add(AddMemberDto memberDto);
        Task<Member> FindMember(int id);
        Task<bool> Update(int id, MemberDto memberDto);
        Task<bool> Delete(int id);
    }
}
