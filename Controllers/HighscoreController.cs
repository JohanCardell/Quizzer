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
using Newtonsoft.Json;

namespace Quizzer.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class HighscoreController : ControllerBase
    {
        private readonly ILogger<HighscoreController> _logger;
        private readonly QuizDbContext _quizDb;

        public HighscoreController(ILogger<HighscoreController> logger, QuizDbContext quizDb)
        {
            _logger = logger;
            _quizDb = quizDb;
        }

        [HttpGet]
        public async Task<IEnumerable<ScoreEntry>> GetAsync()
        {
            var leaderBoard = await _quizDb.ScoreEntries.ToListAsync();
            var sortedLeaderboard = leaderBoard.OrderByDescending( se => se.Score).ThenByDescending (se => se.EntryDate).Take(10);
            return sortedLeaderboard;

        }

        [HttpPost]
        public IActionResult InsertScore([FromBody]ScoreEntry json)
        {
            try
            {
                json.EntryDate = DateTime.UtcNow;
                _quizDb.ScoreEntries.Add(json);
                _quizDb.SaveChanges();

                return StatusCode(200, "All good");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside InsertScore action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
