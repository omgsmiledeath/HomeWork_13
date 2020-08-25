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
        private Bank<Client> bank = new Bank<Client>();
        //private Bank<CreditAccount> bank2 = new Bank<CreditAccount>();
        Clients clients;
        Clients clients2;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            double i = 100_000;
            bank.AddAccount(new Client("111","222","8800223535"));
            bank.AddAccount(new Client("111", "222", "8800223535"));
            bank.AddAccount(new Client("111", "222", "8800223535"));
            bank.AddAccount(new Client("111", "222", "8800223535"));
            bank.AddAccount(new Client("111", "222", "8800223535"));
            bank.AddAccount(new Client("111", "222", "8800223535"));
            bank.AddAccount(new Client("111", "222", "8800223535"));
            bank.AddAccount(new Client("111", "222", "8800223535"));


            clients = new Clients(bank.AccountList);
            bank.AccountList[0].Phone_number = "888";

            clients2 = new Clients(bank.AccountList);
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
