using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13.Models
{
    public abstract class Client  

    {
        static long id_count;

        static Client()
        {
            id_count=0;
        }

        private long id;
        private string client_full_name;
        private string address;
        private string phone_number;
        protected double loyality;
        private ObservableCollection<Account> carts;


        public long Id { get => id; }
        public string Client_full_name { get => client_full_name; set => client_full_name = value; }
        public string Address { get => address; set => address = value; }
        public string Phone_number { get => phone_number; set => phone_number = value; }
        public ObservableCollection<Account> Carts { get => carts;  }

        public Client(string name,string addr,string phone)
        {
            Client_full_name = name;
            Address = addr;
            Phone_number = phone;
            id = ++id_count;
            carts = new ObservableCollection<Account>();
        }

        public bool OpenDebit()
        {
            foreach(var el in Carts)
            {
                if (el is SaveAccount) return false;
            }
            return true;
        }

        public bool OpenCredit()
        {
            foreach (var el in Carts)
            {
                if (el is CreditAccount) return false;
            }
            return true;
        }

    }



    
}
