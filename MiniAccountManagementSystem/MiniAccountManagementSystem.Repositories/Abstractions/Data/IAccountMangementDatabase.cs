using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAccountManagementSystem.Repositories.Abstractions.Data
{
    public interface IAccountMangementDatabase
    {
        IDbConnection CreateConnection();
    }
}
