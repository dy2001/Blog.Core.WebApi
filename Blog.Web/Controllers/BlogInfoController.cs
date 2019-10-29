using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Model.Request;
using Blog.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    public class BlogInfoController : Controller
    {
        private readonly BlogService _BlogService;
        public BlogInfoController(BlogService blogService)
        {
            this._BlogService = blogService;
        }

        /// <summary>
        /// 根据id获取blog
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetBlogById(int id)
        {
            var result = await _BlogService.GetBlogById(id);
            return Json(result);
        }
        /// <summary>
        /// 分页获取blog
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetBlog(int page, int size)
        {
            var result = await _BlogService.GetBlog(page,size);
            return Json(result);
        }
        /// <summary>
        /// 分页根据类别id获取blog
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetBlogByCategoryId(int page, int size,int categoryid)
        {
            var result = await _BlogService.GetBlogByCategoryId(page, size, categoryid);
            return Json(result);
        }

        /// <summary>
        /// 添加blog
        /// </summary>
        /// <param name="blog">blog</param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Blog(AddBlog blog)
        {
            var result = await _BlogService.AddBlog(blog);
            return Json(result);
        }

        /// <summary>
        /// 修改blog
        /// </summary>
        /// <param name="id">blogid</param>
        /// <param name="blog">blog</param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Blog(int id, AddBlog blog)
        {
            var result = await _BlogService.UpdateBlog(id, blog);
            return Json(result);
        }

        /// <summary>
        /// 删除blog
        /// </summary>
        /// <param name="id">类别id</param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> Blog(int id)
        {
            var result = await _BlogService.DeleteBlog(id);
            return Json(result);
        }
    }
}