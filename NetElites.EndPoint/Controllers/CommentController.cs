using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetElites.Domain.Model.Users;
using NetElitres.Application.Dto.Comment;
using NetElitres.Application.Dto.Response;
using NetElitres.Application.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetElites.EndPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _comment;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _user;
        public CommentController(ICommentRepository comment,IMapper mapper,UserManager<User> user)
        {
            _comment = comment;
            _mapper = mapper;
            _user = user;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CommentDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await _user.GetUserAsync(HttpContext.User);
                model.UserId = user.Id;
                await _comment.Add(model);
                return Ok(new ResponseDto
                {
                    DisplayMessage = "عملیات ثبت کامنت با موفقیت انجام شد",
                    IsSccees = true,
                    links = new List<LinksDto>()
                    {
                        new LinksDto
                        {
                            Href = "",
                            Method = "Put",
                            Rel = "Put"
                        }
                    }
                });

            }
            return BadRequest(model);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromRoute]int id,[FromBody]CommentDto model)
        {
            if (ModelState.IsValid)
            {
                var comment = await _comment.Update(id,model);
                if (comment != false)
                {
                    return Ok(new ResponseDto
                    {
                        DisplayMessage = "عملیات ثبت کامنت با موفقیت انجام شد",
                        IsSccees = true,
                        links = new List<LinksDto>()
                        {
                            new LinksDto
                            {
                                Href = "",
                                Method = "POST",
                                Rel = "Post"
                            }
                        }
                    });
                }
                return BadRequest(new ResponseDto
                {
                    DisplayMessage = "عملیات ثبت کامنت با موفقیت انجام نشد",
                    IsSccees = true,
                    links = new List<LinksDto>()
                    {
                        new LinksDto
                        {
                            Href = "",
                            Method = "POST",
                            Rel = "Post"
                        }
                    }
                });

            }
            return BadRequest(model);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            var comment = await _comment.Delete(id);
            if (comment != false)
            {
                return Ok(new ResponseDto
                {
                    DisplayMessage = "عملیات حذف کامنت با موفقیت انجام شد",
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
                ErrorMessage = "عمیلات حذف با موفقیت انجام نشد",
                IsSccees = false,
                links = new List<LinksDto>
                {
                    new LinksDto
                    {

                    }
                }
            });
        }
    }
}
