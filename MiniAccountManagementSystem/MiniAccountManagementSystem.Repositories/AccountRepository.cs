using System.Collections.Generic;
using System.Data;
using MiniAccountManagementSystem.DTO;
using MiniAccountManagementSystem.Repositories.Abstractions.Data;

namespace MiniAccountManagementSystem.Repositories
{
    public class AccountRepository
    {
        private readonly IAccountMangementDatabase _connectionFactory;

        public AccountRepository(IAccountMangementDatabase connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public List<AccountDTO> GetAllAccounts()
        {
            var accounts = new List<AccountDTO>();

            using (var con = _connectionFactory.CreateConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "sp_GetAccounts";
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        accounts.Add(new AccountDTO
                        {
                            AccountId = (int)reader["AccountId"],
                            AccountName = reader["AccountName"].ToString(),
                            ParentAccountId = reader["ParentAccountId"] as int?
                        });
                    }
                }
            }
            return accounts;
        }

        public bool ManageAccount(AccountDTO account, string action)
        {
            using (var con = _connectionFactory.CreateConnection())
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "sp_ManageChartOfAccounts2";
                cmd.CommandType = CommandType.StoredProcedure;

                var paramAccountId = cmd.CreateParameter();
                paramAccountId.ParameterName = "@AccountId";
                paramAccountId.Value = account.AccountId;
                cmd.Parameters.Add(paramAccountId);

                var paramAccountName = cmd.CreateParameter();
                paramAccountName.ParameterName = "@AccountName";
                paramAccountName.Value = account.AccountName ?? (object)DBNull.Value;
                cmd.Parameters.Add(paramAccountName);

                var paramParentAccountId = cmd.CreateParameter();
                paramParentAccountId.ParameterName = "@ParentAccountId";
                paramParentAccountId.Value = account.ParentAccountId.HasValue ? (object)account.ParentAccountId.Value : DBNull.Value;
                cmd.Parameters.Add(paramParentAccountId);

                var paramAction = cmd.CreateParameter();
                paramAction.ParameterName = "@Action";
                paramAction.Value = action;
                cmd.Parameters.Add(paramAction);

                con.Open();
                var rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0;
            }
        }
    }
}
