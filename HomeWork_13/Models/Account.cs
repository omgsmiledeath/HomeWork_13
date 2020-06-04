using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13.Models
{
    public abstract class Account
    {
        
        static List<long> idList; //List всех айди аккаунтов
        /// <summary>
        /// Статический конструктор 
        /// </summary>
        static Account()
        {
            idList = new List<long>();
        }

        private double balance;//текущий баланс на счету
        protected long id; // ID счета

        protected List<string> LogTransaction; // Лог транзакций данного счета
        public double Balance { get => balance; set => balance = value; } // Автосвойсвто для баланса
        public long ID
        {
            get
            {
                return id;
            }
        }
        /// <summary>
        /// Конструктор базового класса 
        /// </summary>
        /// <param name="amount"></param>

        public Account(double amount)
        {
            Balance = amount;
            id = idList.Count;
            idList.Add(id);
            LogTransaction = new List<string>();
        }

        /// <summary>
        /// Свойство для перевода денег с текущего счета на другой
        /// </summary>
        /// <param name="target">Аккаунт на который переводятся средства</param>
        /// <param name="amount">Сумма</param>
        /// <returns></returns>
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
        /// <summary>
        /// Свойство для пополнения счета
        /// </summary>
        /// <param name="amount"></param>
        public virtual void Deposit(double amount)
        {
            balance += amount;
            LogTransaction.Add($"Added {amount} at {DateTime.Now}");
        }

        /// <summary>
        /// Текстовое представление аккаунта
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Account number :{this.id} has {this.Balance}";
        }
    }
}
