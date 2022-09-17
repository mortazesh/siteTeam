using NetElites.Domain.Model.Articles;
using NetElites.Domain.Model.Members;
using NetElites.Domain.Model.Worksamples;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetElites.Doamin.Model
{
    public class Tag
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "نام تگ")]
        [Required(ErrorMessage = " {0} را لطفا وارد کنید")]
        [MinLength(3, ErrorMessage = "{0} نباید از {1} کارکتر کمتر باشد")]
        public string Name { get; set; }
        public int? ArticleId { get; set; }
        public int? MemberId { get; set; }
        public int? WorksampleId { get; set; }
        #region Relations
        public virtual Article Article { get; set; }
        public virtual Member Member { get; set; }
        public virtual Worksample Worksample { get; set; }
        #endregion
    }
}
