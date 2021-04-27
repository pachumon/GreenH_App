using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreenwayCoding.Models;
using GreenwayCoding.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GreenwayCodingTest.Pages
{
    public class TriviaGameModel : PageModel
    {
        private readonly ITriviaHandler _triviaHandler;

        [BindProperty]
        public TriviaInfo TriviaInfoCollection { get; set; }
        [BindProperty]
        public List<TriviaQuestion> TriviaQueries { get; set; }
        [BindProperty]
        public int CorrectAnswers { get; set; } = -1;
        //[BindProperty]
        //public List<TriviaQuestion> Question { get; set; }
        public TriviaGameModel(ITriviaHandler triviaHandler)
        {
            _triviaHandler = triviaHandler;
        }
        public void OnGet()
        {            
        }

        public void OnGetTrivia()
        {
            TriviaInfoCollection = _triviaHandler.RetrieveTriviaList();
            TriviaQueries = TriviaInfoCollection.TriviaQueryList;
            //Question = TriviaQueries.Take(2).ToList();
            CorrectAnswers = -1;
        }

        public void OnPostQuizsubmit()
        {
            foreach (var item in TriviaQueries)
            {
                if(item.CorrectAnswer.Equals(item.Option,StringComparison.InvariantCultureIgnoreCase))
                {
                    item.IsCorrect = true;
                }
            }
            CorrectAnswers = TriviaQueries.Where(x => x.IsCorrect == true).ToList().Count();
            TriviaQueries = null;
        }
    }
}
