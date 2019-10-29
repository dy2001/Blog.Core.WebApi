using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CategoryController : Controller
    {
        private readonly CategoryService _CategoryService;
        public CategoryController(CategoryService categoryService)
        {
            this._CategoryService = categoryService;
        }

        /// <summary>
        /// 获取类别列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Category()
        {
            var result = await _CategoryService.CategoryList();
            return Json(result);
        }

        /// <summary>
        /// 添加类别
        /// </summary>
        /// <param name="name">类别名</param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Category(string name)
        {
            var result = await _CategoryService.AddCategory(name);
            return Json(result);
        }

        /// <summary>
        /// 修改类别
        /// </summary>
        /// <param name="id">类别id</param>
        /// <param name="name">新类别名</param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Category(int id,string name)
        {
            var result = await _CategoryService.UpdateCategory(id,name);
            return Json(result);
        }

        /// <summary>
        /// 删除类别
        /// </summary>
        /// <param name="id">类别id</param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> Category(int id)
        {
            var result = await _CategoryService.DeleteCategory(id);
            return Json(result);
        }
    }
}