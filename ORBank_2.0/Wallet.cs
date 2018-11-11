using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORBank_2._0
{
    [Serializable]
    public class Wallet
    {
        public decimal Moneys { get; private set; }

        public Wallet(decimal Money)
        {
            Moneys = Money;
        }

        public decimal Get_Wallet()
        {
            return Moneys;
        }

        public override string ToString()
        {
            return ((int)Moneys).ToString();
        }
    }
}
