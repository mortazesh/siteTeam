using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetElites.Comman.Helper
{
    public class GenricCode
    {
        public static string smsCode()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }
        public static string code()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
