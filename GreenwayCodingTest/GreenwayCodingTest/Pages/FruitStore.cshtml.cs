using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GreenwayCoding.Utilities;
using GreenwayCoding.Services.Abstractions;
using GreenwayCoding.Models;

namespace GreenwayCodingTest.Pages
{
    public class FruitStoreModel : PageModel
    {
        private readonly IBillHandlerService _billHandlerService;
        public FruitStoreModel(IBillHandlerService billHandlerService)
        {
            _billHandlerService = billHandlerService;
        }
        [BindProperty]
        public string BillingDetailsText { get; set; }

        [BindProperty]
        public BillingInfo BillingInfo { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {

            if (!string.IsNullOrWhiteSpace(BillingDetailsText))
            {
                var billedItems = BillingDetailsText
                    .ToSanitizedContent(new List<string> { "[", "]" }, "")
                    .Split(',').Select(x=>x.Trim()).ToList();
                BillingInfo = _billHandlerService.GenerateBillForCart(billedItems);
                
            }
            return Page();
        }
    }
}
