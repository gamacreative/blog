using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.MVC.Models
{
    public class Tag
    {
        public Tag()
        {
            PostTag = new List<PostTag>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public List<PostTag> PostTag { get; set; }
    }
}
