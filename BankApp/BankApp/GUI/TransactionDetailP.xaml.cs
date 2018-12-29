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

namespace BankApp.GUI
{
    
    /// <summary>
    /// Interaction logic for TransactionDetail.xaml
    /// </summary>
    public partial class TransactionDetailP : Page
    {
        BankDbContext db = new BankDbContext();
        public TransactionDetailP()
        {
            InitializeComponent();
        }

        private void transactionListView_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void transactionListView_Loaded_1(object sender, RoutedEventArgs e)
        {
            db.transact.Load();
            transactionListView.ItemsSource = db.transact.ToList();
        }
    }
}
