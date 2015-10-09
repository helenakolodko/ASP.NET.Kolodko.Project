using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Forum.ViewModels
{
    public class TopicInfoViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Topic")]
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public string Author { get; set; }
        public int SectionId { get; set; }
        public string Section { get; set; }

        [Display(Name = "Date Added")]        
        public DateTime DateAdded { get; set; }
        public int Raiting { get; set; }
    }
}                                               
