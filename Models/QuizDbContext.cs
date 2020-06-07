using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Quizzer.Models
{
    public class QuizDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public QuizDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
            Database.EnsureCreated();
        }

        public DbSet<ApplicationUser> Players { get; set; }
        public DbSet<ScoreEntry> ScoreEntries { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .OwnsMany(qp => qp.ScoreEntries);
        }
    }
}