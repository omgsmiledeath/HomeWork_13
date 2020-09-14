using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13.Models
{
    public class SaveAccount : Account
    {

        enum TypeInvestment
        {
            WithCapitalization,
            WithoutCapitalization
        }

        private DateTime startInvestmentDate;
        private DateTime completeInvestmentDate;

        private TypeInvestment currentInvestment;
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

        public double InterestBalance { get => interestBalance; set => interestBalance = value; }
        public double InterestRate { get => interestRate;  }
        private TypeInvestment CurrentInvestment { get => currentInvestment; set => currentInvestment = value; }

        public SaveAccount(double amount,double bonusInterestRate=0) : base(amount,AccountTypes.Debit)
        {
            interestRate = bonusInterestRate;
            InterestBalance = 0;
            InvestitionProcess = false;
        }

        

        private void ChangeInterestRate(double rate)
        {
            interestRate = rate;
        }

        public bool StartInvestment(double amount,int month,bool flag)
        {
            Mounts = month;
            if((Balance-amount)>=0 && !InvestitionProcess)
            {
                CurrentInvestment = flag ? TypeInvestment.WithCapitalization : TypeInvestment.WithoutCapitalization;
                StartInvestmentDate = DateTime.Now;
                CompleteInvestmentDate = DateTime.Now.AddMonths(Mounts);
                InterestBalance += amount;
                Balance -= amount;
                LogTransaction.Add($"Investment {amount} start at {StartInvestmentDate} {InterestBalance}");
                InvestitionProcess = true;
                return true;
            }
            return false;
        }

        

        public bool CheckInvestment()
        {
            if(DateTime.Now>CompleteInvestmentDate)
            {
                switch(CurrentInvestment)
                {
                    case (TypeInvestment.WithCapitalization):
                        CompleteInvestment();
                        break;
                    case (TypeInvestment.WithoutCapitalization):
                        CompleteSimpleInvestment();
                        break;
                }
                
                return true;
            }
            return false;
        }

        private void CompleteInvestment()
        {
            double mountInterest = 0;
            double startInterestBalance =InterestBalance;
            for (int i = 0; i < Mounts; i++)
            {
                mountInterest = InterestBalance * (InterestRate / 100);
                InterestBalance += mountInterest;
                LogTransaction.Add($"mountInterest - {mountInterest} interest balance - {InterestBalance}");
                mountInterest = 0;
            }


            interestRate += InterestRate / 10 * 5;
            Balance += InterestBalance;
            LogTransaction.Add($"Investment complete with {InterestBalance}");
            InterestBalance = 0;
            
        }

        private void CompleteSimpleInvestment()
        {

        }


    }



}
