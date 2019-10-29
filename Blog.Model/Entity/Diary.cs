using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.Model.Entity
{
    public class Diary
    {
        public int Id { get; set; }
        [MaxLength(500)]
        public string Content { get; set; }
        public string CreateTime { get; set; }
    }
}
