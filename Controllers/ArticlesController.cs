using Microsoft.AspNetCore.Mvc;
using ArticlesAPI.Services.ArticleServices;
using ArticlesAPI.Models;
using AutoMapper;
using ArticlesAPI.Dtos;
using System.Collections.Generic;
using ArticlesAPI.JwtAuth;
using Microsoft.AspNetCore.Authorization;

namespace ArticlesAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleServices _articleService;
        private readonly IMapper _mapper;
        private readonly IJwtAuth _jwtmanager;

        public ArticlesController(IArticleServices articleService, IMapper mapper, IJwtAuth jwtauth)
        {
            _articleService = articleService;
            _mapper = mapper;
            _jwtmanager = jwtauth;

        }

        [HttpGet("GetAll")]

        public IActionResult Get()
        {
            ResponseModel<List<ArticleDTO>> response = new ResponseModel<List<ArticleDTO>>();
            response.Data = _mapper.Map<List<ArticleDTO>>(_articleService.GetArticles());
            return Ok(response);
        }

        [HttpGet("GetArticle/{id}")]
        public IActionResult GetArticle(int id)
        {
            ResponseModel<ArticleDTO> response = new ResponseModel<ArticleDTO>();
            var article = _articleService.GetArticleById(id);
            if (article != null)
            {
                response.Data = _mapper.Map<ArticleDTO>(article);
                return Ok(response);
            }
            response.Succes = false;
            response.Data = null;
            response.ErrorMessage = "Invalid Id";
            return Ok(response);
        }

        [HttpPost("AddArticle")]
        public IActionResult AddArticle(AddArticleDTO article)
        {
            var articleModel = _mapper.Map<Article>(article);
            ResponseModel<ArticleDTO> response = new ResponseModel<ArticleDTO>();
            response.Data = _mapper.Map<ArticleDTO>(_articleService.AddArticle(articleModel));
            return Ok(response);
        }

        [HttpPut("UpdateArticle/{id}")]
        public IActionResult UpdateArticle(int id, UpdateArticleDTO article)
        {
            var articleModelFromRepo = _articleService.GetArticleById(id);
            if (articleModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(article, articleModelFromRepo);
            _articleService.UpdateArticle(articleModelFromRepo);
            return NoContent();
        }

        [HttpDelete("DeleteArticle/{id}")]

        public IActionResult DeleteArticle(int id)
        {
            ResponseModel<List<ArticleDTO>> response = new ResponseModel<List<ArticleDTO>>();
            response.Data = _mapper.Map<List<ArticleDTO>>(_articleService.DeleteArticle(id));
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(UserCred userCred)
        {
            var token = _jwtmanager.Authenticate(userCred.Username, userCred.Password);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }

    }
}