using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13.Models
{
    class Bank <T>
        where T : Client
    {
        private ObservableCollection<T> clientList = new ObservableCollection<T>();

        public ObservableCollection<T> ClientList { get => clientList; }

        public void AddClient(T client)
        {
            clientList.Add(client);
        }
    }
}
