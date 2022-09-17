using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetElitres.Application.Dto.Article
{
    public class AddArticlesDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string UrlImage { get; set; }
        public string Author { get; set; }
        public DateTime Created { get; set; }
        public string Level { get; set; }
    }
}
