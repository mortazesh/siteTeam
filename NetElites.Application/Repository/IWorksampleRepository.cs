using NetElites.Domain.Model.Worksamples;
using NetElitres.Application.Dto.Worksample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetElitres.Application.Repository
{
    public interface IWorksampleRepository
    {
        Task<WorksampleDto> GetWorksampleById(int id);
        Task<IEnumerable<WorksampleDto>> GetAllWorksample();
        Task Add(AddWorksampleDto worksampleDto);
        Task<Worksample> FindWorksample(int id);
        Task<bool> Update(int id, WorksampleDto worksampleDto);
        Task<bool> Delete(int id);
    }
}
