﻿using System;
using System.Collections.Generic;

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
        public string url { get; set; }
        public string imgUrl { get; set; }
        public DateTime createDate { get; set; }
        public ApplicationUser Author { get; set; }
        public List<PostTag> PostTags { get; set; }

    }
}
