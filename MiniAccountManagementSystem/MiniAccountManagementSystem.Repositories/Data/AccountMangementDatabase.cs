using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using MiniAccountManagementSystem.Repositories.Abstractions.Data;

namespace MiniAccountManagementSystem.Repositories.Data
{
   public  class AccountMangementDatabase:IAccountMangementDatabase
    {
        private readonly string _connectionString;
        public AccountMangementDatabase(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
