using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.MODAL
{
    public class CustomerReg
    {
        public string CustomerRegId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double AccountNo { get; set; }
        public double AccountBalance { get; set; }
        public string AccountName { get; set; }
        public string AccountType { get; set; }
        public int Age { get; set; }
        public DateTime DOB { get; set; }
        public double PhoneNo { get; set; }
        public string NextKin { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
    }
}
