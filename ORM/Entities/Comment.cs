namespace ORM.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Comment()
        {
            CommentVotes = new HashSet<CommentVote>();
        }

        public int Id { get; set; }

        public int AuthorId { get; set; }

        public int TopicId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DateAdded { get; set; }

        [Required]
        public string Text { get; set; }

        public virtual User User { get; set; }

        public virtual Topic Topic { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CommentVote> CommentVotes { get; set; }
    }
}
