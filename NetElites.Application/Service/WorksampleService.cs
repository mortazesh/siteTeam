using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
                .Select(worksample => new WorksampleDto
                {
                    Title = worksample.Title,
                    //type
                    Description = worksample.Description,
                })
                .ToListAsync();
            return worksample;
        }

        public WorksampleDto GetWorksample()
        {
            var worksample = _context.worksamples
                .Take(4)
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
            var worksample = await _context.articles.
                Where(a => a.Id == id).
                Include(a => a.Comments).
                Include(a => a.Seo).
                FirstOrDefaultAsync();
            return new WorksampleDto
            {
                Created = worksample.Created,
                Description = worksample.Description,
                // type
                Title = worksample.Title,
                UriImage = worksample.UrlImage,
                comment = worksample.Comments.Select(comment => new CommentDto
                {
                    Created = comment.Created,
                    Description = comment.Description,
                    FullName = comment.FullName,
                }).ToList(),
                seo = new SeoDto
                {
                    Description = worksample.Seo.Description,
                    Title = worksample.Seo.Title,
                    Created = worksample.Seo.Created,
                }
            };
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
