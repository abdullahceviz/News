using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConserns.Loging.Log4Net.Loggers;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class NewsManager : INewsService
    {
        private IHttpContextAccessor _httpContextAccessor;
        private INewsDal _newsDal;
        public NewsManager(INewsDal newsDal, IHttpContextAccessor httpContextAccessor)
        {
            _newsDal = newsDal;
            _httpContextAccessor = httpContextAccessor;
        }
        [ValidationAspect(typeof(NewsValidator))]
        [LogAspect(typeof(DatabaseLogger))]
        public IResult Add(NewsDto news)
        {
            News n = new News();
            n.Caption = news.Caption;
            n.Content = news.Content;
            n.Published = news.Published;
            n.NewsId = news.NewsId;
            var IdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            n.UserId = Convert.ToInt32(IdClaim);
            _newsDal.Add(n);
            return new SuccessResult(Messages.NewsAdded);

        }
        [LogAspect(typeof(DatabaseLogger))]
        public IResult Delete(NewsDto news)
        {
            var IdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (_newsDal.Control(news.NewsId, Convert.ToInt32(IdClaim)))
            {
                News n = new News();
                n.Caption = news.Caption;
                n.Content = news.Content;
                n.Published = news.Published;
                n.NewsId = news.NewsId;
                _newsDal.Delete(n);
                return new SuccessResult(Messages.NewsDeleted);
            }
            else
            {
                return new ErrorResult(Messages.NewsDeleteError);
            }
        }

        public IDataResult<News> GetById(int id)
        {
            return new SuccessDataResult<News>(_newsDal.Get(x => x.NewsId == id));
        }
        public IDataResult<List<NewsDto>> GetList()
        {
            return new SuccessDataResult<List<NewsDto>>(_newsDal.GetAllNewsDto().ToList());
        }

        public IDataResult<List<NewsDto>> GetMyNews(bool publised)
        {
            var IdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return new SuccessDataResult<List<NewsDto>>(_newsDal.GetMyNews(Convert.ToInt32(IdClaim), publised).ToList());
        }
        [ValidationAspect(typeof(NewsValidator))]
        [LogAspect(typeof(DatabaseLogger))]
        public IResult Update(NewsDto news)
        {
            var IdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (_newsDal.Control(news.NewsId, Convert.ToInt32(IdClaim)))
            {
                News n = new News();
                n.Caption = news.Caption;
                n.Content = news.Content;
                n.Published = news.Published;
                n.NewsId = news.NewsId;
                n.UserId = Convert.ToInt32(IdClaim);
                _newsDal.Update(n);
                return new SuccessResult(Messages.NewsUpdated);
            }
            else
            {
                return new ErrorResult(Messages.NewsUpdateError);
            }
        }
        [LogAspect(typeof(DatabaseLogger))]
        public IResult ChangePublishState(int newsId,bool published)
        {
            var IdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (_newsDal.Control(newsId, Convert.ToInt32(IdClaim)))
            {
                News n = GetById(newsId).Data;
                n.Published = published;
                _newsDal.Update(n);
                return new SuccessResult(Messages.NewsUpdated);
            }
            else
            {
                return new ErrorResult(Messages.NewsUpdateError);
            }
        }
    }
}
