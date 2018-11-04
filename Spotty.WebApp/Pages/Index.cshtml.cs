﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Spotty.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private IAuthorization Authorization { get; }

        public IndexModel(IAuthorization authorization)
        {
            Authorization = authorization;
        }

        public async Task OnGetAuthorizationCallbackAsync(string code)
        {
            var token = await Authorization.GetTokenAsync(code).ConfigureAwait(false);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return Redirect(Authorization.GetRedirectUriForCode("app-remote-control").AbsoluteUri);
        }
    }
}
