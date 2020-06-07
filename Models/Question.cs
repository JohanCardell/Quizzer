using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Quizzer.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        public string Text { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}
