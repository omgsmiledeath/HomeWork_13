using HomeWork_13.Models;
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

namespace HomeWork_13
{
    /// <summary>
    /// Логика взаимодействия для Clients.xaml
    /// </summary>
    public partial class Clients: Page 
       
    {
        private ObservableCollection<SaveAccount> accounts = new ObservableCollection<SaveAccount>();
        private ObservableCollection<CreditAccount> accounts2 = new ObservableCollection<CreditAccount>();
        public Clients()
        {
            InitializeComponent();
            
        }

        public Clients(ObservableCollection<SaveAccount> accountlist) : base()
        {
            InitializeComponent();
            this.accounts = accountlist;

            AccountListGrid.ItemsSource = accounts;
        }
        public Clients(ObservableCollection<CreditAccount> accountlist) : base()
        {
            InitializeComponent();
            this.accounts2 = accountlist;
            AccountListGrid.ItemsSource = accounts2;

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
           
        }
    }
}
