using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MiniAccountManagementSystem.Repositories;
using MiniAccountManagementSystem.DTO;  // for SelectListItem
// other using statements...
namespace MiniAccountMangementSystemController.Areas.Identity.Pages.Account;
public class EditModel : PageModel
{
    private readonly AccountRepository _accountRepo;

    public EditModel(AccountRepository accountRepo)
    {
        _accountRepo = accountRepo;
    }

    [BindProperty]
    public AccountDTO Account { get; set; }

    // Add this property for dropdown
    public List<SelectListItem> ParentAccounts { get; set; }

    public IActionResult OnGet(int id)
    {
        var accounts = _accountRepo.GetAllAccounts();
        Account = accounts.FirstOrDefault(a => a.AccountId == id);

        if (Account == null)
            return RedirectToPage("Index");

        // Prepare dropdown list items
        ParentAccounts = accounts
            .Where(a => a.AccountId != id)  // avoid selecting itself as parent
            .Select(a => new SelectListItem
            {
                Value = a.AccountId.ToString(),
                Text = a.AccountName
            })
            .ToList();

        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            // If invalid, reload the dropdown list so the page doesn't break on postback
            var accounts = _accountRepo.GetAllAccounts();
            ParentAccounts = accounts
                .Where(a => a.AccountId != Account.AccountId)
                .Select(a => new SelectListItem
                {
                    Value = a.AccountId.ToString(),
                    Text = a.AccountName
                })
                .ToList();

            return Page();
        }

        var result = _accountRepo.ManageAccount(Account, "Update");

        if (result)
            return RedirectToPage("Index");

        ModelState.AddModelError("", "Failed to update account.");
        return Page();
    }
}
