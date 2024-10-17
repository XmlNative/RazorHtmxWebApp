using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorHtmxWebApp.Pages.HelloWorld
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }

        public PartialViewResult OnGetClickHere()
        {
            return Partial("_HelloWorld");
        }
    }
}
