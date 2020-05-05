using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13.Models
{
    public class Account
    {
        static List<long> idList;
        static Account()
        {
            idList = new List<long>();
        }
        private double balance;//текущий баланс на счету
        private long id; // ID счета
        private double interestRate;

        public double Balance { get => balance; set => balance = value; }
       
        /// <summary>
        /// Конструктор базового класса 
        /// </summary>
        /// <param name="amount"></param>

        public Account(double amount)
        {
            Balance = amount;
            interestRate = 4.5;
            id = idList.Count;
            idList.Add(id);
        }
    }
}
