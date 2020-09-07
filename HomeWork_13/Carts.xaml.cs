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
using System.Windows.Shapes;
using HomeWork_13.Models;


namespace HomeWork_13
{
    /// <summary>
    /// Логика взаимодействия для Carts.xaml
    /// </summary>
    public partial class Carts : Window
    {
        private Client currentClient; // Текущий клиент
        public Carts()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Перезагрузка конструктора
        /// </summary>
        /// <param name="client">Экземпляр клиента</param>
        public Carts(Client client) :base()
        {
            InitializeComponent();
           
            CartListGrid.ItemsSource= client.Carts;
            currentClient = client;

            
        }
        /// <summary>
        /// Действие по нажатию кнопки открытия сберегательного счета
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenSave_Click(object sender, RoutedEventArgs e)
        {
            if (currentClient.CheckAndOpenAccount(Account.AccountTypes.Debit, 100, 6))
                MessageBox.Show("Успех");
            else
                MessageBox.Show("Такой счет уже имеется");
        }

        /// <summary>
        /// Действие по нажатию кнопки открытия кредитного счета
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenCredit_Click(object sender, RoutedEventArgs e)
        {
            if (currentClient.CheckAndOpenAccount(Account.AccountTypes.Credit, 111, 6000000))
                MessageBox.Show("Успех");
            else
                MessageBox.Show("Такой счет уже имеется");
        }


        private void CartListGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (CartListGrid.Items.Count != 0 && CartListGrid.SelectedItem as Account != null )
                {
                    
                    var currAccount = (Account)CartListGrid.SelectedItem;
                    ListOfLogTransaction.ItemsSource = currAccount.LogTransaction.ToList();
                   
                }
            }
            catch
            {
                MessageBox.Show("Что то пошло не так");
            }
        }
    }
}
