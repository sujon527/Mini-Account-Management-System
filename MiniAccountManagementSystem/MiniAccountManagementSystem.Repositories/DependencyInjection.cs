using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiniAccountManagementSystem.Repositories.Abstractions.Data;
using MiniAccountManagementSystem.Repositories.Data;

namespace MiniAccountManagementSystem.Repositories
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddHiringActivityRepositories(this IServiceCollection Services, IConfiguration configuration)
        {

            string connectionString = configuration.GetConnectionString("AppConnectionString");

            Services.AddScoped<IAccountMangementDatabase>((provider) =>
            {
                return new AccountMangementDatabase(connectionString);
            });





            return Services;
        }
    }
}

