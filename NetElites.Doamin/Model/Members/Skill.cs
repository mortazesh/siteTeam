using NetElites.Domain.Model.Members;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetElites.Doamin.Model.Members
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "نام")]
        [Required(ErrorMessage = " {0} را لطفا وارد کنید")]
        [MinLength(3, ErrorMessage = "{0} نباید از {1} کارکتر کمتر باشد")]
        [MaxLength(50, ErrorMessage = "{0} نباید از {1} کارکتر بیشتر باشد")]
        public string Name { get; set; }
        [Display(Name = "نام")]
        [Required(ErrorMessage = " {0} را لطفا وارد کنید")]
        [MinLength(1, ErrorMessage = "{0} نباید از {1} کارکتر کمتر باشد")]
        [MaxLength(3, ErrorMessage = "{0} نباید از {1} کارکتر بیشتر باشد")]
        public string Level { get; set; }
        public int MemberId { get; set; }
        #region Relations
        public virtual Member Member { get; set; }
        #endregion
    }
}
