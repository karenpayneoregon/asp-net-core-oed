using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo1.Mocked;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Demo1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public string TimeOfDay() =>
            DateTime.Now.Hour switch
            {
                <= 12 => "Morning",
                <= 16 => "Afternoon",
                <= 20 => "Evening",
                _ => "Good Night"
            };

        public CurrentUser CurrentUser() => 
            new () { UserName = "Karen", Pin = "1234" };

        public List<string> TeamMembers => new() { "Bill", "Bick", "Lisa", "Karen", "Lindon", "Garen" };
    }
}
