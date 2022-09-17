using NetElites.Application.Dto.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetElites.Application.Repository
{
    public interface IContextRepository
    {
        Task<ContextDto> GetContextById(int id);
        Task<IEnumerable<Task<ContextDto>>> GetAll();
        Task Add(AddContextDto contextDto); 
    }
}
