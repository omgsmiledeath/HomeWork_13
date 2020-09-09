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
        bool InvestitionProcess;
        public DateTime StartInvestmentDate { get => startInvestmentDate; set 
            { 
                startInvestmentDate = value;
                OnPropertyChanged("StartInvestmentDate");
            }
        }
        public DateTime CompleteInvestmentDate
        {
            get => completeInvestmentDate; set
            {
                completeInvestmentDate = value;
                OnPropertyChanged("CompleteInvestmentDate");
            }
        }

        public int Mounts { get => mounts; set
            {
                mounts = value;
                if (mounts > 6) this.interestRate += 12;
                else this.interestRate += 5;
                OnPropertyChanged("Mounts");
            }
        }

        public SaveAccount(double amount,double bonusInterestRate=0) : base(amount,AccountTypes.Debit)
        {
            interestRate = bonusInterestRate;
            InvestitionProcess = false;
        }

        

        private void ChangeInterestRate(double rate)
        {
            interestRate = rate;
        }

        public bool StartInvestment(double amount,int month)
        {
            Mounts = month;
            if((Balance-amount)>=0 && !InvestitionProcess)
            {
                StartInvestmentDate = DateTime.Now;
                CompleteInvestmentDate = DateTime.Now.AddMonths(Mounts);
                interestBalance += amount;
                Balance -= amount;
                LogTransaction.Add($"Investment {amount} start at {StartInvestmentDate}");
                InvestitionProcess = true;
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
            for (int i = 0; i < Mounts; i++)
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
