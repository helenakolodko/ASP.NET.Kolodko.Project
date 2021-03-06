﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Forum.ViewModels
{
    public class TopicViewModel
    {
        public string Name { get; set; }
        public string Text { get; set; }

        [Display(Name = "User name")]
        public UserViewModel Author { get; set; }
        public SectionHeaderViewModel Section { get; set; }

        [Display(Name = "Date Added")]        
        public DateTime DateAdded { get; set; }

        [UIHint("Raiting")]
        public int Raiting { get; set; }
    }
}                                               
