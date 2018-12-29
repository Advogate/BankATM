using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.MODAL
{
    public class BankDetails
    {
        public int BankDetailsId { get; set; }
        public string CustomerRegId { get; set; }
        public double AccountNo { get; set; }
        public double AccountBalance { get; set; }
        public string AccountName { get; set; }
        public string AccountType { get; set; }
        public string BankDebitBalance { get; set; }
    }
}
