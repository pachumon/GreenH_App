using GreenwayCoding.Models;
using GreenwayCoding.Services.Abstractions;
using GreenwayCoding.Utilities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace GreenwayCoding.Services
{
    public class TriviaHandler : ITriviaHandler
    {
        private readonly IWebRetrieverService _webRetrieverService;
        public TriviaHandler(IWebRetrieverService webRetrieverService)
        {
            _webRetrieverService = webRetrieverService;
        }

        public TriviaInfo RetrieveTriviaList()
        {
            var triviaInfo = new TriviaInfo();
            triviaInfo.TriviaQueryList = _webRetrieverService.GetTriviaQueryResponse().Result;

            foreach (var trivia in triviaInfo.TriviaQueryList)
            {
                trivia.IncorrectAnswer.Add(trivia.CorrectAnswer);
                trivia.IncorrectAnswer.Shuffle();
                trivia.IncorrectAnswer.Add("Select One");
                trivia.IncorrectAnswer.Reverse();
                trivia.AllOption = trivia.IncorrectAnswer.Select(x => new SelectListItem { Text = x, Value = x, Selected = false }).ToList<SelectListItem>();
                
            }

            return triviaInfo;
        }

        public TriviaInfo ValidateTriviaResponse(TriviaInfo triviaInfo)
        {
            return new TriviaInfo();
        }
    }
}
