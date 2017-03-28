namespace QuizLibraryHost
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyQuizModel : DbContext
    {
        public MyQuizModel()
            : base("name=MyQuizModel")
            // Lokesh note : enabling LazyLoading
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        // Lokesh - end note

        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>()
                .HasMany(e => e.Answers)
                .WithRequired(e => e.Question)
                .WillCascadeOnDelete(true);
        }
    }
}
