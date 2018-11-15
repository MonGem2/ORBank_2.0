using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORBank_2._0
{
    public partial class Forgot : Form
    {
        Users users_;
        public Forgot(Users users)
        {
            InitializeComponent();
            users_ = users;
        }

        private void MetroButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MetroButton1_Click(object sender, EventArgs e)
        {
            if (metroTextBox1.Text == string.Empty)
            {
                Error.SetError(metroTextBox1, "This box can not be empty");
            }
            if (metroTextBox2.Text == string.Empty)
            {
                Error.SetError(metroTextBox2, "This box can not be empty");
            }
            var item = users_.Where(x => x.LogIn==metroTextBox1.Text).ToList();
            
            if (!item.Any())
            {
                Error.SetError(metroTextBox1, "This user does not exist");
                return;
            }
            if (item[0].PINcode != metroTextBox2.Text)
            {

                Error.SetError(metroTextBox2, "Uncorrect pin");
                return;
            }
            item[0].Print();
        }
    }
}
