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
        private int mounts;
        private double interestBalance;
        private double interestRate;

        public DateTime StartInvestmentDate { get => startInvestmentDate; set => startInvestmentDate = value; }
        public DateTime CompleteInvestmentDate { get => completeInvestmentDate; set => completeInvestmentDate = value; }

        public SaveAccount(double amount,int mounts) : base(amount)
        {
            this.mounts = mounts;
            if (mounts > 6) interestRate = 12;
            else interestRate = 5;
        }

        

        private void ChangeInterestRate(double rate)
        {
            interestRate = rate;
        }

        public bool StartInvestment(double amount)
        {
            if((Balance-amount)>=0)
            {
                StartInvestmentDate = DateTime.Now;
                CompleteInvestmentDate = DateTime.Now.AddMonths(mounts);
                interestBalance += amount;
                Balance -= amount;
                LogTransaction.Add($"Investment {amount}");
                return true;
            }
            return false;
        }

        public bool CheckInvestment()
        {
            if(DateTime.Now>CompleteInvestmentDate)
            {
                CompleteInvestment();
                return true;
            }
            return false;
        }

        private void CompleteInvestment()
        {
            double mountInterest = 0;
            for (int i = 0; i < mounts; i++)
            {
                mountInterest = interestBalance * interestRate;
                interestBalance += mountInterest;
            }
            interestRate += interestRate / 10 * 5;
            Balance += interestBalance;
            LogTransaction.Add($"Investment complete with {interestBalance}");
            interestBalance = 0;   
        }




    }



}
