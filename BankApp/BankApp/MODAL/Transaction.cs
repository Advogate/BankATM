using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.MODAL
{
    public class Transaction
    {
        public int TransactionId {get; set;}
        //public string AccountType { get; set; }
        public string AccountName { get; set; }
        public double AccountNo { get; set; }
        public string AccoountType { get; set; }
        public double? DepositedAmount { get; set; }
        public double? WithdrawalAmount { get; set; }
        public double? TransferedAmount { get; set; }
        public double? RecipientAccNo { get; set; }
        public string RecipientBank { get; set; }
        public DateTime? DOJournalTime { get; set; }
        public DateTime? TransactionDate { get; set; }
        
    }
}
