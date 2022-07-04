using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace NetElites.Domain.Model.Users
{
    public class User:IdentityUser
    {
        [Display(Name = "فعال سازی")]
        public bool IsActive { get; set; }
        #region Relations
        public virtual ICollection<Token> Tokens { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        #endregion
    }
}
