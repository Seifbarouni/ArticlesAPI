using ArticlesAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace ArticlesAPI.Services.ArticleServices {
    public class ArticleContext : DbContext {
        public ArticleContext (DbContextOptions<ArticleContext> opt) : base (opt) {

        }

        public DbSet<Article> Articles { get; set; }
    }
}