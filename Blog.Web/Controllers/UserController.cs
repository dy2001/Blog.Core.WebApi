using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Blog.Model.Request;
using Blog.Model.Response;
using Blog.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Blog.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly AdminService _AdminService;
        private readonly IConfiguration _configuration;
        public UserController(AdminService adminService, IConfiguration configuration)
        {
            this._AdminService = adminService;
            this._configuration = configuration;
        }
        /// <summary>
        /// 登录获取token
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Login(string Account,string Password)
        {
            var result = await _AdminService.AdminList();
            if (result.data.Account == Account && result.data.Password == Password)
            {
                var claims = new[]
                {
                   new Claim(ClaimTypes.Name, result.data.NickName),
                   new Claim(ClaimTypes.Role,"Admin")
               };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                        issuer: "Deng_Blog_Web",
                        audience: "Deng_Blog_Web",
                        claims: claims,
                        expires: DateTime.Now.AddDays(10),
                        signingCredentials: creds);
                //return new JwtSecurityTokenHandler().WriteToken(token).ToString();
                return Json(new ResponseModel
                {
                    code = 200,
                    result = "登录成功",
                    data = new JwtSecurityTokenHandler().WriteToken(token).ToString()
                });
            }
            else
            {
                return Json(new ResponseModel
                {
                    code = 0,
                    result = "登录失败"
                });
            }
        }

        /// <summary>
        /// 获取管理员信息
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Admin()
        {
            var result = await _AdminService.AdminList();
            return Json(result);
        }


        /// <summary>
        /// 修改管理员信息
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Admin(UpdataAdmin admin)
        {
            var result = await _AdminService.UpdateAdmin(admin);
            return Json(result);
        }
    }
}