using Microsoft.AspNetCore.Mvc;
using ArticlesAPI.Services.ArticleServices;
using ArticlesAPI.Models;
using AutoMapper;
using ArticlesAPI.Dtos;
using System.Collections.Generic;

namespace ArticlesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleServices _articleService;
        private readonly IMapper _mapper;

        public ArticlesController(IArticleServices articleService, IMapper mapper)
        {
            _articleService = articleService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]

        public IActionResult Get()
        {
            return Ok(_mapper.Map<List<ArticleDTO>>(_articleService.GetArticles()));
        }

        [HttpGet("GetArticle/{id}")]
        public IActionResult GetArticle(int id)
        {
            var article = _articleService.GetArticleById(id);
            if (article != null)
            {
                return Ok(_mapper.Map<ArticleDTO>(article));
            }
            return NotFound();
        }

        [HttpPost("AddArticle")]
        public IActionResult AddArticle(AddArticleDTO article)
        {
            var articleModel = _mapper.Map<Article>(article);
            return Ok(_mapper.Map<ArticleDTO>(_articleService.AddArticle(articleModel)));
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
            return Ok(_mapper.Map<List<ArticleDTO>>(_articleService.DeleteArticle(id)));
        }

    }
}