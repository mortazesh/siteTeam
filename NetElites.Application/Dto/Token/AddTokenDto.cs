using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetElites.Application.Dto.Token
{
    public class AddTokenDto
    {
        public string tokenHash { get; set; }
        public string refreshTokenHash { get; set; }
        public string userId { get; set; }
    }
}
