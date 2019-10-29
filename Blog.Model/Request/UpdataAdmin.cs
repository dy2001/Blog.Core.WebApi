using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Model.Request
{
    public class UpdataAdmin
    {
        public string Password { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
    }
}
