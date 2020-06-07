using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Quizzer.Models;

namespace Quizzer.Controllers
{
    [Authorize]
    [ApiController]
    [Route("quiz")]
    public class QuizController : ControllerBase
    {
        private readonly ILogger<QuizController> _logger;

        public QuizController(ILogger<QuizController> logger)
        {
            _logger = logger;
        }

        //[HttpGet]
        //public IEnumerable<Quiz> Get()
        //{
        //    (using http)
        //}
    }
}
