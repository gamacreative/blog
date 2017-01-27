namespace Blog.MVC.Models
{
    public class PostTag
    {
        public PostTag()
        {
            Post = new Post();
            Tag = new Tag();
        }
        public int PostID { get; set; }
        public int TagID { get; set; }

        public Post Post { get; set; }
        public Tag Tag { get; set; }
    }
}
