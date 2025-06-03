using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MiniAccountManagementSystem.DTO;
using MiniAccountManagementSystem.Handler;

namespace MiniAccountMangementSystemController.Identity.Pages.Account
{
    public class IndexModel : PageModel
    {
        private readonly AccountService _accountService;

        public IndexModel(AccountService accountService)
        {
            _accountService = accountService;
        }

        public List<AccountDTO> Accounts { get; set; }

        public void OnGet()
        {
            Accounts = _accountService.GetAllAccounts();
        }

        public string GetParentAccountName(int? parentId)
        {
            if (parentId == null) return "-";
            var parent = Accounts.Find(a => a.AccountId == parentId);
            return parent?.AccountName ?? "-";
        }
    }
}
