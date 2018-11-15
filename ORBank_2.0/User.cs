using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORBank_2._0
{
    [Serializable]
    public class User
    {
        public void Print()
        {
            System.Windows.Forms.MessageBox.Show("Name:    "+Name+
                "\nSurname:      "+SurName+
                "\nLogin:        "+LogIn+
                "\nPassword:     "+Password+
                "\nCard:         "+CardNum+
                "\nPhone number: "+Phone_Number
                );


        }
        public bool Banned { get; set; } = false;

        public string Name { get; set; }

        public string SurName { get; set; }

        public Wallet wallet { get; set; }

        public string LogIn { get; set; }

        public string Password { get; set; }

        public string CardNum { get; set; }

        public string PINcode { get; set; }

        public string Phone_Number { get; set; }

        public Deposits Deposits { get; set; } = new Deposits();

        public Credits Credits { get; set; } = new Credits();

        public static User Create(Int64 UsersNum,Users users)
        {
            User newUser = null;
            Registration reg = new Registration(users);
            reg.ShowDialog();
            if (reg.Done)
            {
                newUser = reg.ToUser(UsersNum);
            }

            return newUser;
        }

    }
    [Serializable]
    public class Deposits : BindingList<Deposit>
    {

    }

    [Serializable]
    public class Credits : BindingList<Credit>
    {

    }
}
