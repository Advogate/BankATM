using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BankApp.MODAL;

namespace BankApp.DAL
{
    public class BankDbContext:DbContext
    {
        public DbSet<CustomerReg> custreg { get; set; }
        public DbSet<BankDetails> bnkdetails { get; set; }
        public DbSet<Journal> journal { get; set; }
        public DbSet<Transaction> transact { get; set; }
    }
}
