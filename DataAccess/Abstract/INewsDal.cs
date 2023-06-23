using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface INewsDal:IEntityRepository<News>
    {
        List<NewsDto> GetAllNewsDto();
        List<NewsDto> GetMyNews(int userId, bool published);
        bool Control(int NewsId, int userId);
    }
}
