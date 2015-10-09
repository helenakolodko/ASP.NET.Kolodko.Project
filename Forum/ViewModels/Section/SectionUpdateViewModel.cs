using System;
using System.ComponentModel.DataAnnotations;

namespace Forum.ViewModels
{
    public class SectionUpdateViewModel
    {
        [Required]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; } 
    }
}