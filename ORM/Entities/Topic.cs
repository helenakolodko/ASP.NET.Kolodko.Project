using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Entities
{
    [Table("Topics")] 
    public partial class Topic
    {
        public Topic()
        {
            Comments = new HashSet<Comment>();
            Votes = new HashSet<Vote>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")] 
        public virtual User Author { get; set; }

        [Required]
        public int SectionId { get; set; }

        [ForeignKey("SectionId")] 
        public virtual Section Section { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Vote> Votes { get; set; }
    }
}
