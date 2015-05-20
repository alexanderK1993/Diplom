using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomVirtualEnterprize
{
    class Table
    {
        private string date = "";
        private int countHours=12;

        public Table(string date, int countHours)
        {
            this.date = date;
            this.countHours = countHours;
        }

        public string Date
        {
            get { return date; }
        }

        public int CountHours
        {
            get { return countHours; }
        }
    }
}
