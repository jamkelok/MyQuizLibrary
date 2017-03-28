namespace QuizLibraryHost
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Question")]
    public partial class Question
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Question()
        {
            Answers = new HashSet<Answer>();
        }

        public int QuestionId { get; set; }

        [Required]
        [StringLength(100)]
        public string Category { get; set; }

        [Required]
        public string Content { get; set; }

        [StringLength(255)]
        public string ImageUrl { get; set; }

        [StringLength(255)]
        public string MoreInfoUrl { get; set; }

        [Required]
        [StringLength(50)]
        public string QuestionType { get; set; }

        public string ReasonForAnswer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
