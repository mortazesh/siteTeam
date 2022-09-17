using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetElites.Application.Dto.Tag;
using NetElites.Application.Dto.UsedWorksample;
using NetElites.Domain.Model.Worksamples;
using NetElitres.Application.Dto.Comment;
using NetElitres.Application.Dto.Seo;
using NetElitres.Application.Dto.Worksample;
using NetElitres.Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetElitres.Application.Service
{
    public class WorksampleService : IWorksampleRepository
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public WorksampleService(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task Add(AddWorksampleDto worksampleDto)
        {
            var wrksample = _mapper.Map<Worksample>(worksampleDto);
            await _context.worksamples.AddAsync(wrksample);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var worksample = await FindWorksample(id);
            if (worksample != null)
            {
                _context.worksamples.Remove(worksample);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Worksample> FindWorksample(int id)
        {
            var worksamples = await _context.worksamples.FindAsync(id);
            return worksamples;
        }

        public async Task<IEnumerable<WorksampleDto>> GetAllWorksample()
        {
            var worksample = await _context.worksamples
                .Include(worksample => worksample.UsedWorksamples)
                .Select(worksample => new WorksampleDto
                {
                    Id = worksample.Id,
                    Title = worksample.Title,
                    Description = worksample.Description,
                    usedWorksamples = worksample.UsedWorksamples.Select(u => new UsedWorksampleDto
                    {
                        name = u.Name
                    }).ToList()
                })
                .ToListAsync();
            return worksample;
        }

        public WorksampleDto GetWorksample()
        {
            var worksample = _context.worksamples
                .Take(8)
                .ToList();
            if (worksample == null)
            {
                var worksampleDto = _mapper.Map<WorksampleDto>(worksample);
                return worksampleDto;
            }
            return null;
        }

        public async Task<WorksampleDto> GetWorksampleById(int id)
        {
            var worksample = await _context.worksamples.
                Where(a => a.Id == id).
                Include(w => w.UsedWorksamples).
                Include(w => w.Seo).
                Include(w => w.Tags).
                FirstOrDefaultAsync();
            if (worksample != null)
            {
                return new WorksampleDto
                {
                    Created = worksample.Created,
                    Description = worksample.Description,
                    Title = worksample.Title,
                    UriImage = worksample.UriImage,
                    AltImage = worksample.AltImage,
                    TitleImage = worksample.TitleImage,
                    tags = worksample.Tags.Select(t => new TagDto
                    {
                        name = t.Name
                    }).ToList(),
                    usedWorksamples = worksample.Tags.Select(u => new UsedWorksampleDto
                    {
                        name = u.Name
                    }).ToList(),
                    seo = new SeoDto
                    {
                        Description = worksample.Seo.Description,
                        Title = worksample.Seo.Title,
                        Created = worksample.Seo.Created,
                    }
                };
            }
            return null;
        }

        public async Task<bool> Update(int id, WorksampleDto worksampleDto)
        {
            var worksample = await FindWorksample(id);
            if (worksample != null)
            {
                var worksampleModel = _mapper.Map(worksampleDto, worksample);
                _context.worksamples.Update(worksampleModel);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
