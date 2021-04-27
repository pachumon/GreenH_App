using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GreenwayCoding.Utilities;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace GreenwayCodingTest.Pages
{
    public class LetterCountModel : PageModel
    {
        [BindProperty]
        public string ContentText { get; set; }
        [BindProperty]
        public List<string> LetterCountCol { get; set; }
        
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {         

            if (!string.IsNullOrWhiteSpace(ContentText))
            {
                var sanitizedContent = ContentText.ToSanitizedContent(new List<string> { "\"", "&quot;" }, "");
                var Charcollection = sanitizedContent.ToCharArray().                     
                     GroupBy(x => x).
                     Select(x => new { value = x.Key, Count = x.Count() }).ToList();
                LetterCountCol = Charcollection.
                    Select(x => $"{x.value.ToString().ToUpper()} = {x.Count}").ToList();
            }
            return Page();

        }
    }
}
