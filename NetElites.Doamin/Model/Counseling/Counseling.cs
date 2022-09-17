using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetElites.Doamin.Model.Counseling
{
    public class Counseling
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "نام")]
        [Required(ErrorMessage = " {0} را لطفا وارد کنید")]
        [MinLength(3, ErrorMessage = "{0} نباید از {1} کارکتر کمتر باشد")]
        [MaxLength(20, ErrorMessage = "{0} نباید از {1} کارکتر بیشتر باشد")]
        public string Name { get; set; }
        [Display(Name = "نوع مشاوره")]
        [Required(ErrorMessage = " {0} را لطفا وارد کنید")]
        [MinLength(5, ErrorMessage = "{0} نباید از {1} کارکتر کمتر باشد")]
        public string Type { get; set; }
        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = " {0} را لطفا وارد کنید")]
        [MinLength(11, ErrorMessage = "{0} نباید از {1} کارکتر کمتر باشد")]
        [MaxLength(11, ErrorMessage = "{0} نباید از {1} کارکتر بیشتر باشد")]
        [Phone]
        public string MobileNumber { get; set; }
        [Display(Name = "درخواست")]
        [Required(ErrorMessage = " {0} را لطفا وارد کنید")]
        [MinLength(3, ErrorMessage = "{0} نباید از {1} کارکتر کمتر باشد")]
        public string Application { get; set; }
    }
}
