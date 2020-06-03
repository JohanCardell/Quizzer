using Quizzer.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizzer.Data
{
    public class QuizDbContext : ApiAuthorizationDbContext<QuizPlayer>
    {
        public QuizDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
            Database.EnsureCreated();
        }

        public DbSet<QuizPlayer> QuizPlayers { get; set; }
        public DbSet<ScoreEntry> ScoreEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ScoreEntry>()
                .HasOne(se => se.QuizPlayer)
                .WithMany(qp => qp.ScoreEntries)
                .HasForeignKey(se => se.QuizPlayerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}