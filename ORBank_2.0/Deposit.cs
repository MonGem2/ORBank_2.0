﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORBank_2._0
{
    [Serializable]
    public class Deposit
    {
        public double Sum { get; set; }
        DateTime Createtime { get; set; }
        public float Percent { get; set; }
        public int Min_Days_For_Take { get; set; }

        public Deposit(double newsum)
        {
            Createtime = DateTime.Today;
            Percent = 3;
            Sum = newsum;
        }
        public double GetSum()
        {
            int daysnum = (DateTime.Now - Createtime).Days;
            if (daysnum < Min_Days_For_Take)
            {
                return 0;
            }
            double NewS = Sum;
            for (int i = 0; i < daysnum; i++)
            {
                NewS += (NewS / 100) * Percent;
            }

            return NewS;
        }
        public double Get_Sum()
        {
            return Sum;
        }

    }
}
