using Microsoft.EntityFrameworkCore;
using Quizzer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Quizzer.Data;
using Microsoft.Extensions.Logging;

namespace Quizzer
{
    public static class DbSeedHelper
    {
        private const string URL = "https://opentdb.com/api.php";
        private static string urlParameters = "?amount=50&type=multiple";
        private static List<Question> modelledQuestions = new List<Question>();
        private static List<Option> modelledOptions = new List<Option>();
      
        public static void Seed(this ModelBuilder modelBuilder)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(urlParameters).Result;

            // Retrieve questions and answers from API, then create objects based on EF models 
            if (response.IsSuccessStatusCode)
            {
                int questionIdCounter = 1;
                var resultCollection = (response.Content.ReadAsAsync<ResultCollection>().Result);

                foreach (var q in resultCollection.Results)
                {
                    //Console.WriteLine("{0}", q.Question.CleanSpecialChars());
                    //Console.WriteLine("Correct answer: {0}", q.CorrectAnswer);
                    //Console.WriteLine("Incorrect answers: {0}, {1}, {2}",
                    //    q.IncorrectAnswers[0].CleanSpecialChars(),
                    //    q.IncorrectAnswers[1].CleanSpecialChars(),
                    //    q.IncorrectAnswers[2].CleanSpecialChars());
                    //Console.WriteLine();

                    modelledQuestions.Add(new Question { Id = questionIdCounter, Text = q.Question.CleanSpecialChars() });
                    modelledOptions.Add(new Option { Id = (10 * questionIdCounter) + 1, QuestionId = questionIdCounter, IsCorrect = true,  Text = q.CorrectAnswer.CleanSpecialChars() });
                    modelledOptions.Add(new Option {Id = (10 * questionIdCounter) + 2, QuestionId = questionIdCounter, Text = q.IncorrectAnswers[0].CleanSpecialChars() });
                    modelledOptions.Add(new Option { Id = (10 * questionIdCounter) + 3, QuestionId = questionIdCounter, Text = q.IncorrectAnswers[1].CleanSpecialChars() });
                    modelledOptions.Add(new Option {Id = (10 * questionIdCounter) + 4, QuestionId = questionIdCounter, Text = q.IncorrectAnswers[2].CleanSpecialChars() });

                    questionIdCounter++;
                }
            }

            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            modelBuilder.Entity<Question>().HasData(modelledQuestions);
            modelBuilder.Entity<Option>().HasData(modelledOptions);
        }

        public static string CleanSpecialChars(this string str)
        {
            const string doubleQuote = "\"";
            const string singleQuote = "'";
            return str
                .Replace("&quot;", doubleQuote)
                .Replace("&#039;" , singleQuote)
                .Replace("&uuml;", "ü")
                .Replace("&ouml;", "ö")
                .Replace("&Ouml;", "Ö")
                .Replace("&eacute;", "é")
                .Replace("&ntilde;", "ñ");
        }
    }
}
