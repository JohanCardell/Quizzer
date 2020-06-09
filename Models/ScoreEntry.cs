using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quizzer.Models
{
    public class ScoreEntry
    {
        public int Id { get; set; }
        public virtual ApplicationUser QuizPlayer { get; set; }

        public string QuizPlayerId { get; set; }

        public DateTime EntryDate { get; set; }

        public int Score { get; set; }
    }
}
