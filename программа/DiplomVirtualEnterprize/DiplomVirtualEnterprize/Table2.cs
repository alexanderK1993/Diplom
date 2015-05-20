using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomVirtualEnterprize
{
    class Table2
    {
          private string name = "";
        private int countHours=12;

        public Table2(string name, int countHours)
        {
            this.name = name;
            this.countHours = countHours;
        }

        public string Name
        {
            get { return name; }
        }

        public int CountHours
        {
            get { return countHours; }
        }
    }
}
