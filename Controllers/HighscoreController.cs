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
        private readonly ILogger<QuizController> _logger;
        private readonly QuizDbContext _quizDb;

        public HighscoreController(ILogger<QuizController> logger, QuizDbContext quizDb)
        {
            _logger = logger;
            _quizDb = quizDb;
        }

        [HttpGet]
        public async Task<IEnumerable<ScoreEntry>> GetAsync()
        {
            var leaderBoard = await _quizDb.ScoreEntries.Include(se => se.QuizPlayer).ToListAsync();
            var whatever = leaderBoard.OrderBy(se => se.Score).ThenBy(se => se.EntryDate).ThenBy(se => se.QuizPlayer.UserName).Take(10);
            foreach (var item in whatever)
            {
                Console.WriteLine("scores "+ item.Score);
            }
            return whatever;

        }

        [HttpPost]
        public IActionResult InsertScore([FromBody]string Json)
        {
            Console.WriteLine(Json);
            var definition = new { userName = "", score = 0 };
            var deserializedData = JsonConvert.DeserializeAnonymousType(Json, definition);
            Console.WriteLine(deserializedData.userName + " scored " + deserializedData.score.ToString());
            try
            {
                var userEntity = _quizDb.Players.FirstOrDefaultAsync(p => p.UserName == deserializedData.userName).Result;
                var scoreEntity = new ScoreEntry
                {
                    QuizPlayerId = userEntity.Id,
                    EntryDate = DateTime.Today,
                    Score = deserializedData.score
                };
                _quizDb.ScoreEntries.AddAsync(scoreEntity);
                _quizDb.SaveChangesAsync();

                return StatusCode(200);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside InsertScore action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
