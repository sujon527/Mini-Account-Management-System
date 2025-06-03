using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniAccountManagementSystem.DTO;
using MiniAccountManagementSystem.Repositories;

namespace MiniAccountManagementSystem.Handler
{
   public class AccountService
    {
        private readonly AccountRepository _repository;

        public AccountService(AccountRepository repository)
        {
            _repository = repository;
        }

        public List<AccountDTO> GetAllAccounts()
        {
            return _repository.GetAllAccounts();
        }

        public void CreateAccount(AccountDTO account)
        {
            _repository.ManageAccount(account, "CREATE");
        }

        public void UpdateAccount(AccountDTO account)
        {
            _repository.ManageAccount(account, "UPDATE");
        }

        public void DeleteAccount(int accountId)
        {
            var account = new AccountDTO { AccountId = accountId };
            _repository.ManageAccount(account, "DELETE");
        }
    }
}
