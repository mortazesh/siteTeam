using NetElites.Domain.Model;
using NetElitres.Application.Dto.Seo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetElitres.Application.Repository
{
    public interface ISeoRepository
    {
        Task Add(SeoDto seoDto);
        Task<Seo> FindSeo(int id);
        Task<bool> Update(int id, SeoDto seoDto);
        Task<bool> Delete(int id);
    }
}
