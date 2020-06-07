using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizzer.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<ScoreEntry> ScoreEntries { get; set; }
    }
}
