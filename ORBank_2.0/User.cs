using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORBank_2._0
{
    [Serializable]
    public class User
    {
        public string Name { get; set; }

        public string SurName { get; set; }

        public Wallet wallet { get; set; }

        public string LogIn { get; set; }

        public string Password { get; set; }

        public string CardNum { get; set; }

        public string PINcode { get; set; }

        public string Phone_Number { get; set; }

        public static User Create(Int64 UsersNum,Users users)
        {
            User newUser = new User();
            Registration reg = new Registration(users);
            reg.ShowDialog();
            if (reg.Done)
            {
                newUser = reg.ToUser(UsersNum);
            }

            return newUser;
        }
    }
}
