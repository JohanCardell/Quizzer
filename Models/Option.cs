using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Quizzer.Models
{
    public class Option
    {
        [Key]
        public int Id { get; set; }
        public bool IsCorrect { get; set; } = false;
        public string Text { get; set; }
        [ForeignKey("QuestionId")]
        public virtual int QuestionId { get; set; }
    }
}
