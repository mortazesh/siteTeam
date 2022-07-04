using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace NetElites.Domain.Model.Users
{
    public class Role:IdentityRole
    {
        public string Des { get; set; }
    }
}
