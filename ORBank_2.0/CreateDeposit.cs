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
    public partial class CreateDeposit : MetroForm
    {
        
        User user;
        public CreateDeposit()
        {
            InitializeComponent();
        }

        public CreateDeposit(ref User user_)
        {
            InitializeComponent();
            user = user_;

        }

        public bool IsSuccessful { get; set; }

        private void MetroButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MetroButton2_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = user.wallet.Moneys;
            if (numericUpDown1.Value != 0)
            {
                Error.SetError(numericUpDown1, "Uncorrect value");
            }
            Deposit Deposit= null;
            if (metroRadioButton1.Checked)
            {
                Deposit = new Deposit((double)numericUpDown1.Value);
                Deposit.Min_Days_For_Take = 0;
                Deposit.Percent = 0.02F;
            }
            if (metroRadioButton2.Checked)
            {
                Deposit = new Deposit((double)numericUpDown1.Value);
                Deposit.Min_Days_For_Take = 30;
                Deposit.Percent = 0.05F;
            }
            if (metroRadioButton3.Checked)
            {
                Deposit = new Deposit((double)numericUpDown1.Value);
                Deposit.Min_Days_For_Take = 366;
                Deposit.Percent = 0.1F;
            }
            MessageBox.Show("Deposit created sucsessfull");
            user.Deposits.Add(Deposit);
        }
    }
}
