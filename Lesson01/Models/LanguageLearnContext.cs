namespace Lesson01.Models
{
    using System.Data.Entity;

    public partial class LanguageLearnContext : DbContext
    {
        public LanguageLearnContext()
            : base("name=cString")
        {
        }

        public virtual DbSet<BookletOfTalking> BookletOfTalking { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
