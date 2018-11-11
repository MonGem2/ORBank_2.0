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
    }

    [Serializable]
    public class Users : BindingList<User>
    {

    }
}
