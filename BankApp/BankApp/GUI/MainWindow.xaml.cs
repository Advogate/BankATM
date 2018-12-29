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
using BankApp.GUI;

namespace BankApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        
        private void btn_ClkCusReg_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new CustomerRegistrationP();
        }

        private void btn_ClkOps_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new OperationP();
        }

        private void btn_ClkJournal_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new JournalP();
        }

        private void btn_ClkTransDetail_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new TransactionDetailP();
        }

        private void btn_ClkBnkTail_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new BankDetailsP();
        }

        private void Main_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
