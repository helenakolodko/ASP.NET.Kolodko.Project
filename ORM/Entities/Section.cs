using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Entities
{
    [Table("Sections")] 
    public partial class Section
    {
        public Section()
        {
            Topics = new HashSet<Topic>();                
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Info { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }
    }
}
