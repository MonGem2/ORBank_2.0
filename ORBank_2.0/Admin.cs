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
        public Users Users { get; set; } = new Users();
        public Admin()
        {
            InitializeComponent();
        }

        public Admin(ref Users users)
        {
            InitializeComponent();
            Users = users;
            UpdateDataGrid();
        }

        public void UpdateDataGrid()
        {
            dataGridView1.DataSource = Users;
        }

        private void MetroButton1_Click(object sender, EventArgs e)
        {
            Close();
            
        }

        private void MetroButton2_Click(object sender, EventArgs e)
        {
            User tmp = User.Create(Users.Count, Users);
            if (tmp != null)
            {
                Users.Add(tmp);
            }
            UpdateDataGrid();
        }

        private void MetroButton3_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                i = dataGridView1.Rows.IndexOf(dataGridView1.SelectedRows[0]);
                Users.RemoveAt(i);
                UpdateDataGrid();
            }
            catch
            { }
        }
    }
}
