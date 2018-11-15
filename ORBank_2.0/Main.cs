using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORBank_2._0
{
    public partial class Main : MetroForm
    {
        public Users Users;
        int Index;
        public Main()
        {
            InitializeComponent();
        }

        public Main(ref Users users,int index)
        {
            InitializeComponent();
            timer1.Interval = 1000;
            Users = users;
            Index = index;
            metroTabControl1.SelectedIndex = 0;
            UpdateForm();
            toolStripStatusLabel5.Text = "Users count: " + Users.Count.ToString();
        }

        void ChangeTabUpdate(object sender, TabControlEventArgs e)
        {
            if (metroTabControl1.SelectedTab != metroTabPage4)
            {
                metroTextBox7.Visible = true;
            }
            if (metroTabControl1.SelectedTab != metroTabPage2)
            {
                metroTextBox10.Visible = true;
                dataGridView1.Visible = false;
            }
            if (metroTabControl1.SelectedTab != metroTabPage3)
            {
                metroTextBox9.Visible = true;
            }
            if (metroTabControl1.SelectedTab != metroTabPage5)
            {
                metroTextBox11.Visible = true;
            }
            if (metroTabControl1.SelectedTab != metroTabPage6)
            {
                metroTextBox12.Visible = true;
            }
        }

        void UpdateForm()
        {
            timer1.Start();
            toolStripStatusLabel2.Text = Users[Index].Name;
            toolStripStatusLabel3.Text = Users[Index].SurName;
            metroTabControl1.Selected += new TabControlEventHandler(ChangeTabUpdate);
            Text = Users[Index].LogIn;
            metroLabel1.Text = Users[Index].wallet.ToString()+" orbs";
            metroTextBox6.Text = Users[Index].Name;
            metroTextBox2.Text = Users[Index].SurName;
            metroTextBox3.Text = Users[Index].LogIn;
            metroTextBox4.Text = Users[Index].Password;
            metroTextBox5.Text = Users[Index].Phone_Number;
            metroTextBox8.Text = Users[Index].CardNum;
        }

        void SaveChange()
        {
            Users[Index] = new User { Name = metroTextBox6.Text, SurName = metroTextBox2.Text, LogIn = metroTextBox3.Text, Password = metroTextBox4.Text, Phone_Number = metroTextBox5.Text, CardNum = metroTextBox8.Text, PINcode = Users[Index].PINcode, wallet = Users[Index].wallet };
        }

        private void MetroButton4_Click(object sender, EventArgs e)
        {
            metroTextBox4.UseSystemPasswordChar = !metroTextBox4.UseSystemPasswordChar;
            metroTextBox4.PasswordChar = '\0';
        }

        private void MetroTextBox7_TextChanged(object sender, EventArgs e)
        {
            if (metroTextBox7.Text == Users[Index].PINcode)
            {
                metroTextBox7.Visible = false;
                metroTextBox7.Clear();
            }
        }

        private void MetroButton6_Click(object sender, EventArgs e)
        {
            metroTextBox13.Enabled = true;
            metroButton6.Enabled = false;
        }

        private void MetroTextBox13_TextChanged(object sender, EventArgs e)
        {
            if (metroTextBox13.Text == Users[Index].PINcode)
            {
                metroTextBox13.Visible = false;
                metroTextBox13.Clear();
                metroTextBox6.ReadOnly = false;
                metroTextBox2.ReadOnly = false;
                metroTextBox3.ReadOnly = false;
                metroTextBox4.ReadOnly = false;
                metroTextBox5.ReadOnly = false;
                metroTextBox6.ReadOnly = false;
                metroButton5.Visible = true;
                metroButton7.Visible = true;
            }
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
                if (Users.Where(a => a.LogIn == metroTextBox3.Text).Count() != 0&&metroTextBox3.Text != Users[Index].LogIn)
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
            if (!reg.IsMatch(metroTextBox6.Text))
            {
                errorProvider1.SetError(metroTextBox6, "2-16 letters(first is capital)");
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

        private void MetroButton5_Click(object sender, EventArgs e)
        {
            if (IsCorrect())
            {
                SaveChange();
                metroTextBox13.Visible = true;
                metroTextBox13.Enabled = false;
                metroTextBox13.Clear();
                metroTextBox6.ReadOnly = true;
                metroTextBox2.ReadOnly = true;
                metroTextBox3.ReadOnly = true;
                metroTextBox4.ReadOnly = true;
                metroTextBox5.ReadOnly = true;
                metroTextBox6.ReadOnly = true;
                metroButton5.Visible = false;
                metroButton7.Visible = false;
                metroButton6.Enabled = true;
                UpdateForm();
            }
        }

        private void MetroTextBox10_TextChanged(object sender, EventArgs e)
        {
            if (metroTextBox10.Text == Users[Index].PINcode)
            {
                metroTextBox10.Visible = false;
                metroTextBox10.Clear();
                dataGridView1.Visible = true;
                dataGridView1.DataSource = Users[Index].Deposits;
            }
        }

        private void MetroTextBox9_TextChanged(object sender, EventArgs e)
        {
            if (metroTextBox9.Text == Users[Index].PINcode)
            {
                metroTextBox9.Visible = false;
                metroTextBox9.Clear();
                dataGridView2.Visible = true;
                dataGridView2.DataSource = Users[Index].Credits;
                metroButton11.Visible = true;
                metroButton9.Visible = true;
            }
        }

        private void MetroTextBox11_TextChanged(object sender, EventArgs e)
        {
            if (metroTextBox11.Text == Users[Index].PINcode)
            {
                metroTextBox11.Visible = false;
                metroTextBox11.Clear();
            }
        }

        private void MetroTextBox12_TextChanged(object sender, EventArgs e)
        {
            if (metroTextBox12.Text == Users[Index].PINcode)
            {
                metroTextBox12.Visible = false;
                metroTextBox12.Clear();
            }
        }

        private void MetroButton7_Click(object sender, EventArgs e)
        {
            metroTextBox13.Visible = true;
            metroTextBox13.Enabled = false;
            metroTextBox13.Clear();
            metroTextBox6.ReadOnly = true;
            metroTextBox2.ReadOnly = true;
            metroTextBox3.ReadOnly = true;
            metroTextBox4.ReadOnly = true;
            metroTextBox5.ReadOnly = true;
            metroTextBox6.ReadOnly = true;
            metroButton5.Visible = false;
            metroButton7.Visible = false;
        }

        private void MetroButton3_Click(object sender, EventArgs e)
        {
            try
            {
                decimal sum = decimal.Parse(metroTextBox1.Text);

                if (sum > Users[Index].wallet.Moneys)
                    errorProvider1.SetError(metroTextBox1, "Lack of funds!!!");
                else
                {
                    Users[Index].wallet.Subtract(sum);
                    errorProvider1.Clear();
                    Users.Add(new User());
                    Users.RemoveAt(Users.Count - 1);
                    saveFileDialog1.FileName = "temp";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        using (FileStream fs = new FileStream(saveFileDialog1.FileName + ".ref", FileMode.Create, FileAccess.Write))
                        {
                            using (BinaryWriter bw = new BinaryWriter(fs))
                            {
                                int i = new Random().Next(-100, 100);
                                bw.Write("12321");
                                bw.Write((Decimal)(sum+i));
                                bw.Write(i);
                            }
                        }
                    }
                }
            }
            catch
            {
                errorProvider1.SetError(metroTextBox1, "This is not a number!!!");
            }
            UpdateForm();
        }

        private void MetroButton2_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        using (FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read))
                        {
                            using (BinaryReader br =new BinaryReader(fs))
                            {
                                if (br.ReadString() != "12321")
                                {
                                    throw new Exception();
                                }
                                decimal i = br.ReadDecimal();
                                i -= br.Read();
                                if (Users[Index].wallet.Refill(i))
                                {
                                    MessageBox.Show("Successful");
                                }
                                Users.Add(new User());
                                Users.RemoveAt(Users.Count - 1);

                            }
                        }
                    }
                    File.Delete(openFileDialog1.FileName);

                }
                catch (Exception)
                {
                    MessageBox.Show("Can not open refill file");

                }
                UpdateForm();
            }
            catch
            {
                MessageBox.Show("This is not a receipt!!!");
            }
        }

        private void MetroButton1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write))
                    {
                        using (BinaryWriter BW = new BinaryWriter(fs))
                        {
                            BW.Write(Users[Index].Name);
                            BW.Write(Users[Index].SurName);
                            BW.Write(Users[Index].Phone_Number);
                            BW.Write(Users[Index].Password);
                            BW.Write(Users[Index].LogIn);
                            BW.Write(Users[Index].CardNum);
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Ortem loh(Can not create user file :( )");
                    
                }
                
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToLongTimeString();
            toolStripStatusLabel4.Text = DateTime.Now.ToShortDateString();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
        }

        private void MetroButton8_Click_1(object sender, EventArgs e)
        {
            var tmp = Users[Index];
            CreateDeposit createDeposit = new CreateDeposit(ref tmp);
            Users[Index] = tmp;
            createDeposit.ShowDialog();
            dataGridView1.DataSource = Users[Index].Deposits;
        }
    }
}
