using NetElites.Domain.Model.Articles;
using NetElites.Domain.Model.Members;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetElites.Domain.Model.Worksamples;

namespace NetElites.Domain.Model
{
    public class Seo
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = " {0} را لطفا وارد کنید")]
        [MinLength(3, ErrorMessage = "{0} نباید از {1} کارکتر کمتر باشد")]
        [MaxLength(30, ErrorMessage = "{0} نباید از {1} کارکتر بیشتر باشد")]
        public string Title { get; set; }
        [Display(Name = "توضیح کوتاه")]
        [Required(ErrorMessage = " {0} را لطفا وارد کنید")]
        [MinLength(30, ErrorMessage = "{0} نباید از {1} کارکتر کمتر باشد")]
        [MaxLength(150, ErrorMessage = "{0} نباید از {1} کارکتر بیشتر باشد")]
        public string Description { get; set; }
        [Display(Name = "زمان انتشار ")]
        public DateTime Created { get; set; }
        public int ArticleId { get; set; }
        public int MemberId { get; set; }
        public int WorksampleId { get; set; }
        #region Relations
        public virtual Article Article { get; set; }
        public virtual Member Member { get; set; }
        public virtual Worksample Worksample { get; set; }
        #endregion
    }
}
