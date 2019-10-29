using Blog.Model.Request;
using Blog.Model.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service
{
    public class AdminService
    {
        private readonly SetData _context;

        public AdminService(SetData setData)
        {
            this._context = setData;
        }
        public async Task<ResponseModel> UpdateAdmin(UpdataAdmin admin)
        {
            var result = await _context.Admins.FirstOrDefaultAsync();
            result.Password = admin.Password;
            result.NickName = admin.NickName;
            result.Email = admin.Email;
            var i = await _context.SaveChangesAsync();
            if (i > 0)
                return new ResponseModel() { code = 200, result = "Admin信息修改成功", data = "" };
            else
                return new ResponseModel() { code = 0, result = "Admin信息修改失败", data = "" };
        }

        public async Task<ResponseModel> AdminList()
        {
            var result = await _context.Admins.FirstOrDefaultAsync();
            return new ResponseModel() { code = 200, result = "Admin信息获取成功", data = result };
        }
    }
}
