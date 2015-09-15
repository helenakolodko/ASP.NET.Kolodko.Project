using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Forum.ViewModels
{
    public class CommentViewModel
    {
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
        public UserViewModel Author { get; set; }
        public TopicViewModel Topic { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }
        public int Raiting { get; set; }
    }
}