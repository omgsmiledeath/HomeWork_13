using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13.Models
{
    public class Client  

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
        private double loyality;

       
        public string Client_full_name { get => client_full_name; set => client_full_name = value; }
        public string Address { get => address; set => address = value; }
        public string Phone_number { get => phone_number; set => phone_number = value; }


        public Client(string name,string addr,string phone)
        {
            Client_full_name = name;
            Address = addr;
            Phone_number = phone;
            loyality = 0;
            id = ++id_count;

        }

    }



    
}
