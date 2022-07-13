using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetElites.Application.Dto.User
{
    public class SmsDto
    {
        public string MobileNumber { get; set; }
        public string Code { get; set; }
        public bool Used { get; set; }
        public DateTime Created { get; set; }
        public int RequertCount { get; set; }
    }
}
