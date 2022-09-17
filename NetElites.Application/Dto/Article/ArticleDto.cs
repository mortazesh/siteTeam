using NetElites.Application.Dto.Tag;
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
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UrlImage { get; set; }
        public string AltImage { get; set; }
        public string TitleImage { get; set; }
        public string Author { get; set; }
        public DateTime Created { get; set; }
        public string Level { get; set; }
        public List<CommentDto> comment { get; set; }
        public SeoDto seo { get; set; }
        public List<TagDto> tags { get; set; }
    }
}
