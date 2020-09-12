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
        private Bank<Business> businessBank = new Bank<Business>(); //Отдел банка с бизнес клиентами
        private Bank<VipClient> vipBank = new Bank<VipClient>(); // Отдел банка с вип клиентами
        private Bank<Individual> individualBank = new Bank<Individual>(); // Отдел банка с обычными клиентами

        
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработка загрузки главного окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            individualBank.AddClient(new Individual("Петров В.С.", "Жопниково", "2281488"));
            individualBank.AddClient(new Individual("Шмальц Ы.А.", "Пидрово", "221323488"));
            businessBank.AddClient(new Business("Ростелеком", "валерград", "2281488","вася","пао"));
            vipBank.AddClient(new VipClient("Шмальц Ы.А.", "Пидрово", "221323488"));
            MainFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
        }

        /// <summary>
        /// Обработка нажатия кнопки открытия страницы с обычными клиентами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenIndividualClientsPage(object sender, RoutedEventArgs e)
        {
            
            MainFrame.Content = new Clients(individualBank.ClientList);
        }
        /// <summary>
        /// Обработка нажатия кнопки открытия страницы с бизнес клиентами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenBusinessClientsPage(object sender, RoutedEventArgs e)
        {
            
            MainFrame.Content = new Clients(businessBank.ClientList);
        }
        /// <summary>
        /// Обработка нажатия кнопки открытия страницы с вип клиентами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenVipClientsPage(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Clients(vipBank.ClientList);
        }

        private void OpenAllAccountsPage(object sender, RoutedEventArgs e)
        {
            var list = new ObservableCollection<Account>(individualBank.ClientList.SelectMany(t=>t.Carts)
                .Concat(businessBank.ClientList.SelectMany(t=>t.Carts))
                .Concat(vipBank.ClientList.SelectMany(t=>t.Carts))
                );
            
            MainFrame.Content = new AllAccounts(list);
        }
    }
}
