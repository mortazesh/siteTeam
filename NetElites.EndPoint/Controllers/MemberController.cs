using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetElitres.Application.Dto.Response;
using NetElitres.Application.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;
using NetElitres.Application.Dto.Member;

namespace NetElites.EndPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberRespoitory _member;
        private readonly IMapper _mapper;
        public MemberController(IMemberRespoitory member, IMapper mapper)
        {
            _member = member;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var member = await _member.GetAllMember();
            return Ok(new ResponseDto
            {
                DisplayMessage = "عملیات با موفقیت انجام شد",
                IsSccees = true,
                Result = member,
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
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var member = await _member.GetMemberById(id);
            return Ok(new ResponseDto
            {
                DisplayMessage = "عملیات با موفقیت انجام شد",
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
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddMemberDto model)
        {
            if (!ModelState.IsValid)
            {
                await _member.Add(model);
                return Ok(new ResponseDto
                {
                    DisplayMessage = "عملیات ثبت عضو جدید با موفقیت انجام شد",
                    IsSccees = true,
                    links = new List<LinksDto>()
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
        public async Task<IActionResult> Put([FromRoute]int id,[FromBody] MemberDto model)
        {
            var member = await _member.Update(id,model);
            if (member !=  false)
            {
                return Ok(new ResponseDto
                {
                    DisplayMessage = "عملیات ویرایش اطلاعات عضو با موفقیت انجام شد",
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
                ErrorMessage = "",
                IsSccees = false,
                links = new List<LinksDto>
                {
                    new LinksDto
                    {
                        Href = "",
                        Method = "",
                        Rel = ""
                    }
                }
            });
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            var member = await _member.Delete(id);
            if (member != false)
            {
                return BadRequest(new ResponseDto
                {
                    DisplayMessage = "عملیات حذف اطلاعات حذف با موفقیت انجام شد",
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
                });;
            }
            return BadRequest(new ResponseDto
            {
                ErrorMessage = "عملیات حذف اطلاعات حذف با موفقیت انجام نشد",
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
