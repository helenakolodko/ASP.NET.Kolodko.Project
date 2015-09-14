using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public UserViewModel Author { get; set; }
        public TopicViewModel Topic { get; set; }
        public DateTime DateAdded { get; set; }
        public int Raiting { get; set; }
    }
}