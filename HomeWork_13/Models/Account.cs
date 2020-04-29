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
        private string owner; //владелец счета
        private string id; // ID счета
        private double interestRate;

        public double Balance { get => balance; set => balance = value; }
        public string Owner { get => owner; set => owner = value; }
       
        /// <summary>
        /// Конструктор базового класса 
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="owner"></param>
        public Account(double amount,string owner)
        {
            Balance = amount;
            Owner = owner;
            interestRate = 4.5;


        }
    }
}
