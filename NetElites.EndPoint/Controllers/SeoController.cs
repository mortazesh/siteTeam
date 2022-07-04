using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetElitres.Application.Dto.Response;
using NetElitres.Application.Dto.Seo;
using NetElitres.Application.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetElites.EndPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeoController : ControllerBase
    {
        private readonly ISeoRepository _seo;
        private readonly IMapper _mapper;
        public SeoController(ISeoRepository seo, IMapper mapper)
        {
            _seo = seo;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]SeoDto model)
        {
            if (!ModelState.IsValid)
            {
                await _seo.Add(model);
                return Ok(new ResponseDto
                {
                    DisplayMessage = "عملیات ثبت با موفقیت انجام شد",
                    IsSccees = true,
                    links = new List<LinksDto>
                {
                    new LinksDto
                    {
                        Href = "",
                        Method = "POST",
                        Rel = ""
                    }
                }
                });
            }
            return BadRequest(model);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromRoute]int id,[FromBody] SeoDto model) 
        {
            if (ModelState.IsValid)
            {
                var seo = await _seo.Update(id,model);
                if (seo != false)
                {

                }
                return BadRequest(new ResponseDto
                {
                    ErrorMessage = "عملیات آپدیت با موفقیت انجام نشد",
                    IsSccees = true,
                    links = new List<LinksDto>
                    {
                        new LinksDto
                        {
                            Href = "",
                            Method = "PUT",
                            Rel = "Put"
                        }
                    }
                });
            }
            return BadRequest(model);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            var seo = await _seo.Delete(id);
            if (seo != false)
            {

            }
            return BadRequest(new ResponseDto
            {
                ErrorMessage = "عملیات حذف با موفقیت اناجم نشد",
                IsSccees = false,
                links = new List<LinksDto>
                {
                    new LinksDto
                    {
                        Href = "",
                        Method = "DELETE",
                        Rel = ""
                    }
                }
            });
        }
    }
}
