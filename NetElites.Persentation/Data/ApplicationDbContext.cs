using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetElites.Doamin.Model.Members;
using NetElites.Domain.Model;
using NetElites.Domain.Model.Articles;
using NetElites.Domain.Model.Members;
using NetElites.Domain.Model.Users;
using NetElites.Domain.Model.Worksamples;
using NetElitres.Application.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetElites.EndPoint.Data
{
    public class ApplicationDbContext : IdentityDbContext<User,Role,string>, IApplicationDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> users { get; set; }
        public DbSet<Token> tokens { get; set; }
        public DbSet<SmsCode> smsCodes { get; set; }
        public DbSet<Article> articles { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Seo> seos { get; set; }
        public DbSet<Member> members { get; set; }
        public DbSet<Worksample> worksamples { get; set; }
        public DbSet<Skill> skills { set; get; }
    }
}
