using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;

namespace MiniAccountManagementSystem.Models
{
   public class ApplicationUser: IdentityUser<string>
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid().ToString(); // 🔐 Set the primary key manually
        }
        public string FullName { get; set; }
      
    }
}
