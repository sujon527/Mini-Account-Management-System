using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MiniAccountManagementSystem.DTO;
using MiniAccountManagementSystem.Handler;

namespace MiniAccountMangementSystemController.Areas.Identity.Pages.Account
{
    public class CreateModel : PageModel
    {
        private readonly AccountService _accountService;

        public CreateModel(AccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty]
        public AccountDTO Account { get; set; }

        public List<SelectListItem> ParentAccountOptions { get; set; }

        public void OnGet()
        {
            LoadParentAccounts();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                LoadParentAccounts();
                return Page();
            }

            _accountService.CreateAccount(Account);

            return RedirectToPage("Index");
        }

        private void LoadParentAccounts()
        {
            var accounts = _accountService.GetAllAccounts();
            ParentAccountOptions = new List<SelectListItem>();

            foreach (var acc in accounts)
            {
                ParentAccountOptions.Add(new SelectListItem { Value = acc.AccountId.ToString(), Text = acc.AccountName });
            }
        }
    }
}
