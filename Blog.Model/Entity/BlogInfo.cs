using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.Model.Entity
{
    public class BlogInfo
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(500)]
        public string Abstr { get; set; }
        public DateTime CreateTime { get; set; }
        [MaxLength(500)]

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public BContent Content { get; set; }

    }
}
