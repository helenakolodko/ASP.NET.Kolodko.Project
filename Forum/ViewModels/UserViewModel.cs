using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Forum.ViewModels
{
    public class UserViewModel
    {
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Display(Name = "E-Mail")]
        public string Email { get; set; }

        [Display(Name = "Registration date")]
        public DateTime DateAdded { get; set; }

        // public List<RoleViewModel> Roles { get; set; }
    }
}