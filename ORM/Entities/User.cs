using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Entities
{
    [Table("Users")]
    public partial class User
    {
        public User()
        {
            Messages = new HashSet<Message>();
            Topics = new HashSet<Topic>();
            Comments = new HashSet<Comment>();
            Roles = new HashSet<Role>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public int? UserInfoId { get; set; }

        [ForeignKey("UserInfoId")]
        public virtual UserInfo Info { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Topic> Topics { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    
    }
}
