using NetElitres.Application.Dto.Comment;
using NetElitres.Application.Dto.Seo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetElitres.Application.Dto.Worksample
{
    public class WorksampleDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string UriImage { get; set; }
        public string Type { get; set; }
        public DateTime Created { get; set; }
        public List<CommentDto> comment { get; set; }
        public SeoDto seo { get; set; }
    }
}
