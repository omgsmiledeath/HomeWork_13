using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13.Models
{
    public class SaveAccount : Account
    {
        private DateTime startInvestmentDate;
        private DateTime completeInvestmentDate;
        private double interestBalance;
        public SaveAccount(double amount) : base(amount)
        {
            
        }

        

        public void ChangeInterestRate(double rate)
        {
            interestRate = rate;
        }

        public bool StartInvestment(double amount)
        {
            if((Balance-amount)>=0)
            {
                startInvestmentDate = DateTime.Now;
                completeInvestmentDate = DateTime.Now.AddMonths(12);
                interestBalance += amount;
                Balance -= amount;
                LogTransaction.Add($"Investment {amount}");
                return true;
            }
            return false;
        }


    }



}
