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
        public bool Refill(decimal ref_)
        {
            if (ref_ > 0)
            {
                Moneys += ref_;
                return true;
            }
            return false;
        }
        public Wallet(decimal Money)
        {
            Moneys = Money;
        }

        public void Subtract(decimal sum)
        {
            Moneys -= sum;
        }

        public decimal Get_Wallet()
        {
            return Moneys;
        }

        public override string ToString()
        {
            return (Moneys).ToString();
        }
    }
}
