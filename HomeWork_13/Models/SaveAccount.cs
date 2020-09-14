
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HomeWork_13.Models
{
    public class SaveAccount : Account
    {

        public enum TypeInvestment
        {
            WithCapitalization,
            WithoutCapitalization
        }

        private DateTime startInvestmentDate;
        private DateTime completeInvestmentDate;
        private double capitalizeRate = 0.05;
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
        public TypeInvestment CurrentInvestment { get => currentInvestment; set => currentInvestment = value; }

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
                LogTransaction.Add($"Investment {amount} start at {StartInvestmentDate} {(flag ? "with capitalization" :"without capitalization")}");
                InvestitionProcess = true;
                return true;
            }
            return false;
        }

        

        public bool CheckInvestment()
        {
            //if(DateTime.Now>CompleteInvestmentDate)
            //{
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
            //}
            //return false;
        }

        /// <summary>
        /// Метод расчета вклада с ежемесячной капитализациией
        /// </summary>
        private void CompleteInvestment()
        {
            
                
                var span =   CompleteInvestmentDate - DateTime.Now;
                var months = Math.Ceiling(span.TotalDays / 30.4);
            if (months >= 12)
            {
                LogTransaction.Add($"Investment less than a month, denied");
                return;
            }
            else
            {
                months = 11 - months;
                
                InterestBalance = InterestBalance * Math.Pow((1 + InterestRate / 100 / Mounts), months );
                Balance += InterestBalance;
                LogTransaction.Add($"Investment complete for {months} months with {InterestBalance}");
                InterestBalance = 0;
                startInvestmentDate = DateTime.Now;
            }
            
        }

        /// <summary>
        /// Метод расчета вклада без капитализации с возможность получения прибыли за уже пройденные месяцы
        /// </summary>
        private void CompleteSimpleInvestment()
        {




            var span = CompleteInvestmentDate - DateTime.Now;
                var months = Math.Ceiling(span.TotalDays / 30.4);



            if (months >= 12)
            {
                LogTransaction.Add($"Investment less than a month, denied");
                return;
            }
            else
            {
                months = 11 - months;
                double monthInterest = 0;

                for (var i = 1; i < months; i++)
                {
                    monthInterest += InterestBalance * InterestRate / 100 / Mounts;
                    LogTransaction.Add($"Get investment for {i} month = { InterestBalance * InterestRate / 100 / Mounts}");
                }
                InterestBalance += monthInterest;
                Balance += InterestBalance;
                startInvestmentDate = DateTime.Now;
            }
        }


    }



}
