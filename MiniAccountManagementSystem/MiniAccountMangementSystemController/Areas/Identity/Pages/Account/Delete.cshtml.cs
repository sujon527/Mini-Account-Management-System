using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MiniAccountManagementSystem.DTO;
using MiniAccountManagementSystem.Repositories;
using System.Linq;

namespace MiniAccountMangementSystemController.Areas.Identity.Pages.Account
{
    public class DeleteModel : PageModel
    {
        private readonly AccountRepository _accountRepo;

        public DeleteModel(AccountRepository accountRepo)
        {
            _accountRepo = accountRepo;
        }

        [BindProperty]
        public AccountDTO Account { get; set; }

        public IActionResult OnGet(int id)
        {
            var accounts = _accountRepo.GetAllAccounts();
            Account = accounts.FirstOrDefault(a => a.AccountId == id);

            if (Account == null)
                return RedirectToPage("Index");

            return Page();
        }

        public IActionResult OnPost()
        {
            if (Account == null)
                return RedirectToPage("Index");

            var result = _accountRepo.ManageAccount(Account, "Delete");

            if (result)
                return RedirectToPage("Index");

            ModelState.AddModelError("", "Failed to delete account.");
            return Page();
        }
    }
}
