using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13.Models
{
    public class BaseRepository
    {
        private Bank<Individual> individualList;
        private Bank<Business> businessList;
        private Bank<VipClient> vipClientsList;

        public Bank<Individual> IndividualList { get => individualList;  }
        public Bank<Business> BusinessList { get => businessList;  }
        public Bank<VipClient> VipClientsList { get => vipClientsList;  }

        public BaseRepository(Bank<Individual> individuals,
            Bank<Business> businesses,
            Bank<VipClient> vipClients)
        {
            this.individualList = individuals;
            this.businessList = businesses;
            this.vipClientsList = vipClients;
        }

    }
}
