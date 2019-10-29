using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Blog.Model.Response;
using Blog.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace Blog.Service
{
    public class CategoryService
    {
        private readonly SetData _context;

        public CategoryService(SetData setData)
        {
            this._context = setData;
        }

        /// <summary>
        /// 添加类别服务
        /// </summary>
        /// <param name="CategoryName">类别名</param>
        /// <returns></returns>
        public async Task<ResponseModel> AddCategory(string CategoryName)
        {
            _context.Categorys.Add(new Category { CategoryName = CategoryName, CreateTime = DateTime.Now });
            var i = await _context.SaveChangesAsync();
            if (i > 0)
                return new ResponseModel() { code = 200, result = "类别添加成功", data = "" };
            else
                return new ResponseModel() { code = 0, result = "类别添加失败", data = "" };
        }

        /// <summary>
        /// 修改类别名
        /// </summary>
        /// <param name="CategoryId">类别id</param>
        /// <param name="CategoryName">新类别名</param>
        /// <returns></returns>
        public async Task<ResponseModel> UpdateCategory(int CategoryId, string CategoryName)
        {
            var result = await _context.Categorys.FindAsync(CategoryId);
            result.CategoryName = CategoryName;
            var i = await _context.SaveChangesAsync();
            if (i > 0)
                return new ResponseModel() { code = 200, result = "类别修改成功", data = "" };
            else
                return new ResponseModel() { code = 0, result = "类别修改失败", data = "" };
        }

        /// <summary>
        /// 类别删除
        /// </summary>
        /// <param name="CategoryId">类别id</param>
        /// <returns></returns>
        public async Task<ResponseModel> DeleteCategory(int CategoryId)
        {
            var result = _context.Categorys.Find(CategoryId);
            _context.Remove(result);
            var i = await _context.SaveChangesAsync();
            if (i > 0)
                return new ResponseModel() { code = 200, result = "类别删除成功", data = "" };
            else
                return new ResponseModel() { code = 0, result = "类别删除失败", data = "" };
        }

        /// <summary>
        /// 返回类别列表
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseModel> CategoryList()
        {
            var result = await _context.Categorys.OrderBy(x => x.CreateTime).ToListAsync();
            //List<Category> categoryList = new List<Category>();
            //await Task.Run(() => {
            //    foreach (var item in result)
            //    {
            //        categoryList.Add(item);
            //    }
            //});
            return new ResponseModel() { code = 200, result = "类别获取成功", data = result };
        }

    }
}
