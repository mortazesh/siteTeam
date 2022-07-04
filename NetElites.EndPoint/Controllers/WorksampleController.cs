using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetElitres.Application.Dto.Response;
using NetElitres.Application.Dto.Worksample;
using NetElitres.Application.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetElites.EndPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorksampleController : ControllerBase
    {
        private readonly IWorksampleRepository _worksample;
        public WorksampleController(IWorksampleRepository worksample)
        {
            _worksample = worksample;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var worksample = await _worksample.GetAllWorksample();
            return Ok(new ResponseDto
            {
                DisplayMessage = "عملیات برگشت نمونه کارها با موفقیت انجام شد",
                IsSccees = true,
                links = new List<LinksDto>
                {
                    new LinksDto
                    {
                        Href = "",
                        Method = "GET",
                        Rel = "GetAll"
                    }
                }
            });
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            var worksample = await _worksample.GetWorksampleById(id);
            return Ok(new ResponseDto
            {
                DisplayMessage = "عملیات برگشت نمونه کارها با موفقیت انجام شد",
                IsSccees = true,
                links = new List<LinksDto>
                {
                    new LinksDto
                    {
                        Href = "",
                        Method = "GET",
                        Rel = ""
                    }
                }
            });
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AddWorksampleDto model)
        {
            if (ModelState.IsValid)
            {
                await _worksample.Add(model);
                return Ok(new ResponseDto
                {
                    DisplayMessage = "عملیات قبت نمونه کار با موفقیت انجام شد",
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
        public async Task<IActionResult> Put([FromRoute]int id,[FromBody]WorksampleDto model)
        {
            if (ModelState.IsValid)
            {
                var worksample = await _worksample.Update(id,model);
                if (worksample != false)
                {
                    return Ok(new ResponseDto
                    {
                        DisplayMessage = "عملیات آپدیت نمونه کار با موفقیت انجام شد",
                        IsSccees = true,
                        links = new List<LinksDto>
                        {
                            new LinksDto
                            {
                                Href = "",
                                Method = "PUT",
                                Rel = ""
                            }
                        }
                    });
                }
                return BadRequest(new ResponseDto
                {
                    ErrorMessage = "عملیات آپدیت نمونه کار با موفقیت انجام نشد",
                    IsSccees = false,
                    links = new List<LinksDto>
                    {
                        new LinksDto 
                        {
                            Href = "",
                            Method = "PUT",
                            Rel = ""
                        }
                    }
                });
            }
            return BadRequest(model);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            var worksample = await _worksample.Delete(id);
            if (worksample != false)
            {
                return Ok(new ResponseDto
                {
                    DisplayMessage = "عملیات حذف نونه کار با موفقیت انجام نشد",
                    IsSccees = true,
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
            return BadRequest(new ResponseDto
            {
                ErrorMessage = "عملیات حذف نونه کار با موفقیت انجام نشد",
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
