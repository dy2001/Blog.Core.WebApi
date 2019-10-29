using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.Model.Entity
{
    public class Category
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string CategoryName { get; set; }
        public DateTime CreateTime { get; set; }

        public List<BlogInfo> Blogs { get; set; }
    }
}
