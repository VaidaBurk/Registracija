using Microsoft.EntityFrameworkCore;
using Registracija.Models;

namespace Registracija.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Registration> Registrations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>()
                .HasMany(q => q.Answers)
                .WithOne(a => a.Question);

            modelBuilder.Entity<Registration>()
                .HasKey(r => new { r.RegId, r.QuestionId, r.AnswerId });

            modelBuilder.Entity<Registration>()
                .HasOne(r => r.Question)
                .WithMany().HasForeignKey(r => r.QuestionId);

            modelBuilder.Entity<Registration>()
                .HasOne(r => r.Answer)
                .WithMany().HasForeignKey(r => r.AnswerId);
        }
    }
}
