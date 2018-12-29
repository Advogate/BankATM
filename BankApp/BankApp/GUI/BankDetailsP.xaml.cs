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
using System.Data.Entity;
using BankApp.MODAL;

namespace BankApp.GUI
{
    /// <summary>
    /// Interaction logic for BankDetails.xaml
    /// </summary>
    public partial class BankDetailsP : Page
    {
        BankDbContext db = new BankDbContext();
        public BankDetailsP()
        {
            InitializeComponent();
        }

        private void bankDetailsListView_Loaded(object sender, RoutedEventArgs e)
        {
            db.bnkdetails.Load();
            bankDetailsListView.ItemsSource = db.bnkdetails.ToList();

             
        }

        private void btn_BDebit_Click(object sender, RoutedEventArgs e)
        {
            BankDetails bd = new BankDetails();
            var SumDebit = (from s in db.bnkdetails  select s.AccountBalance).Sum();
            BnkDebit_txt.Text = SumDebit.ToString();
            bd.BankDebitBalance = BnkDebit_txt.Text;
            db.SaveChanges();
        }
    }
}
