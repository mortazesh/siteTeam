using NetElites.Application.Dto.Tag;
using NetElites.Application.Dto.UsedWorksample;
using NetElites.Doamin.Model;
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
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UriImage { get; set; }
        public string AltImage { get; set; }
        public string TitleImage { get; set; }
        public DateTime Created { get; set; }
        public List<CommentDto> comment { get; set; }
        public List<TagDto> tags { get; set; }
        public List<UsedWorksampleDto> usedWorksamples { get; set; }
        public SeoDto seo { get; set; }
    }
}
