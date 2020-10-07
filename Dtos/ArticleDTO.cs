using System.ComponentModel.DataAnnotations;

namespace ArticlesAPI.Dtos
{
    public class ArticleDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}