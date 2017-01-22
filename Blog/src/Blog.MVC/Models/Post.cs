using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.MVC.Models
{
    public class Post
    {
        public Post()
        {
            Author = new ApplicationUser();
            PostTags = new List<PostTag>();
        }
        public int ID { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Text { get; set; }
        public DateTime createDate { get; set; }
        public ApplicationUser Author { get; set; }
        public List<PostTag> PostTags { get; set; }
    }
}
