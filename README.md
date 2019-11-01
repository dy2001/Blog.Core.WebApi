# Blog.Core.WebApi
这是一个前后端分离的个人博客系统，基于.Net Core 3.0+Vuejs打造。

[Blog.Core项目地址](https://github.com/dy2001/Blog.Core.WebApi)   	Blog WebApi项目（基于.NetCore 3.0开发）
[Blog.Admin项目地址](https://github.com/dy2001/blog_admin) 	Blog后台管理项目（基于VueJS开发）
[Blog.Vue项目地址](https://github.com/dy2001/blog_vue)		Blog前台项目（基于VueJS开发）
此系列项目代码、分层非常简单(代码逻辑一目了然)，很适合.Net Core初学者学习

## 如果你喜欢这个项目或者它帮助你, 请给一个 Star⭐

### 开发环境
- Windows10
- Visual Studio 2019
- (确保你电脑的.NET Core升级到了3.0)
### 使用技术
- ASP.NET Core 3.0
- ASP.NET Core WebApi
- JWT身份认证（JSON WEB TOKEN）
- Entity Framework Core
- NET Core 依赖注入
- Swagger UI
### 项目结构说明
- Blog.Model 模型层，用来放实体的model类
- Blog.Service 数据访问层，和数据库操作的类
- Blog.Web UI层+逻辑层 网页展示，逻辑内容 WebApi都在这里
### 如何调试这个项目
- 将这个项目Clone到本地
- 进入项目目录双击Blog.Core.sln（用VS打开项目）
- 进入Blog.Web这个目录修改appsettings.json的SqlServerConnection中的连接字符串为你的数据库连接字符串
```
  "ConnectionStrings": {
    "SqlServerConnection": "Server=192.168.215.128;database=Blog;uid=sa;pwd=Pass@Word;"
  }
```
再打开包管理控制台(Package Manager Console)，执行如下命令生成数据库表结构：
```
Update-Database
```
当然也可以不输，我已经配置的自动创建数据库
- 点击VS的启动按钮，再浏览器网址后添加/swagger/index.html即可成功运行项目
### 发布
​		VS中右键点击Blog.Web这个项目再点击发布跟流程走就行，然后把bin\Debug\netcoreapp3.0目录中的Blog.Web.xml这个文件拷贝的你发布的文件夹里
### 注意事项
Startup.cs文件里下面代码的.WithPlicy方法里的ip地址要有你前端项目的运行地址，不然前端请求api的时候会有跨域错误！
```
services.AddCors(c =>
            {
                //一般采用这种方法
                c.AddPolicy("LimitRequests", policy =>
                {
                    policy
                    .WithOrigins("http://localhost:8080","http://localhost:8081", "http://localhost:80")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
```