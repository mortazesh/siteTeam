using NetElites.Domain.Model;
using NetElitres.Application.Dto.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetElitres.Application.Repository
{
    public interface ICommentRepository
    {
        Task Add(CommentDto commentDto);
        Task<Comment> FindComment(int id);
        Task<bool> Update(int id, CommentDto commentDto);
        Task<bool> Delete(int id);
    }
}
