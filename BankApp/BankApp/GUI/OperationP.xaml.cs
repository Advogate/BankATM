using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BankApp.DAL;
using BankApp.MODAL;
using BankApp.GUI;

namespace BankApp.GUI
{
    
    /// <summary>
    /// Interaction logic for Operation.xaml
    /// </summary>
    public partial class OperationP : Page
    {
        
        BankDbContext db = new BankDbContext();
        public OperationP()
        {
            InitializeComponent();
        }

        private void accountNoTextBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            var account =double.Parse( accountNoTextBox1.Text);
            var query = (from s in db.custreg where s.AccountNo == account select s).SingleOrDefault();
            if (query != null)
            {
                accountBalanceTextBox1.Text = query.AccountBalance.ToString();
                accountNameTextBox1.Text = query.AccountName;
                AccType_txtBlk.Text = query.AccountType;
            }
            else
                MessageBox.Show("Invalid Account No");
           
        }
        
        
        private void e_Compute(object sender, RoutedEventArgs e)
        {
            Button bt = sender as Button;
            if (bt.Content.ToString() == "Deposit")
            {
                Transaction trans = new Transaction();

                trans.AccountNo = double.Parse(accountNoTextBox1.Text);
                trans.AccountName = accountNameTextBox1.Text;
                trans.AccoountType = AccType_txtBlk.Text;
                trans.DepositedAmount = double.Parse(txt_DepoAmount.Text);
                trans.TransactionDate = DateTime.UtcNow;
                db.transact.Add(trans);
                db.SaveChanges();

                var account = double.Parse(accountNoTextBox1.Text);
                var query = (from s in db.custreg where s.AccountNo == account select s).SingleOrDefault();
                query.AccountBalance += double.Parse( txt_DepoAmount.Text); 
                db.SaveChanges();
                MessageBox.Show("N" +txt_DepoAmount.Text + " was Deposited to your Account");
                accountBalanceTextBox1.Text =query.AccountBalance.ToString();
                var accDtl = double.Parse(accountNoTextBox1.Text);
                var queryDtl = (from s in db.bnkdetails where s.AccountNo == accDtl select s).SingleOrDefault();
                if (queryDtl != null)
                {
                    queryDtl.AccountBalance =double.Parse( accountBalanceTextBox1.Text);
                    db.SaveChanges();
                }
            }
            if (bt.Content.ToString() == "Withdraw")
            {
                Transaction trans = new Transaction();

                trans.AccountNo = double.Parse(accountNoTextBox1.Text);
                trans.AccountName = accountNameTextBox1.Text;
                trans.AccoountType = AccType_txtBlk.Text;
                trans.WithdrawalAmount = double.Parse(txt_Withdraw.Text);
                trans.TransactionDate = DateTime.UtcNow;
                db.transact.Add(trans);
                db.SaveChanges();

                var account = double.Parse(accountNoTextBox1.Text);
                var query = (from s in db.custreg where s.AccountNo == account select s).SingleOrDefault();
                query.AccountBalance -= double.Parse(txt_Withdraw.Text);
                db.SaveChanges();
                MessageBox.Show("N" + txt_Withdraw.Text + " was Withdrawn from your Account");
                accountBalanceTextBox1.Text = query.AccountBalance.ToString();
                var accDtl = double.Parse(accountNoTextBox1.Text);
                var queryDtl = (from s in db.bnkdetails where s.AccountNo == accDtl select s).SingleOrDefault();
                if (queryDtl != null)
                {
                    queryDtl.AccountBalance = double.Parse(accountBalanceTextBox1.Text);
                    db.SaveChanges();
                }

            }
            if (bt.Content.ToString() == "Transfer" )
            {
                Transaction trans = new Transaction();

                trans.AccountNo = double.Parse(accountNoTextBox1.Text);
                trans.AccountName = accountNameTextBox1.Text;
                trans.AccoountType = AccType_txtBlk.Text;
                trans.RecipientAccNo = double.Parse(txt_RecipAccNo.Text);
                trans.RecipientBank =RecipientBank_comboBox.SelectionBoxItem.ToString();
                trans.TransferedAmount = double.Parse(txt_RecipTransAmount.Text);
                trans.TransactionDate = DateTime.UtcNow;
                db.transact.Add(trans);
                db.SaveChanges();

                var account = double.Parse(accountNoTextBox1.Text);
                var query = (from s in db.custreg where s.AccountNo == account select s).SingleOrDefault();
                query.AccountBalance -= double.Parse(txt_RecipTransAmount.Text);
                db.SaveChanges();
                MessageBox.Show("N" + txt_RecipTransAmount.Text + " was transfered to "+ txt_RecipAccNo.Text);
                accountBalanceTextBox1.Text = query.AccountBalance.ToString();

                var accTxt = double.Parse(txt_RecipAccNo.Text);
                var transquery = (from s in db.custreg where s.AccountNo == accTxt select s).SingleOrDefault();
                if (transquery != null)
                {
                    transquery.AccountBalance +=double.Parse( txt_RecipTransAmount.Text);
                    db.SaveChanges();
                }
                //accountBalanceTextBox1.Text = transquery.AccountBalance.ToString();
                var accDtl = double.Parse(txt_RecipAccNo.Text);
                var queryDtl = (from s in db.bnkdetails where s.AccountNo == accDtl select s).SingleOrDefault();
                if (queryDtl != null)
                {
                    queryDtl.AccountBalance = double.Parse(accountBalanceTextBox1.Text);
                    db.SaveChanges();
                }
                var accDTrans = double.Parse(txt_RecipAccNo.Text);
                var queryTrans = (from s in db.bnkdetails where s.AccountNo == accDTrans select s).SingleOrDefault();
                if (queryTrans != null)
                {
                    queryDtl.AccountBalance += double.Parse(txt_RecipTransAmount.Text);
                    db.SaveChanges();
                }


            }
        }

        private void compute(object sender, RoutedEventArgs e)
        {

        }
    }
}
