using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetElitres.Application.Dto.Response
{
    public class ResponseDto
    {
        public bool IsSccees { get; set; } = true;
        public string DisplayMessage { get; set; } = "";
        public object Result { get; set; }
        public string ErrorMessage { get; set; }
        public List<LinksDto> links { get; set; }
    }
}
