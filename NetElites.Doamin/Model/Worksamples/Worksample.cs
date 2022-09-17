using NetElites.Doamin.Model;
using NetElites.Doamin.Model.Worksamples;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetElites.Domain.Model.Worksamples
{
    public class Worksample
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "عنوان نمونه کار")]
        [Required(ErrorMessage = " {0} را لطفا وارد کنید")]
        [MinLength(3, ErrorMessage = "{0} نباید از {1} کارکتر کمتر باشد")]
        [MaxLength(20, ErrorMessage = "{0} نباید از {1} کارکتر بیشتر باشد")]
        public string Title { get; set; }
        [Display(Name = "متن نمونه کار")]
        [Required(ErrorMessage = " {0} را لطفا وارد کنید")]
        [MinLength(30, ErrorMessage = "{0} نباید از {1} کارکتر کمتر باشد")]
        public string Description { get; set; }
        [Display(Name = "زمان انتشار نمونه کار")]
        [Required(ErrorMessage = " {0} را لطفا وارد کنید")]
        public DateTime Created { get; set; }
        [Display(Name = "عکس نمونه کار")]
        [Required(ErrorMessage = " {0} را لطفا وارد کنید")]
        public string UriImage { get; set; }
        [Display(Name = "توضیح کوتاه عکس نمونه کار")]
        [Required(ErrorMessage = " {0} را لطفا وارد کنید")]
        public string AltImage { get; set; }
        [Display(Name = "توضیح عکس نمونه کار")]
        [Required(ErrorMessage = " {0} را لطفا وارد کنید")]
        public string TitleImage { get; set; }
        #region Relations
        public virtual Seo Seo { get; set; }
        public virtual ICollection<Tag> Tags { get; set; } 
        public virtual ICollection<UsedWorksample> UsedWorksamples { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        #endregion
    }
}
