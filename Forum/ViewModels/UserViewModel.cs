using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Forum.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Display(Name = "User name")]
        public string UserName { get; set; }
        public string Role { get; set; }
    }
}