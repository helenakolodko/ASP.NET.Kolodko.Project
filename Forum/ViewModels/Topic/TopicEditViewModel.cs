using System;
using System.ComponentModel.DataAnnotations;


namespace Forum.ViewModels
{
    public class TopicEditViewModel
    {
        [Required]
        [Display(Name = "Topic Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Content")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
    }
}