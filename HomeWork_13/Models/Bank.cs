using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13.Models
{
    class Bank <T>
        where T : Account
    {
        private ObservableCollection<T> accountList = new ObservableCollection<T>();

        public ObservableCollection<T> AccountList { get => accountList;}

        public void AddAccount(T account)
        {
            accountList.Add(account);
        }
    }
}
