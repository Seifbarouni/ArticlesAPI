using System.ComponentModel.DataAnnotations;

namespace ArticlesAPI.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = "Empty Title";
        [Required]
        public string Content { get; set; } = "No Content";
    }
}