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
    public class DiaryController : Controller
    {
        private readonly DiaryService _DiaryService;
        public DiaryController(DiaryService diarygService)
        {
            this._DiaryService = diarygService;
        }

        /// <summary>
        /// 获取日记列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Diary()
        {
            var result = await _DiaryService.DiarysList();
            return Json(result);
        }

        /// <summary>
        /// 添加日记
        /// </summary>
        /// <param name="content">类别名</param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Diary(string content)
        {
            var result = await _DiaryService.AddDiary(content);
            return Json(result);
        }

        /// <summary>
        /// 修改日记
        /// </summary>
        /// <param name="id">类别id</param>
        /// <param name="content">新类别名</param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Diary(int id, string content)
        {
            var result = await _DiaryService.UpdateDiary(id, content);
            return Json(result);
        }

        /// <summary>
        /// 删除日记
        /// </summary>
        /// <param name="id">类别id</param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> Diary(int id)
        {
            var result = await _DiaryService.DeleteDiary(id);
            return Json(result);
        }
    }
}