using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13.Models
{
    /// <summary>
    /// Класс описывающй транзакции между счетами
    /// </summary>
    /// <typeparam name="T">Наследник реализующий ITransaction</typeparam>
    class Transaction<T>
        where T : ITransaction
    {
        static ObservableCollection<long> TransactionIdList;
        static Transaction()
        {
            TransactionIdList = new ObservableCollection<long>();
        }


        long TransactionId;

        /// <summary>
        /// Конструктор 
        /// </summary>
        /// <param name="inAccount">Принимающий аккаунт</param>
        /// <param name="outAccount">Отправляющий аккаунт</param>
        public Transaction(T inAccount, T outAccount)
        {
           while(true)
            {
                TransactionId = new Random().Next((int)DateTime.Now.Ticks);
                if(!TransactionIdList.Contains(TransactionId))
                {
                    TransactionIdList.Add(TransactionId);
                    break;
                }
            }

        }
        
    }
}
