using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.MVC.Models
{
    public class Lead
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string IP { get; set; }
        public int DownloadCount { get; set; }
    }
}
