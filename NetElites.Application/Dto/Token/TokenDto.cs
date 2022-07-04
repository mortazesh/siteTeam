using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetElites.Application.Dto.Token
{
    public  class TokenDto
    {
        public string tokenHash { get; set; }
        public DateTime tokenExp { get; set; }
        public string refreshTokenHash { get; set; }
        public DateTime refreshTokenExp { get; set; }
    }
}
