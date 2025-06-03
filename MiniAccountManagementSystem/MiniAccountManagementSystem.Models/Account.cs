using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAccountManagementSystem.Models
{
  public  class Account
    {
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public int? ParentAccountId { get; set; }
    }
}
