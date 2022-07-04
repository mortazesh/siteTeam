using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetElitres.Application.Dto.Worksample
{
    public class AddWorksampleDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string UriImage { get; set; }
        public string Type { get; private set; }
        public DateTime Created { get; set; }
    }
}
