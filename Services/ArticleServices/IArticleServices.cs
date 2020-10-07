using ArticlesAPI.Models;
using System.Collections.Generic;
namespace ArticlesAPI.Services.ArticleServices
{
    public interface IArticleServices
    {
        List<Article> GetArticles();
        Article GetArticleById(int id);
        Article AddArticle(Article article);
        Article UpdateArticle(int id, Article article);
        List<Article> DeleteArticle(int id);

    }
}