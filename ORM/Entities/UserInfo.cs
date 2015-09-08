using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Entities
{
    [Table("UsersInfo")]
    public partial class UserInfo
    {
        [Key, ForeignKey("User")]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string About { get; set; }
        public DateTime? BirthDate { get; set; }
        public string AvatarPath { get; set; }

        public virtual User User { get; set; }
    }
}
