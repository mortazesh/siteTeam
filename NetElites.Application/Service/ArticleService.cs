using NetElitres.Application.Dto.Article;
using NetElitres.Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using NetElitres.Application.Dto.Comment;
using NetElitres.Application.Dto.Seo;
using NetElites.Domain.Model.Articles;
using NetElites.Application.Dto.Tag;

namespace NetElitres.Application.Service
{
    public class ArticleService: IArticleRepository
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ArticleService(IApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Add(AddArticlesDto articlesDto)
        {
            var article = _mapper.Map<Article>(articlesDto);
            await _context.articles.AddAsync(article);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var article = await FindArticle(id);
            if (article != null)
            {
                _context.articles.Remove(article);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Article> FindArticle(int id)
        {
            var article = await _context.articles.FindAsync(id);
            return article;
        }
        public async Task<IEnumerable<ArticlesDto>> GetAllArticles()
        {
            var articles = await _context.articles
                .Select(article => new ArticlesDto
                {
                    Id = article.Id,
                    Title = article.Title,
                    Description = article.Description,
                    Author = article.Author,
                    UrlImage = article.UrlImage
                })
                .ToListAsync();
            return articles;
        }
        public async Task<ArticlesDto> GetArticleById(int id)
        {
            var article = await _context.articles.
                Where(a => a.Id == id).
                Include(a => a.Seo).
                Include(a => a.Tags).
                FirstOrDefaultAsync();
            if (article != null)
            {
                return new ArticlesDto
                {
                    Id = article.Id,
                    Title = article.Title,
                    Level = article.Level,
                    UrlImage = article.UrlImage,
                    AltImage = article.AltImage,
                    TitleImage = article.TitleImage,
                    Author = article.Author,
                    Created = article.Created,
                    Description = article.Description,
                    seo = new SeoDto
                    {
                        Description = article.Seo.Description,
                        Title = article.Seo.Title,
                        Created = article.Seo.Created,
                    },
                    tags = article.Tags.Select(t => new TagDto
                    {
                        name = t.Name
                    }).ToList()
                };
            }
            return null;
        }

        public async Task<bool> Update(int id, ArticlesDto articlesDto)
        {
            var article = await FindArticle(id);
            if (article != null)
            {       
                var articalModel = _mapper.Map(articlesDto,article);
                _context.articles.Update(articalModel);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
