using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;

namespace MiniAccountManagementSystem.Models
{
   public class ApplicationRole: IdentityRole<string>
    {
     
        
            public string Description { get; set; }
            
        
    }
}
