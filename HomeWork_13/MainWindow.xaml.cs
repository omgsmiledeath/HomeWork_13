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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Bank<Business> bank = new Bank<Business>();
        private Bank<VipClient> bank2 = new Bank<VipClient>();

        Clients clients;
        Clients clients2;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            double i = 100_000;
            bank.AddAccount(new Business("111","222","8800223535","Vasia","OAO"));
            bank.AddAccount(new Business("111", "222", "8800223535", "Vasia", "OAO"));
            bank.AddAccount(new Business("111", "222", "8800223535", "Vasia", "OAO"));
            bank.AddAccount(new Business("111", "222", "8800223535", "Vasia", "OAO"));
            bank.AddAccount(new Business("111", "222", "8800223535", "Vasia", "OAO"));
            bank.AddAccount(new Business("111", "222", "8800223535", "Vasia", "OAO"));
            bank.AddAccount(new Business("111", "222", "8800223535", "Vasia", "OAO"));
            bank.AddAccount(new Business("111", "222", "8800223535", "Vasia", "OAO"));


            clients = new Clients(bank.AccountList);
            
           
            bank2.AddAccount(new VipClient("77", "222", "8800223535"));
            clients2 = new Clients(bank2.AccountList);
            MainFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            MainFrame.Content = clients;
           // MainFrame.Navigate(clients);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            MainFrame.Content = clients2;
        }
    }
}
