using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GreenwayCoding.Models
{
    public class TriviaQuestion
    {
        [JsonProperty("category")]
        public string Category { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("difficulty")]
        public string Difficulty { get; set; }
        [JsonProperty("question")]
        public string Question { get; set; }
        [JsonProperty("correct_answer")]
        public string CorrectAnswer { get; set; }
        [JsonProperty("incorrect_answers")]
        public List<string> IncorrectAnswer { get; set; }
        public IEnumerable<SelectListItem> AllOption { get; set; }
        public string Option { get; set; }
        public bool IsCorrect { get; set; } = false;
    }
}
