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
        protected double interestRate;
        protected List<string> LogTransaction;
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
            LogTransaction = new List<string>();
        }

        public virtual bool Withdraw(Account target,double amount)
        {
            if((Balance - amount)>=0)
            {
                Balance -= amount;
                target.Deposit(amount);
                LogTransaction.Add($"Withdrawn {amount} to {target} at {DateTime.Now} ");
                return true;
            }
            return false;
        }

        public void Deposit(double amount)
        {
            balance += amount;
            LogTransaction.Add($"Added {amount} at {DateTime.Now}");
        }

        public override string ToString()
        {
            return $"Account number :{this.id}";
        }
    }
}
