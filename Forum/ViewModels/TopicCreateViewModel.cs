using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.ViewModels
{
    public class TopicCreateViewModel
    {
        [Required]
        [Display(Name = "Topic Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Content")]
        public string Text { get; set; }

        [Required]
        [Display(Name = "Section")]
        public SectionSelectViewModel Section { get; set; }
    }
}