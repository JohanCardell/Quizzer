using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizzer.Models
{
    public class Quiz
    {
        public int response_code { get; set; }

        public List<Question> results { get; set; }
    }
}

