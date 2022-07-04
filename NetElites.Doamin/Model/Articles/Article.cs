using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetElites.Domain.Model.Articles
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="عنوان مقاله")]
        [Required(ErrorMessage = " {0} را لطفا وارد کنید")]
        [MinLength(3, ErrorMessage = "{0} نباید از {1} کارکتر کمتر باشد")]
        [MaxLength(20, ErrorMessage = "{0} نباید از {1} کارکتر بیشتر باشد")]
        public string Title { get; set; }
        [Display(Name = "متن مقاله")]
        [Required(ErrorMessage = " {0} را لطفا وارد کنید")]
        [MinLength(50, ErrorMessage = "{0} نباید از {1} کارکتر کمتر باشد")]
        public string Description { get; set; }
        [Display(Name = "عکس مقاله")]
        [Required(ErrorMessage = " {0} را لطفا وارد کنید")]
        public string UrlImage { get; set; }
        [Display(Name = "نویسنده مقاله")]
        [Required(ErrorMessage = " {0} را لطفا وارد کنید")]
        [MinLength(3, ErrorMessage = "{0} نباید از {1} کارکتر کمتر باشد")]
        [MaxLength(30, ErrorMessage = "{0} نباید از {1} کارکتر بیشتر باشد")]
        public string Author { get; set; }
        [Display(Name = "زمان انتشار مقاله")]
        public DateTime Created { get; set; }
        [Display(Name = "سطح مقاله")]
        [Required(ErrorMessage = " {0} را لطفا وارد کنید")]
        public Level Level { get; set; }
        #region Relations
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual Seo Seo { get; set; }
        #endregion
    }
    public enum Level
    {
        Easy = 0,
        Medium = 1,
        Hard = 2,
    }
}
