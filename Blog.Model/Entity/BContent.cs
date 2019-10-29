using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.Model.Entity
{
    public class BContent
    {
        public int Id { get; set;}
        public string Content { get; set; }
        
        public int BlogId { get; set; }
        public BlogInfo Blog { get; set;}
    }
}
