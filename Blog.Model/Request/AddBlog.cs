using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Model.Request
{
    public class AddBlog
    {
        public string Title { get; set; }
        public string Abstr { get; set; }
        public int CategoryId { get; set; }
        public string Content { get; set; }
    }
}
