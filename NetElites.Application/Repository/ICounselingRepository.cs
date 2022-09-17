using NetElites.Application.Dto.Counseling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetElites.Application.Repository
{
    public interface ICounselingRepository
    {
        Task<IEnumerable<CounselingDto>> GetAll();
        Task<CounselingDto> Get(int id);
        Task Add(AddCounslingDto counslingDto);
    }
}
