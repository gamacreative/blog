using System.Collections.Generic;

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
