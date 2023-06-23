using Core.Utilities.Result;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface INewsService
    {
        IDataResult<List<NewsDto>> GetList();
        IDataResult<List<NewsDto>> GetMyNews(bool publised);
        IDataResult<News> GetById(int id);
        IResult Add(NewsDto news);
        IResult Update(NewsDto news);
        IResult Delete(NewsDto news);
        IResult ChangePublishState(int newsId, bool published);

    }
}
