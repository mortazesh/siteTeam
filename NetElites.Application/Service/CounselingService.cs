using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetElites.Application.Dto.Counseling;
using NetElites.Application.Repository;
using NetElites.Doamin.Model.Counseling;
using NetElitres.Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetElites.Application.Service
{
    public class CounselingService : ICounselingRepository
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CounselingService(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task Add(AddCounslingDto counslingDto)
        {
            var counsling = _mapper.Map<Counseling>(counslingDto);
            await _context.counselings.AddAsync(counsling);
            await _context.SaveChangesAsync();
        }

        public async Task<CounselingDto> Get(int id)
        {
            var counsling = await _context.counselings
                .SingleOrDefaultAsync(counsling => counsling.Id == id);
            if (counsling != null)
            {
                var counslingDto = _mapper.Map<CounselingDto>(counsling);
                return counslingDto;
            }
            return null;
        }

        public async Task<IEnumerable<CounselingDto>> GetAll()
        {
            var counseling = await _context.counselings
                .Select(counseling => new CounselingDto
                {
                    id = counseling.Id,
                    application = counseling.Application,
                    mobileNumber = counseling.MobileNumber,
                    name = counseling.Name,
                    type = counseling.Type
                })
                .ToListAsync();
            return counseling;
        }
    }
}
