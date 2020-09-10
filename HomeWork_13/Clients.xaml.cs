﻿using HomeWork_13.Models;
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
        private ObservableCollection<Individual> individual = new ObservableCollection<Individual>(); //Список аккаунтов обычных клиентов
        private ObservableCollection<Business> bussines = new ObservableCollection<Business>(); //Список аккаунтов бизнес клиентов
        private ObservableCollection<VipClient> vip = new ObservableCollection<VipClient>(); //Список вип клиентов

        enum ClientTypes{
            Individual = 1,
            Business = 2, 
            Vip = 3
        }

        ClientTypes thisClientType;
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Clients()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Конструктор для отдела банка для работы с обычными клиентами
        /// </summary>
        /// <param name="accountlist"></param>
        public Clients(ObservableCollection<Individual> accountlist) : base()
        {
            InitializeComponent();
            this.individual = accountlist;
            this.thisClientType = ClientTypes.Individual;
            AccountListGrid.ItemsSource = individual;
            
        }
        /// <summary>
        /// Конструктор для отдела банка для работы с Бизнес клиентами
        /// </summary>
        /// <param name="accountlist"></param>
        public Clients(ObservableCollection<Business> accountlist) : base()
        {
            InitializeComponent();
            this.bussines = accountlist;
            this.thisClientType = ClientTypes.Business;
            AccountListGrid.ItemsSource = bussines;
           
        }
        /// <summary>
        /// Конструктор для отдела банка для работы с VipClient
        /// </summary>
        /// <param name="accountList"></param>
        public Clients(ObservableCollection<VipClient> accountList) :base()
        {
            InitializeComponent();

            this.vip = accountList;
            this.thisClientType = ClientTypes.Vip;
            AccountListGrid.ItemsSource = vip;
           
        }
        /// <summary>
        /// Правило для автосоздания стлобцов DataGrid 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void gridAutoGeneratedColumnsEvent(object sender,DataGridAutoGeneratingColumnEventArgs e)
        {

            string header = e.Column.Header.ToString();

            if(!String.IsNullOrWhiteSpace(header))
            {
                switch (header)
                {
                    case "Id":
                        e.Column.Header = "ID";
                        e.Column.DisplayIndex = 0;
                            break;
                    case "Client_full_name":
                        e.Column.Header = "ФИО";
                        e.Column.DisplayIndex = 1;
                        break;
                    case "Address":
                        e.Column.Header = "Адрес";
                        e.Column.DisplayIndex = 2;
                        break;
                    case "Phone_number":
                        e.Column.Header = "Телефон";
                        e.Column.DisplayIndex = 3;
                        break;
                    case "CompanyDirector":
                        e.Column.Header = "Директор";
                        e.Column.DisplayIndex = 4;
                        break;
                    case "Type":
                        e.Column.Header = "Форма";
                        e.Column.DisplayIndex = 5;
                        break;
                    default:
                        e.Column.Visibility = Visibility.Hidden;
                        break;

                }
            }
            
        }

        private void OpenCartInfo(object sender, RoutedEventArgs e)
        {
            var item = (Button)e.OriginalSource;
            Carts carts = new Carts((Client)item.DataContext);
            carts.Show();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
            switch (thisClientType)
            {
                case ClientTypes.Individual:
                    
                    break;
                case ClientTypes.Business:
                    break;
                case ClientTypes.Vip:
                    break;
            }
           
        }

        private void AddClientButton_Click(object sender, RoutedEventArgs e)
        {
            BottonGridLane.Height = new GridLength(0);
        }

        private void AddClientMenuItem_Click(object sender, RoutedEventArgs e)
        {
            BottonGridLane.Height = new GridLength(50);
        }
    }
}
