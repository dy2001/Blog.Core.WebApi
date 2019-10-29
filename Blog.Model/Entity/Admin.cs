using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.Model.Entity
{
    public class Admin
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string Account { get; set; }
        [MaxLength(20)]
        public string Password { get; set; }
        [MaxLength(20)]
        public string NickName { get; set; }
        [MaxLength(30)]
        public string Email { get; set; }
    }
}
