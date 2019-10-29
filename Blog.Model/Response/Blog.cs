using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Model.Response
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Abstr { get; set; }
        public DateTime CreateTime { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }

        public string Content { get; set; }
    }
}
