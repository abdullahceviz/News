using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Utilities.Result;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfNewsDal : EfEntityRepositoryBase<News, NewsContext>, INewsDal
    {
        public List<NewsDto> GetAllNewsDto()
        {
            using (var context = new NewsContext())
            {
                var result = from news in context.News where news.Published == true
                             select new NewsDto { NewsId = news.NewsId, Content = news.Content, Caption=news.Caption, Published=news.Published };
                return result.ToList();
            }
        }

        public List<NewsDto> GetMyNews(int userId, bool published)
        {
            using (var context = new NewsContext())
            {
                var result = from news in context.News
                             where news.Published == published && news.UserId == userId
                             select new NewsDto { NewsId = news.NewsId, Content = news.Content, Caption = news.Caption, Published = news.Published };
                return result.ToList();
            }
        }
        public bool Control(int NewsId,int UserId)
        {
            using (var context = new NewsContext())
            {
                var control = context.News.FirstOrDefault(x => x.NewsId == NewsId && x.UserId == UserId);
                return (control != null);
            }
        }
    }
}
