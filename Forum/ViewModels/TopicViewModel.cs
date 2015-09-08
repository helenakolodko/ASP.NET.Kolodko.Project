using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Forum.ViewModels
{
    public class TopicViewModel
    {
        public int Id { get; set; }
        public UserViewModel Author { get; set; }
        // public virtual Section Section { get; set; }
        [Display(Name = "Date Added")]        
        public DateTime DateAdded { get; set; }
        // raiting
    }
}                                               
