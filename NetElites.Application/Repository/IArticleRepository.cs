using NetElites.Domain.Model.Articles;
using NetElitres.Application.Dto.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetElitres.Application.Repository
{
    public interface IArticleRepository
    {
        Task<ArticlesDto> GetArticleById(int id);
        Task<IEnumerable<ArticlesDto>> GetAllArticles();
        Task Add(AddArticlesDto articlesDto);
        Task<Article> FindArticle(int id);
        Task<bool> Update(int id,ArticlesDto articlesDto);
        Task<bool> Delete(int id);
    }
}
