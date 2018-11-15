using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORBank_2._0
{
    public partial class Registration : Form
    {
        Users Users;

        public Registration(Users users)
        {
            Users = users;
            InitializeComponent();
        }

        public bool Done { get; set; } = false;

        public User ToUser(Int64 UsersNum)
        {
            Random rnd = new Random();
            User newUser = new User();
            if (metroTextBox1.Text != string.Empty && metroTextBox2.Text != string.Empty && metroTextBox3.Text != string.Empty && metroTextBox4.Text != string.Empty && metroTextBox5.Text != string.Empty)
            {
                newUser.Name = metroTextBox1.Text;
                newUser.SurName = metroTextBox2.Text;
                newUser.Password = metroTextBox4.Text;
                newUser.LogIn = metroTextBox3.Text;
                newUser.Phone_Number = metroTextBox5.Text;
                for (int i = 0; i < 16 - UsersNum.ToString().Count(); i++)
                {
                    newUser.CardNum += "0";
                }
                newUser.CardNum += (UsersNum + 1).ToString();
                newUser.PINcode = rnd.Next(9).ToString() + rnd.Next(9).ToString() + rnd.Next(9).ToString() + rnd.Next(9).ToString();
                newUser.wallet = new Wallet(300);
                MessageBox.Show($"Your card number:{newUser.CardNum}\nPin:{newUser.PINcode}");
            }
            return newUser;
        }

        bool IsCorrect()
        {
            string LogPattern = @"^[A-Za-z]\w{5,15}$";
            string NamePattern = @"^[A-Z][a-z]{1,15}$";
            string PhonePattern = @"^([+][0-9\s-\(\)]{6,25})+$";

            bool NameCorrect = true;
            bool SurNameCorrect = true;
            bool LoginCorrect = true;
            bool PassCorrect = true;
            bool PhoneCorrect = true;

            Regex reg = new Regex(LogPattern);
            if (!reg.IsMatch(metroTextBox3.Text))
            {
                errorProvider3.SetError(metroTextBox3, "6-16 letters and numbers(first is letter)");
                LoginCorrect = false;
            }
            else if (Users.Count != 0)
            {
                if (Users.Where(a => a.LogIn == metroTextBox3.Text).Count() != 0)
                {
                    errorProvider3.SetError(metroTextBox3, "This user was already created");
                    LoginCorrect = false;
                }
                else { errorProvider3.Clear(); }
            }
            else { errorProvider3.Clear(); }
            if (!reg.IsMatch(metroTextBox4.Text))
            {
                errorProvider4.SetError(metroTextBox4, "6-16 letters and numbers(first is letter)");
                PassCorrect = false;
            }
            else { errorProvider4.Clear(); }
            reg = new Regex(NamePattern);
            if (!reg.IsMatch(metroTextBox1.Text))
            {
                errorProvider1.SetError(metroTextBox1, "2-16 letters(first is capital)");
                NameCorrect = false;
            }
            else { errorProvider1.Clear(); }
            if (!reg.IsMatch(metroTextBox2.Text))
            {
                errorProvider2.SetError(metroTextBox2, "2-16 letters(first is capital)");
                SurNameCorrect = false;
            }
            else { errorProvider2.Clear(); }
            reg = new Regex(PhonePattern);
            if (!reg.IsMatch(metroTextBox5.Text))
            {
                errorProvider5.SetError(metroTextBox5, @"+________...(6-25 numbers)");
                PhoneCorrect = false;
            }
            else { errorProvider5.Clear(); }
            if (LoginCorrect && NameCorrect && PassCorrect && SurNameCorrect && PhoneCorrect)
            {
                return true;
            }
            return false;
        }

        private void MetroButton1_Click(object sender, EventArgs e)
        {
            if (IsCorrect())
            {
                Done = true;
                Close();
            }
        }
    }
}
