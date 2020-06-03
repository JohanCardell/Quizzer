using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizzer.Models
{
    public class ScoreEntry
    {
        public QuizPlayer QuizPlayer { get; set; }

        public string QuizPlayerId { get; set; }

        public int Score { get; set; }
    }
}
