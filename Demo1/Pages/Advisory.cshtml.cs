using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo1.Pages
{
    public class AdvisoryModel : PageModel
    {
        public void OnGet()
        {
        }

        public List<string> Rules => new()
        {
            "By using this Online Claim System, you are consenting to having your responses to our questions become part of your claim record.",
            "This is an alternative to the Weekly Claim Line for individuals who have established their eligibility for unemployment insurance and wish to file their weekly report.",
            "You are responsible for the answers you give. We match the earnings you report with wages reported by your employers to verify the information you provide.",
            "False answers may result in overpaid benefits, which you must pay back. If you provide information that you know is false or misleading, or if you withhold information, it is considered fraud and is punishable by law.",
            "I understand that making the certification is under penalty of perjury and that intentional misrepresentation in order to obtain payments to which I am not entitled to receive may be subject to criminal prosecution."
        };
    }
}
