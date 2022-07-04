using AutoMapper;
using NetElites.Domain.Model;
using NetElitres.Application.Dto.Seo;
using NetElitres.Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetElitres.Application.Service
{
    public class SeoService : ISeoRepository
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public SeoService(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task Add(SeoDto seoDto)
        {
            var seo = _mapper.Map<Seo>(seoDto);
            await _context.seos.AddAsync(seo);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var seo = await FindSeo(id);
            if (seo != null)
            {
                _context.seos.Remove(seo);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Seo> FindSeo(int id)
        {
            var seo = await _context.seos.FindAsync(id);
            return seo;
        }

        public async Task<bool> Update(int id, SeoDto seoDto)
        {
            var seo = await FindSeo(id);
            if (seo != null)
            {
                var seoModel = _mapper.Map(seoDto,seo);
                _context.seos.Remove(seoModel);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
