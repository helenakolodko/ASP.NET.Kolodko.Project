using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Forum.ViewModels
{
    public class TopicInfoViewModel
    {
        [Display(Name = "Topic")]
        public string Name { get; set; }
        public UserViewModel Author { get; set; }
        public SectionHeaderViewModel Section { get; set; }

        [Display(Name = "Date Added")]        
        public DateTime DateAdded { get; set; }
        public int Raiting { get; set; }
    }
}                                               
