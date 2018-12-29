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

namespace BankApp.GUI
{
    /// <summary>
    /// Interaction logic for Journal.xaml
    /// </summary>
    public partial class JournalP : Page
    {
        BankDbContext db = new BankDbContext();
        public JournalP()
        {
            InitializeComponent();
        }

        private void customerRegListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void accountNoTextBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            var accTxt =double.Parse( accountNoTextBox.Text);
            var query = (from s in db.custreg where s.AccountNo == accTxt select s).SingleOrDefault();
            if (query != null)
            {
                accountNameTextBox.Text = query.AccountName;
                accountTypeTextBox.Text = query.AccountType;

            }
        }

        private void btn_SubmitJnl_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem cm = sender as ComboBoxItem;
            var accTxt = double.Parse(accountNoTextBox.Text);
            var query = (from s in db.custreg where s.AccountNo == accTxt select s).SingleOrDefault();
            if (query != null)
            {
                if (opTypeComboBox.SelectionBoxItem.ToString() == "Debit")
                {
                    query.AccountBalance = double.Parse(amountTextBox.Text);
                    MessageBox.Show("Debit");
                }
                else if (opTypeComboBox.SelectionBoxItem.ToString() == "Credit")
                {
                    query.AccountBalance += double.Parse(amountTextBox.Text);
                    MessageBox.Show("credit");
                }

            }
            
          
        }
    }
}
