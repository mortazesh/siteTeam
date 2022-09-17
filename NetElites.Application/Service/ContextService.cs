using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetElites.Application.Dto.Context;
using NetElites.Application.Repository;
using NetElites.Doamin.Model.Context;
using NetElitres.Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetElites.Application.Service
{
    public class ContextService : IContextRepository
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ContextService(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task Add(AddContextDto contextDto)
        {
            var context = _mapper.Map<Context>(contextDto);
            await _context.contexts.AddAsync(context);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Task<ContextDto>>> GetAll()
        {
            var contexts = await _context.contexts
                .Select(context => new ContextDto
                {
                    id = context.Id,
                    application = context.Application,
                    mobileNumber = context.MobileNumber,
                    name = context.Name
                })
                .ToListAsync();
            return (IEnumerable<Task<ContextDto>>)contexts;
        }

        public async Task<ContextDto> GetContextById(int id)
        {
            var context = await _context.contexts
                .SingleOrDefaultAsync(c => c.Id == id);
            if (context != null)
            {
                var contextDto = _mapper.Map<ContextDto>(context);
                return contextDto;
            }
            return null;
        }
    }
}
