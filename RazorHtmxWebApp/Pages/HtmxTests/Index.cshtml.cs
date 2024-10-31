using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorHtmxWebApp.Pages.HtmxTests
{
    public class IndexModel : PageModel
    {
        readonly IAntiforgery _antiforgery;
        public string? RequestToken { get; set; }

        public Item? thisItem { get; private set; }
        public Item? thisItemNo { get; private set; }


        public IndexModel(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void OnGet()
        {
            var tokenSet = _antiforgery.GetAndStoreTokens(HttpContext);
            RequestToken = tokenSet.RequestToken;

            thisItem = new Item("An Item", "A Description", Guid.NewGuid());
            thisItemNo = new Item("An Item No", "A Description", Guid.NewGuid());
        }

        public PartialViewResult OnGetHtmxGet()
        {
            var myItem = new Item("Get", "Handler", Guid.NewGuid());
            return Partial("_HtmxResults", myItem);
        }

        public PartialViewResult OnGetHtmxGetNo()
        {
            var myItem = new Item("Get No", "No Handler", Guid.NewGuid());
            return Partial("_HtmxResults", myItem);
        }

        public PartialViewResult OnPostHtmxPost()
        {
            var myItem = new Item("Post", "Handler", Guid.NewGuid());
            return Partial("_HtmxResults", myItem);
        }

        public PartialViewResult OnPostHtmxPostNo()
        {
            var myItem = new Item("Post No", "No Handler", Guid.NewGuid());
            return Partial("_HtmxResults", myItem);
        }

        public PartialViewResult OnPostHtmxPostValues()
        {
            Microsoft.Extensions.Primitives.StringValues myValue;
            Request.Form.TryGetValue("valueString", out myValue);
            var myItem = new Item("Post Values: " + myValue, "No Handler value String", Guid.NewGuid());
            return Partial("_HtmxResults", myItem);
        }

        public PartialViewResult OnPostHtmxPostNoValues()
        {
            Microsoft.Extensions.Primitives.StringValues myValue;
            Request.Form.TryGetValue("valueString", out myValue);
            thisItem = new Item("Post No Values: " + myValue, "No Handler value String", Guid.NewGuid());
            return Partial("_HtmxResults", thisItem);
        }



        public IActionResult OnPostHtmxPostForm(Item model)
        {
            return Partial("_HtmxResults", model);
        }

        public IActionResult OnPostHtmxPostNoForm(Item model)
        {
            return Partial("_HtmxResults", model);
        }

    }
}
