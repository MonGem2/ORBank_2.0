using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORBank_2._0
{
    [Serializable]
    public class Credit
    {
        public double Sum { get; set; }
        DateTime Createtime { get; set; }
        public float Percent { get; set; }
        public int Max_Days_For_Take { get; set; }

        public Credit(double newsum)
        {
            Createtime = DateTime.Today;
            Percent = 3;
            Sum = newsum;
        }
        public double GetSum()
        {
            int daysnum = (DateTime.Now - Createtime).Days;
            double NewS = Sum;
            for (int i = 0; i < daysnum; i++)
            {
                NewS += (NewS / 100) * Percent;
                if (i > Max_Days_For_Take)
                {
                    Percent *= 2;
                }
            }

            return NewS;
        }
        public double Get_Sum()
        {
            return Sum;
        }
    }
}
