using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace Forum.ViewModels
{
    public class SectionSelectViewModel
    {
        private readonly IEnumerable<SectionHeaderViewModel> sections;
        public SectionSelectViewModel(IEnumerable<SectionHeaderViewModel> sections)
        {
            this.sections = sections;
        }

        [Display(Name = "Section")]
        public int SelectedSection { get; set; }

        public IEnumerable<SelectListItem> Sections
        {
            get { return new SelectList(sections, "Id", "Name"); }
        }
    }
}