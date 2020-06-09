using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Quizzer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quizzer.Data;

namespace Quizzer.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class QuizController : ControllerBase
    {
        private readonly ILogger<QuizController> _logger;
        private readonly QuizDbContext _quizDb;

        public QuizController(ILogger<QuizController> logger, QuizDbContext quizDb)
        {
            _logger = logger;
            _quizDb = quizDb;
        }

        [HttpGet]
        public async Task<IEnumerable<Question>> GetAsync()
        {
            var availableQuestions = await _quizDb.Questions.Include(q => q.Options).ToListAsync();
            var rng = new Random(DateTime.Now.Millisecond);
            var quiz = new List<Question>();
            for (int i = 0; i < 2; i++)
            {
                var question = availableQuestions.ElementAtOrDefault(rng.Next(0, 49));
                if (!quiz.Contains(question)) quiz.Add(question);
            }
            return quiz;
        }
    }
}
