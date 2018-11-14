using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORBank_2._0
{
    [Serializable]
    public class Bank
    {
        public Users Users { get; set; } = new Users();
        public Wallet Bank_Moneys { get; set; } = new Wallet(10000000);
    }

    [Serializable]
    public class Users : BindingList<User>
    {



    }
}
