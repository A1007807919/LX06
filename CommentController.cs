using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : Controller
    {
        [HttpGet] //获取用户数量
        public ActionResult Get()
        {
            return Json(DAL.Comment.Instance.GetCount());
        }
        // GET api/<controller>/5
        [HttpPut("{id}")]   //获取单用户数据
        public ActionResult get(int id)
        {
            return Json(DAL.Comment.Instance.GetWorkCount(id));
        }
        [HttpPost("page")]
        public ActionResult getpage([FromBody] Model.Page page)
        {
            var result = DAL.Comment.Instance.Getpage(page);
            if (result.Count() == 0)
                return Json(Result.Err("返回记录数为0"));
            else
                return Json(Result.Ok(result));
        }
        [HttpPost("workpage")]
        public ActionResult getworkpage([FromBody] Model.Commentpage page)
        {
            var result = DAL.Comment.Instance.Getpage(page);
            if (result.Count() == 0)
                return Json(Result.Err("返回记录数为0"));
            else
                return Json(Result.Ok(result));
        }
    }
}
