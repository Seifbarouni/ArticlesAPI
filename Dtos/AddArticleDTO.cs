using System.ComponentModel.DataAnnotations;

namespace ArticlesAPI.Dtos
{
    public class AddArticleDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
    }
}