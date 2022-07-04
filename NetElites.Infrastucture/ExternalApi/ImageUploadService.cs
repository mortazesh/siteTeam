using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetElites.Infrastucture.ExternalApi
{
    public class ImageUploadService : IImageUploadService
    {
        public string Upload(IFormFile files)
        {
            var client = new RestClient("https://localhost:44328/api/Images");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            string bytes;
            using (var ms = new MemoryStream())
            {
                files.CopyToAsync(ms);
                bytes = ms.ToString();
            }
            request.AddFile(files.FileName, bytes, files.FileName);


            IRestResponse response = client.Execute(request);
            UploadDto upload = JsonConvert.DeserializeObject<UploadDto>(response.Content);
            return upload.FileNameAddress;
        }
        public class UploadDto
        {
            public bool Status { get; set; }
            public string FileNameAddress { get; set; }
        }
    }
}
