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
        [Display(Name = "User name")]
        public UserViewModel Author { get; set; }
        public SectionViewModel Section { get; set; }

        [Display(Name = "Date Added")]        
        public DateTime DateAdded { get; set; }
        public int Raiting { get; set; }
    }
}                                               
