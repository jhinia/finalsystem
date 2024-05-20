using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kissbone_Cove_system
{
    public partial class Mainform : Form
    {
        public Mainform()
        {
            InitializeComponent();
           // InitializeFormProperties();
        }

        private void InitializeFormProperties()
        {
            // Set form size
            this.Size = new System.Drawing.Size(1608, 730);
            this.AutoScaleMode = AutoScaleMode.None;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            MainPanel.Size = new System.Drawing.Size(1350, 730);
        }

        public void loadform(object Form)
        {
            if(this.MainPanel.Controls.Count > 0)
                this.MainPanel.Controls.RemoveAt(0);

            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.MainPanel.Controls.Add(f);
            this.MainPanel.Tag = f;
            f.Show();
        }

        private void BtnCustomer_Click(object sender, EventArgs e)
        {
            SidePanel.Visible = true;

            SidePanel.Height = BtnCustomer.Height;
            SidePanel.Top = BtnCustomer.Top;
            OperationDB.AddForm(new CostumerList(), MainPanel);
        }

        private void BtnRoom_Click(object sender, EventArgs e)
        {
            SidePanel.Visible = true;
            SidePanel.Height = BtnRoom.Height;
            SidePanel.Top = BtnRoom.Top;
            OperationDB.AddForm(new AddRoom(), MainPanel);
        }
        private void lblLogOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Confirm Logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check the user's response and return a boolean value
            if (result == DialogResult.Yes)
            {
                this.Hide();
                new Form1().Show();
            }
        }

        private void Mainform_Load(object sender, EventArgs e)
        {

        }
    }
}
