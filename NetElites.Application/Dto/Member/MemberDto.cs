using NetElitres.Application.Dto.Comment;
using NetElitres.Application.Dto.Seo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetElitres.Application.Dto.Member
{
    public class MemberDto
    {
        public string Name { get; set; }
        public string Level { get; set; }
        public string Description { get; set; }
        public string UrlImage { get; set; }
        public DateTime Created { get; set; }
        public SeoDto seo { get; set; }
    }
}
