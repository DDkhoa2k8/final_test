using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final_test
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
            this.op_ql_bh.Click += new System.EventHandler(this.op_ql_bh_Click);
        }

        private Form curForm;
        private bool isOpen = false;

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void op_con_Paint(object sender, PaintEventArgs e)
        {

        }

        private void op_ql_bh_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("hello");
            ql_ban_hang ql_Ban_Hang = new ql_ban_hang();
            ql_Ban_Hang.TopLevel = false;
            this.op_ql_bh.Controls.Add(ql_Ban_Hang);

            ql_Ban_Hang.Dock = DockStyle.Fill;
            ql_Ban_Hang.BringToFront();
            ql_Ban_Hang.Show();
            ql_Ban_Hang.MinimizeBox = false;
            ql_Ban_Hang.FormBorderStyle = FormBorderStyle.None;
            ql_Ban_Hang.FormClosed += (s, args) =>
            {
                this.Controls.Remove(op_ql_bh);
                this.op_con.Controls.Add(this.op_ql_bh);
            };

            this.op_con.Controls.Remove(this.op_ql_bh);
            this.Controls.Add(this.op_ql_bh);
            this.op_ql_bh.BringToFront();
            this.op_ql_bh.Dock = DockStyle.Fill;
            this.curForm = ql_Ban_Hang;
            isOpen = true;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Controls.Remove(op_ql_bh);
            this.op_con.Controls.Add(this.op_ql_bh);
            if (isOpen)
            {
                this.curForm.Close();
                isOpen = false;
            }
        }
    }
}
