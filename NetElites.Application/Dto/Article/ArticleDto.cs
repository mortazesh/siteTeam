using NetElitres.Application.Dto.Comment;
using NetElitres.Application.Dto.Seo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetElitres.Application.Dto.Article
{
    public class ArticlesDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string UrlImage { get; set; }
        public string Author { get; set; }
        public DateTime Created { get; set; }
        public Level Level { get; set; }
        public List<CommentDto> comment { get; set; }
        public SeoDto seo { get; set; }
    }
    public enum Level
    {
        Easy = 0,
        Medium = 1,
        Hard = 2,
    }
}
