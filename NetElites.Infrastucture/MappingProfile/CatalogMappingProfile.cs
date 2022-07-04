using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NetElites.Domain.Model;
using NetElites.Domain.Model.Articles;
using NetElites.Domain.Model.Members;
using NetElites.Domain.Model.Worksamples;
using NetElitres.Application.Dto.Article;
using NetElitres.Application.Dto.Comment;
using NetElitres.Application.Dto.Member;
using NetElitres.Application.Dto.Seo;
using NetElitres.Application.Dto.Worksample;

namespace NetElites.Infrastucture.MappingProfile
{
    public class CatalogMappingProfile: Profile
    {
        public CatalogMappingProfile()
        {
            CreateMap<Article, ArticlesDto>().ReverseMap();
            CreateMap<Article, AddArticlesDto>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<Member, AddMemberDto>().ReverseMap();
            CreateMap<Member, MemberDto>().ReverseMap();
            CreateMap<Seo, SeoDto>().ReverseMap();
            CreateMap<Worksample, AddWorksampleDto>().ReverseMap();
            CreateMap<Worksample, WorksampleDto>().ReverseMap();
        }
    }
}
