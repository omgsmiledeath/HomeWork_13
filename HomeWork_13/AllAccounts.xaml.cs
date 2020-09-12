using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using HomeWork_13.Models;
namespace HomeWork_13
{
    /// <summary>
    /// Логика взаимодействия для AllAccounts.xaml
    /// </summary>
    public partial class AllAccounts : Page
    {
        private Account inAcc;
        private Account outAcc;

        public AllAccounts()
        {
            InitializeComponent();
        }

        public AllAccounts(ObservableCollection<Account> allacc) :base()
        {
            InitializeComponent();
            CartListGrid2.ItemsSource = allacc;
        }

        private void TransactionOutputSelectButton_Click(object sender, RoutedEventArgs e)
        {
            if (CartListGrid2.SelectedItem != null)
            {
                inAcc = (Account)CartListGrid2.SelectedItem;

                OutCartBalanceTextBlock.Text = $"{inAcc.Balance}";
                OutCartNameTextBlock.Text = inAcc.CartNumber;
            }
        }

        private void TransactionInputSelectButton_Click(object sender, RoutedEventArgs e)
        {
            if (CartListGrid2.SelectedItem != null)
            {
                outAcc = (Account)CartListGrid2.SelectedItem;

                InCartBalanceTextBlock.Text = $"{outAcc.Balance}";
                InCartNameTextBlock.Text = outAcc.CartNumber;
            }
        }
    }
}
