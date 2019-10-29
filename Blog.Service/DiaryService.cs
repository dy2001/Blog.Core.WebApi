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
    public class DiaryService
    {
        private readonly SetData _context;

        public DiaryService(SetData setData)
        {
            this._context = setData;
        }

        public async Task<ResponseModel> AddDiary(string Content)
        {
            _context.Diarys.Add(new Diary { Content = Content, CreateTime = DateTime.Now.ToString() });
            var i = await _context.SaveChangesAsync();
            if (i > 0)
                return new ResponseModel() { code = 200, result = "日记添加成功", data = "" };
            else
                return new ResponseModel() { code = 0, result = "日记添加失败", data = "" };
        }

        public async Task<ResponseModel> DeleteDiary(int id)
        {
            var result = await _context.Diarys.FindAsync(id);
            _context.Diarys.Remove(result);
            var i = await _context.SaveChangesAsync();
            if (i > 0)
                return new ResponseModel() { code = 200, result = "日记删除成功", data = "" };
            else
                return new ResponseModel() { code = 0, result = "日记删除失败", data = "" };
        }

        public async Task<ResponseModel> UpdateDiary(int id, string Content)
        {
            var result = await _context.Diarys.FindAsync(id);
            result.Content = Content;
            var i = await _context.SaveChangesAsync();
            if (i > 0)
                return new ResponseModel() { code = 200, result = "日记修改成功", data = "" };
            else
                return new ResponseModel() { code = 0, result = "日记修改失败", data = "" };
        }

        public async Task<ResponseModel> DiarysList()
        {
            var result = await _context.Diarys.OrderByDescending(x => x.CreateTime).ToListAsync();
            return new ResponseModel() { code = 200, result = "日记获取成功", data = result };
        }
    }
}
