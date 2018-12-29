using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.MODAL
{
    
    public class Journal
    {
        public int JournalId { get; set; }
        public double AccountNo { get; set; }
        public string AccountName { get; set; }
        public string AccountType { get; set; }
        public string OpType { get; set; }
        public double Amount { get; set; }

    }
}
