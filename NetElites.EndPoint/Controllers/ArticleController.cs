using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetElitres.Application.Dto.Article;
using NetElitres.Application.Dto.Response;
using NetElitres.Application.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetElites.EndPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleRepository _article;
        private readonly IMapper _mapper;
        public ArticleController(IArticleRepository article,IMapper mapper)
        {
            _article = article;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var aeticle = await _article.GetAllArticles();
            return Ok(new ResponseDto
            {
                DisplayMessage = "عملیات برگشت مقالات با موفقیت انجام شد",
                IsSccees = true,
                Result = aeticle,
                links = new List<LinksDto>()
                {
                    new LinksDto
                    {
                        Href = "",
                        Method = "GET",
                        Rel = "GetById"
                    },
                    new LinksDto
                    {
                        Href = "",
                        Method = "POST",
                        Rel = "Post"
                    },
                    new LinksDto
                    {
                        Href = "",
                        Method = "PUT",
                        Rel = "Put"
                    },
                    new LinksDto
                    {
                        Href = "",
                        Method = "DELETE",
                        Rel = "Delete"
                    }
                }
            });
        }
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            HttpContext.Response.Headers.Add("Access-Control-Allow-Headers", "*");
            HttpContext.Response.Headers.Add("Access-Control-Allow-Methods", "*");
            var article = await _article.GetArticleById(id);
            if (article != null)
            {
                return Ok(new ResponseDto
                {
                    DisplayMessage = "عملیات برگشت مقاله با موفقیت انجام شد",
                    IsSccees = true,
                    Result = article,
                    links = new List<LinksDto>()
                    {
                        new LinksDto
                        {
                            Href = "",
                            Method = "GET",
                            Rel = "GetAll"
                        },
                        new LinksDto
                        {
                            Href = "",
                            Method = "POST",
                            Rel = "Post"
                        },
                        new LinksDto
                        {
                            Href = "",
                            Method = "PUT",
                            Rel = "Put"
                        },
                        new LinksDto
                        {
                            Href = "",
                            Method = "DELETE",
                            Rel = "Delete"
                        }
                    }
                });
            }
            return BadRequest(new ResponseDto
            {
                ErrorMessage = "چنین مقالاتی وجود ندارد",
                IsSccees = false,
                Result = null
            });
        }
        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Post([FromBody]AddArticlesDto model)
        {
            if (ModelState.IsValid)
            {
                await _article.Add(model);
                return Ok(new ResponseDto
                {
                    DisplayMessage = "عمیلات ثبت مقالات با موفقیت انجام شد",
                    IsSccees = true,
                    links = new List<LinksDto>
                    {
                        new LinksDto
                        {
                            Href = "",
                            Method = "POST",
                            Rel = "Post"
                        },
                        new LinksDto
                        {
                            Href = "",
                            Method = "GET",
                            Rel = "GetAll"
                        },
                        new LinksDto
                        {
                            Href = "",
                            Method = "GET",
                            Rel = "GetById"
                        },
                        new LinksDto 
                        {
                            Href = "",
                            Method = "PUT",
                            Rel = "Put"
                        },
                        new LinksDto
                        {
                            Href = "",
                            Method = "DELETE",
                            Rel = "Delete"
                        }
                    }
                });
            }
            return BadRequest(model);
        }
        [HttpPut]
        [Route("Put")]
        public async Task<IActionResult> Put([FromRoute]int id,[FromBody]ArticlesDto model)
        {
            if (ModelState.IsValid)
            {
                var article = await _article.Update(id,model);
                if (article != false)
                {
                    
                }
                return BadRequest(new ResponseDto
                {
                    ErrorMessage = "عملیات آپدیت مقاله با موفقیت انجام نشد",
                    IsSccees = false,
                    links = new List<LinksDto>()
                    {
                        new LinksDto
                        {
                            Href = "",
                            Method = "POST",
                            Rel = "Post"
                        },
                        new LinksDto
                        {
                            Href = "",
                            Method = "GET",
                            Rel = "GetAll"
                        },
                        new LinksDto
                        {
                            Href = "",
                            Method = "GET",
                            Rel = "GetById"
                        },
                        new LinksDto
                        {
                            Href = "",
                            Method = "DELETE",
                            Rel = "Delete"
                        }
                    }
                });
            }
            return BadRequest(model);
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            var article = await _article.Delete(id);
            if (article != false)
            {
                return Ok(new ResponseDto
                {
                    DisplayMessage = "عملیات حذف نقاله با موفقیت انجام شد",
                    IsSccees = false,
                    links = new List<LinksDto>
                    {
                        new LinksDto
                        {
                            Href = "",
                            Method = "POST",
                            Rel = "Post"
                        },
                        new LinksDto
                        {
                            Href = "",
                            Method = "GET",
                            Rel = "GetAll"
                        },
                        new LinksDto
                        {
                            Href = "",
                            Method = "GET",
                            Rel = "GetById"
                        },
                        new LinksDto
                        {
                            Href = "",
                            Method = "PUT",
                            Rel = "Put"
                        }
                    }
                });
            }
            return BadRequest(new ResponseDto
            {
                ErrorMessage = "عملیات حذف مقاله با موفقیت انجام نشد",
                IsSccees = false,
                links = new List<LinksDto>
                {
                    new LinksDto
                    {
                         Href = "",
                         Method = "POST",
                         Rel = "Post"
                    },
                    new LinksDto
                    {
                         Href = "",
                         Method = "GET",
                         Rel = "GetAll"
                    },
                    new LinksDto
                    {
                         Href = "",
                         Method = "GET",
                         Rel = "GetById"
                    },
                    new LinksDto
                    {
                         Href = "",
                         Method = "PUT",
                         Rel = "Put"
                    }
                }
            });
        }
    }
}
