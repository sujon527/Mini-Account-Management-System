using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAccountManagementSystem.DTO
{
   public class AccountDTO
    {
        public int AccountId { get; set; }

        [Required(ErrorMessage = "Account Name is required")]
        [StringLength(100)]
        public string AccountName { get; set; }

        public int? ParentAccountId { get; set; }
    }
}
