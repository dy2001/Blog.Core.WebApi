using Blog.Model.Entity;
using Blog.Model.Request;
using Blog.Model.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service
{
    public class BlogService
    {
        private readonly SetData _context;

        public BlogService(SetData setData)
        {
            this._context = setData;
        }
        /// <summary>
        /// 添加Blog
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        public async Task<ResponseModel> AddBlog(AddBlog blog)
        {
            _context.Blogs.Add(new BlogInfo
            {
                Title = blog.Title,
                Abstr = blog.Abstr,
                CreateTime = DateTime.Now,
                CategoryId = blog.CategoryId,
                Content = new BContent { Content = blog.Content }
            });
            var i = await _context.SaveChangesAsync();
            if (i > 0)
                return new ResponseModel() { code = 200, result = "Blog添加成功", data = "" };
            else
                return new ResponseModel() { code = 0, result = "Blog添加失败", data = "" };
        }

        /// <summary>
        /// 修改blog
        /// </summary>
        /// <param name="id">blogId</param>
        /// <param name="blog"></param>
        /// <returns></returns>
        public async Task<ResponseModel> UpdateBlog(int id, AddBlog blog)
        {
            var result = await _context.Blogs.Include(x => x.Content).Where(x => x.Id == id).FirstOrDefaultAsync();
            result.Title = blog.Title;
            result.Abstr = blog.Abstr;
            result.CategoryId = blog.CategoryId;
            result.Content.Content = blog.Content;
            
            //_context.Update(result);
            var i = await _context.SaveChangesAsync();
            if (i > 0)
                return new ResponseModel() { code = 200, result = "Blog修改成功", data = "" };
            else
                return new ResponseModel() { code = 0, result = "Blog修改失败", data = "" };
        }

        /// <summary>
        /// 删除Blog
        /// </summary>
        /// <param name="id">blogId</param>
        /// <returns></returns>
        public async Task<ResponseModel> DeleteBlog(int id)
        {
            var result = await _context.Blogs.FindAsync(id);
            _context.Remove(result);
            var i = await _context.SaveChangesAsync();
            if (i > 0)
                return new ResponseModel() { code = 200, result = "Blog删除成功", data = "" };
            else
                return new ResponseModel() { code = 0, result = "Blog修删除失败", data = "" };

        }

        public async Task<ResponseModel> GetBlogById(int id)
        {
            var result = await _context.Blogs
                .Include(x => x.Content)
                .Include(x=>x.Category)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            var data = new Model.Response.Blog {
                Id = result.Id,
                Title = result.Title,
                Abstr = result.Abstr,
                CreateTime=result.CreateTime,
                CategoryId=result.CategoryId,
                Category = result.Category.CategoryName,
                Content = result.Content.Content
            };
            if (result!=null)
                return new ResponseModel() { code = 200, result = "Blog获取成功", data = data };
            else
                return new ResponseModel() { code = 0, result = "Blog修获取失败", data = ""  };
        }

        public async Task<ResponseModel> GetBlog(int page,int size)
        {
            var result = await _context.Blogs
                .Include(x => x.Content)
                .Include(x => x.Category)
                .OrderByDescending(x=>x.CreateTime)
                .Skip((page-1)*size)
                .Take(size)
                .ToListAsync();
            List<Model.Response.Blog> data = new List<Model.Response.Blog>();
            foreach (var item in result)
            {
                data.Add(new Model.Response.Blog {
                    Id = item.Id,
                    Title = item.Title,
                    Abstr = item.Abstr,
                    CreateTime = item.CreateTime,
                    Category = item.Category.CategoryName,
                    Content = item.Content.Content
                });
            }
            if (result != null)
                return new ResponseModel() { code = 200, result = "Blog获取成功", data = data };
            else
                return new ResponseModel() { code = 0, result = "Blog修获取失败", data = "" };
        }

        public async Task<ResponseModel> GetBlogByCategoryId(int page, int size,int categoryid)
        {
            var result = await _context.Blogs
                .Include(x => x.Content)
                .Include(x => x.Category)
                .Where(x=>x.CategoryId==categoryid)
                .OrderByDescending(x => x.CreateTime)
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync();
            List<Model.Response.Blog> data = new List<Model.Response.Blog>();
            foreach (var item in result)
            {
                data.Add(new Model.Response.Blog
                {
                    Id = item.Id,
                    Title = item.Title,
                    Abstr = item.Abstr,
                    CreateTime = item.CreateTime,
                    Category = item.Category.CategoryName,
                    Content = item.Content.Content
                });
            }
            if (result != null)
                return new ResponseModel() { code = 200, result = "Blog获取成功", data = data };
            else
                return new ResponseModel() { code = 0, result = "Blog修获取失败", data = "" };
        }
    }
}
