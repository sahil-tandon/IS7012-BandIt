using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreWiki.Pages
{
    public class FermiParadoxModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "Your Fermi Paradox Wiki page.";
        }
    }
}
