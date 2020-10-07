using Microsoft.AspNetCore.Mvc;
using ArticlesAPI.Services.ArticleServices;
using ArticlesAPI.Models;

namespace ArticlesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleServices _articleService;
        public ArticlesController(IArticleServices articleService)
        {
            _articleService = articleService;
        }

        [HttpGet("GetAll")]

        public IActionResult Get()
        {
            return Ok(_articleService.GetArticles());
        }

        [HttpGet("GetArticle/{id}")]
        public IActionResult GetArticle(int id)
        {
            var article = _articleService.GetArticleById(id);
            if (article != null)
            {
                return Ok(article);
            }
            return NotFound();
        }

        [HttpPost("AddArticle")]
        public IActionResult AddArticle(Article article)
        {
            return Ok(_articleService.AddArticle(article));
        }

        [HttpPut("UpdateArticle/{id}")]
        public IActionResult UpdateArticle(int id, Article article)
        {
            return Ok(_articleService.UpdateArticle(id, article));
        }

        [HttpDelete("DeleteArticle/{id}")]

        public IActionResult DeleteArticle(int id)
        {
            return Ok(_articleService.DeleteArticle(id));
        }

    }
}