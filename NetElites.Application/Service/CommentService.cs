using AutoMapper;
using NetElites.Domain.Model;
using NetElitres.Application.Dto.Comment;
using NetElitres.Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetElitres.Application.Service
{
    public class CommentService : ICommentRepository
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CommentService(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task Add(CommentDto commentDto)
        {
            var comment = _mapper.Map<Comment>(commentDto);
            await _context.comments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var comment = await FindComment(id);
            if (comment != null)
            {
                _context.comments.Remove(comment);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<Comment> FindComment(int id)
        {
            var comment = await _context.comments.FindAsync(id);
            return comment;
        }

        public async Task<bool> Update(int id, CommentDto commentDto)
        {
            var comment = await FindComment(id);
            if (comment != null)
            {
                var commentModel = _mapper.Map(commentDto, comment);
                _context.comments.Update(commentModel);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
