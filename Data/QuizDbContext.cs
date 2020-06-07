using Quizzer.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Quizzer.Data
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
            //modelBuilder.Entity<Question>().HasData(
            //    new Question
            //    {
            //        Id = 1,
            //        Text = "thohej",
            //    });

            //modelBuilder.Entity<Answer>().HasData(
            //    new Answer
            //    {
            //        Id = 1,
            //        Text = "hejsan",
            //        QuestionId = 1,
            //    });

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .OwnsMany(qp => qp.ScoreEntries);



            
        }
    }
}