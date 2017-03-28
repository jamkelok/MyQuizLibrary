namespace QuizLibraryHost
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Answer")]
    public partial class Answer
    {
        public int AnswerId { get; set; }

        public int QuestionId { get; set; }

        public bool IsCorrect { get; set; }

        [Required]
        public string Content { get; set; }

        [StringLength(255)]
        public string ImageUrl { get; set; }

        public string Reason { get; set; }

        public virtual Question Question { get; set; }
    }
}
