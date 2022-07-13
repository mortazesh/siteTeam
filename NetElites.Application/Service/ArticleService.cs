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
                    Title = article.Title,
                    Description = article.Description,
                })
                .ToListAsync();
            return articles;
        }

        public async Task<ArticlesDto> GetArticleById(int id)
        {
            var article = await _context.articles.
                Where(a => a.Id == id).
                Include(a => a.Comments).
                Include(a => a.Seo).
                FirstOrDefaultAsync();
            return new ArticlesDto
            {
                Author = article.Author,
                Created = article.Created,
                Description = article.Description,
                comment = article.Comments.Select(comment => new CommentDto
                {
                    Created = comment.Created,
                    Description = comment.Description,
                    FullName = comment.FullName,
                }).ToList(), 
                seo = new SeoDto
                {
                    Description = article.Seo.Description,
                    Title = article.Seo.Title,
                    Created = article.Seo.Created,
                }
            };
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
