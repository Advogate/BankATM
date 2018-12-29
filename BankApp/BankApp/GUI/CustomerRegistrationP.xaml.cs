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
using BankApp.MODAL;
using BankApp.DAL;

namespace BankApp.GUI
{
    /// <summary>
    /// Interaction logic for CustomerRegistration.xaml
    /// </summary>
    public partial class CustomerRegistrationP : Page
    {
        BankDbContext db = new BankDbContext();
        public CustomerRegistrationP()
        {
            InitializeComponent();
        }
        public void refresh()
        {
            accountBalanceTextBox.Clear();
            accountNameTextBox.Clear();
            accountNoTextBox.Clear();
            addressTextBox.Clear();
            ageTextBox.Clear();
            countryTextBox.Clear();
            customerRegIdTextBox.Clear();
            firstNameTextBox.Clear();
            lastNameTextBox.Clear();
            nextKinTextBox.Clear();
            phoneNoTextBox.Clear();
        }
        private void btn_Create_Click(object sender, RoutedEventArgs e)
        {
            Button bt = sender as Button;
            if (bt.Content.ToString() == "Create")
            {
                BankDetails bnktail = new BankDetails();
                bnktail.AccountBalance = int.Parse(accountBalanceTextBox.Text);
                bnktail.AccountName = accountNameTextBox.Text;
                bnktail.AccountNo = double.Parse(accountNoTextBox.Text);
                bnktail.AccountType = accountTypeComboBox.SelectionBoxItem.ToString();
                bnktail.CustomerRegId = customerRegIdTextBox.Text;
                

                CustomerReg reg = new CustomerReg();
                reg.AccountBalance = int.Parse(accountBalanceTextBox.Text);
                reg.AccountName = accountNameTextBox.Text;
                reg.AccountNo = double.Parse(accountNoTextBox.Text);
                reg.AccountType = accountTypeComboBox.SelectionBoxItem.ToString();
                reg.Address = addressTextBox.Text;
                reg.Age = int.Parse(ageTextBox.Text);
                reg.Country = countryTextBox.Text;
                reg.CustomerRegId = customerRegIdTextBox.Text;
                reg.DOB = DateTime.Parse(dOBDatePicker.SelectedDate.Value.ToShortTimeString());
                reg.FirstName = firstNameTextBox.Text;
                reg.LastName = lastNameTextBox.Text;
                reg.NextKin = nextKinTextBox.Text;
                reg.PhoneNo = double.Parse(phoneNoTextBox.Text);
                if (MessageBox.Show("Sure you want to Create", "Information", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    db.bnkdetails.Add(bnktail);
                    db.custreg.Add(reg);
                    db.SaveChanges();
                    MessageBox.Show("Account Created");
                    refresh();
                }
            }
            if (bt.Content.ToString() =="Update")
            {
                var bnkdtl = double.Parse(accountNoTextBox.Text);
                var UpdateDtail = (from s in db.bnkdetails where s.AccountNo == bnkdtl select s).SingleOrDefault();
                if (UpdateDtail != null)
                {
                    UpdateDtail.AccountBalance = int.Parse(accountBalanceTextBox.Text);
                    UpdateDtail.AccountName = accountNameTextBox.Text;
                    UpdateDtail.AccountNo = double.Parse(accountNoTextBox.Text);
                    UpdateDtail.AccountType = accountTypeComboBox.SelectionBoxItem.ToString();
                    UpdateDtail.CustomerRegId = customerRegIdTextBox.Text;
                    db.SaveChanges();
                }
               

                var account = double.Parse(accountNoTextBox.Text);
                var Update = (from s in db.custreg where s.AccountNo == account select s).SingleOrDefault();
                    Update.AccountBalance =double.Parse( accountBalanceTextBox.Text);
                    Update.AccountName = accountNameTextBox.Text;
                    Update.AccountNo =double.Parse( accountNoTextBox.Text);
                    Update.AccountType = accountTypeComboBox.Text;
                    Update.Address = addressTextBox.Text;
                    Update.Age =int.Parse( ageTextBox.Text);
                    Update.Country = countryTextBox.Text;
                    Update.CustomerRegId = customerRegIdTextBox.Text;
                    Update.DOB =DateTime.Parse( dOBDatePicker.SelectedDate.ToString());
                    Update.FirstName = firstNameTextBox.Text;
                    Update.LastName = lastNameTextBox.Text;
                    Update.NextKin = nextKinTextBox.Text;
                    Update.PhoneNo =double.Parse( phoneNoTextBox.Text);
                    if (MessageBox.Show("Sure you want to Update", "Information", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        db.SaveChanges();
                        MessageBox.Show("Account Updated");
                    }
            }
            
            if (bt.Content.ToString()=="Delete")
            {
                var account = double.Parse(accountNoTextBox.Text);
                var Delet = (from s in db.custreg where s.AccountNo == account select s).SingleOrDefault();
                if (MessageBox.Show("Sure you want to Delete", "Information",MessageBoxButton.YesNo)== MessageBoxResult.Yes)
                {
                    db.custreg.Remove(Delet);
                    db.SaveChanges();
                    MessageBox.Show("Account Deleted");
                    refresh();
                }
               
                
            }


        }

        private void accountNoTextBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            var account = double.Parse(accountNoTextBox.Text);
            var query = (from s in db.custreg where s.AccountNo == account select s).SingleOrDefault();
            if (query != null)
            {
                accountBalanceTextBox.Text = query.AccountBalance.ToString();
                accountNameTextBox.Text = query.AccountName;
                accountNoTextBox.Text = query.AccountNo.ToString();
                accountTypeComboBox.Text = query.AccountType;
                addressTextBox.Text = query.Address;
                ageTextBox.Text = query.Age.ToString();
                textBlock.Text = query.AccountType;
                accountTypeComboBox.Text = query.AccountType;
                countryTextBox.Text = query.Country;
                customerRegIdTextBox.Text = query.CustomerRegId;
                dOBDatePicker.SelectedDate = query.DOB;
                firstNameTextBox.Text = query.FirstName;
                lastNameTextBox.Text = query.LastName;
                nextKinTextBox.Text = query.NextKin;
                phoneNoTextBox.Text = query.PhoneNo.ToString();
            }
            else
            {
                if (MessageBox.Show("Invalid Account, Do you want to Create new Account", "Information", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                  
                }
                else
                    refresh();
            }

            
        }
    }
}
