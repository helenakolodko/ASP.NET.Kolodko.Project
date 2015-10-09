using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Forum.ViewModels
{
    public class TopicCreateViewModel
    {
        [Required]
        [Display(Name = "Topic Name")] 
        public string Name { get; set; }

        [Required]
        [Display(Name = "Content")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }

        [Required]
        [UIHint("SectionSelector")]
        public int Section { get; set; }
    }
}