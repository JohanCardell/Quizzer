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
    public class ScoreController : ControllerBase
    {
        private readonly ILogger<QuizController> _logger;
        private readonly QuizDbContext _quizDb;

        public ScoreController(ILogger<QuizController> logger, QuizDbContext quizDb)
        {
            _logger = logger;
            _quizDb = quizDb;
        }

        [Route("./get")]
        [HttpGet]
        public async Task<IEnumerable<ScoreEntry>> GetAsync()
        {
            var leaderBoard = await _quizDb.ScoreEntries.Include(se => se.QuizPlayer).Take(10).ToListAsync();
            return leaderBoard.OrderBy(se => se.Score).ThenBy(se => se.EntryDate).ThenBy(se => se.QuizPlayer.UserName);
          
        }

        [HttpPut]

    }
}
