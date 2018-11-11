using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORBank_2._0
{
    public partial class Admin : Form
    {
        Users Users { get; set; } = new Users();
        public Admin()
        {
            InitializeComponent();
        }

        public Admin(Users users)
        {
            InitializeComponent();
            Users = users;
            dataGridView1.DataSource = Users;
        }

        private void MetroButton1_Click(object sender, EventArgs e)
        {
            Close();
            
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            User tmp = User.Create(Users.Count, Users);
            if (tmp != null)
            {
                Users.Add(tmp);
            }
            dataGridView1.DataSource = Users;
        }
    }
}
