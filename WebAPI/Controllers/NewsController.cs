using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        INewsService _newsService;
        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }
        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _newsService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [Authorize]
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _newsService.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [Authorize]
        [HttpGet("getmypublishedlist")]
        public IActionResult GetMyPublishedNews()
        {
            var result = _newsService.GetMyNews(true);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [Authorize]
        [HttpGet("getmyunpublishedlist")]
        public IActionResult GetMyUnPublishedNews()
        {
            var result = _newsService.GetMyNews(false);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [Authorize]
        [HttpPost("add")]
        public IActionResult Add(NewsDto news)
        {
            var result = _newsService.Add(news);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);

        }
        [Authorize]
        [HttpPost("update")]
        public IActionResult Update(NewsDto news)
        {
            var result = _newsService.Update(news);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);

        }
        [Authorize]
        [HttpPost("delete")]
        public IActionResult Delete(NewsDto news)
        {
            var result = _newsService.Delete(news);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);

        }
        [Authorize]
        [HttpPost("publishNews")]
        public IActionResult publishNews(int newsId)
        {
            var result = _newsService.ChangePublishState(newsId,true);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);

        }
        [Authorize]
        [HttpPost("unPublishNews")]
        public IActionResult unPublishNews(int newsId)
        {
            var result = _newsService.ChangePublishState(newsId, false);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);

        }
    }
}
