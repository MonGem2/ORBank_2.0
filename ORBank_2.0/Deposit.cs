using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORBank_2._0
{
    class Deposit
    {
        public double Sum { get; set; }
        public DateTime Lastupdate { get; set; }
        public DateTime Createtime { get; set; }
        public float Percent { get; set; }

        public Deposit(double newsum)
        {
            Createtime = DateTime.Today;
            Percent = 3;
            Sum = newsum;
        }

        public void UpDate()
        {
            TimeSpan num = DateTime.Today - Lastupdate;
            if (num.Days / 30 >= 1)
            {
                Sum += num.Days / 30 * Sum * (Percent / 100);
                Lastupdate = DateTime.Today;
            }
        }

        public double Get_Sum()
        {
            return Sum;
        }

    }
}
