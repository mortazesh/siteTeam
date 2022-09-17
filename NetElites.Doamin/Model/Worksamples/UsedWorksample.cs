using NetElites.Domain.Model.Worksamples;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetElites.Doamin.Model.Worksamples
{
    public class UsedWorksample
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = " {0} را لطفا وارد کنید")]
        [MinLength(3, ErrorMessage = "{0} نباید از {1} کارکتر کمتر باشد")]
        public string Name { get; set; }
        public int WorksampleId { get; set; }
        #region Relations
        public virtual Worksample Worksamples { get; set; }
        #endregion
    }
}
