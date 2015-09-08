using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Entities
{
    [Table("Comments")]
    public partial class Comment
    {
        public Comment()
        {
            Votes = new HashSet<Vote>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public int TopicId { get; set; }

        [ForeignKey("TopicId")]
        public virtual Topic Topic { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User Author { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        public string Text { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
