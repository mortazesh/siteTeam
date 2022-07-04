using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetElites.Domain.Model.Users
{
    public class Token
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="توکن")]
        public string HashToken { get; set; }
        [Display(Name ="زمان توکن")]
        public DateTime TokenExpiry { get; set; }
        [Display(Name ="رفرش توکن")]
        public string RefreshToken { get; set; }
        [Display(Name ="زمان رفرش توکن")]
        public DateTime RefreshTokenExpiry { get; set; }
        public string UserId { get; set; }
        #region Relations
        public virtual User User { get; private set; }
        #endregion
    }
}
