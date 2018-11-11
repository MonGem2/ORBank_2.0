using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ORBank_2._0
{
    public partial class Login : Form
    {
        Bank bank;
        public Login()
        {
            InitializeComponent();
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = new FileStream(@"Bank\bank.orb", FileMode.Open, FileAccess.Read);
                bank = bf.Deserialize(fs) as Bank;
                fs.Close();
            }
            catch { bank = new Bank(); }
        }

        void Bank_Serialize()
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = new FileStream(@"Bank\bank.orb", FileMode.OpenOrCreate, FileAccess.Write);
                bf.Serialize(fs, bank);
                fs.Close();
            }
            catch(DirectoryNotFoundException)
            {
                Directory.CreateDirectory(@"\Bank");
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = new FileStream(@"Bank\bank.orb", FileMode.OpenOrCreate, FileAccess.Write);
                bf.Serialize(fs, bank);
                fs.Close();
            }
        }

        void listOfParts_ListChanged(object sender, ListChangedEventArgs e)
        {
            Bank_Serialize();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            bank.Users.ListChanged += new ListChangedEventHandler(listOfParts_ListChanged);
            if (metroTextBox1.Text == @"admin\" && metroTextBox2.Text == "qwerty")
            {
                Admin form = new Admin(bank.Users);
                metroTextBox1.Text = "";
                metroTextBox2.Text = "";
                form.ShowDialog(this);
            }
            else
            {
                User tmp;
                try
                {
                    if ((tmp = bank.Users.Where(a => a.LogIn == metroTextBox1.Text).First()) == null)
                    {
                        errorProvider1.Clear();
                        errorProvider1.SetError(metroTextBox1, "This user not exist");
                    }
                    else if (tmp.Password != metroTextBox2.Text)
                    {
                        errorProvider1.Clear();
                        errorProvider1.SetError(metroTextBox2, "Incorrect password");
                    }
                    else { errorProvider1.Clear(); MessageBox.Show($"Hello {tmp.Name}"); metroTextBox1.Text = ""; metroTextBox2.Text = ""; }
                }
                catch { errorProvider1.SetError(metroTextBox1, "This user not exist"); }
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            metroTextBox1.Text = "";
            metroTextBox2.Text = "";
            User tmp = User.Create(bank.Users.Count, bank.Users);
            if (tmp != null)
            {
                bank.Users.Add(tmp);
            }
        }
    }
}

