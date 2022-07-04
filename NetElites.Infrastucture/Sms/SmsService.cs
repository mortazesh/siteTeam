using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetElites.Infrastucture.Sms
{
    public class SmsService
    {
        public static void Send(string mobileNumber, string messageBody)
        {
            var client = new RestClient($"http://ippanel.com:8080/?apikey=mfZHjQ5FzR8irH3s9gfbmGnBwfr3AsfznBZTy6fktig=&pid=dupj5ghe9t&fnum=983000505&tnum={mobileNumber}&p1=code&v1={messageBody}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Cookie", "PHPSESSID=qcds265lk4f46naeujgqfdntgg");
            request.AlwaysMultipartFormData = true;
            IRestResponse response = client.Execute(request);
        }
    }
}
