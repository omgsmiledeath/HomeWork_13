
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HomeWork_13.Models
{
    public abstract class Account 
    {
        static List<long> idList;

        static Account()
        {
            idList = new List<long>();
        }

        protected string owner;
        protected long id;
        protected double balance;
        protected long 
    }
}