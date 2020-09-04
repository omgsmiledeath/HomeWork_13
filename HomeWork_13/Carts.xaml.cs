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
        public Carts()
        {
            InitializeComponent();
        }

        public Carts(Client client) :base()
        {
            InitializeComponent();
           // client.Carts.Add(new SaveAccount(123123,6));
            CartListGrid.ItemsSource= client.Carts;
        }
    }
}
