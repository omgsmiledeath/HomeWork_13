
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HomeWork_13.Models
{
    public class CreditAccount : Account
    {
        private double limit;
        private double creditBalance;
        private double creditRate;
        public CreditAccount(double amount,double limit) : base(amount,AccountTypes.Credit)
        {
            this.limit = limit;
            this.creditRate = 10;
            creditBalance = 0;
            
        }

        public bool GetCredit(double amount)
        {
            if(creditBalance+amount!=limit)
            {
                limit += amount+amount*creditRate;
                Balance += amount;
                LogTransaction.Add($"Get credit at {amount}");
                return true;
            }
            return false;
        }

        public bool CloseCredit(double amount)
        {
            if ((Balance - amount >= 0) && (limit-amount>=0))
            {
                limit -= amount;
                Balance -= amount;
                LogTransaction.Add($"Close credit at {amount}");
                if (limit == 0) creditRate -= 0.2;
                return true;
            }
            return false;
        }



    }
}