using ArticlesAPI.Dtos;
using ArticlesAPI.Models;
using AutoMapper;

namespace ArticlesAPI.Profiles
{
    public class ArticlesProfile : Profile
    {
        public ArticlesProfile()
        {
            CreateMap<Article, ArticleDTO>();
            CreateMap<AddArticleDTO, Article>();
            CreateMap<UpdateArticleDTO, Article>();
        }
    }
}