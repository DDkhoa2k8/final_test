using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace final_test
{
    public partial class menu : Form
    {
        public bool isQuen = false;
        public String veriCode;
        public String vaitro;
        public String username;
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
        //        return cp;
        //    }
        //}

        public menu()
        {
            InitializeComponent();
            //this.DoubleBuffered = true;
            this.op_ql_bh.Click += new System.EventHandler(this.op_ql_bh_Click);
            this.op_ql_sp.Click += new System.EventHandler(this.op_ql_sp_Click);
            this.op_ql_dm.Click += new System.EventHandler(this.op_dm_Click);
            this.op_ql_nv.Click += new System.EventHandler(this.op_ql_nv_Click);
            this.op_ql_hd.Click += new System.EventHandler(this.op_ql_hd_Click);
            this.op_bc.Click += new System.EventHandler(this.op_bc_Click);
            this.op_ql_nh.Click += new System.EventHandler(this.op_ql_nh_Click);
            this.op_ql_ncc.Click += new System.EventHandler(this.op_ql_ncc_Click);
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

        private void showChildForm<F>(Guna2Panel op) where F : Form, new()
        {
            F cf = new F();
            cf.TopLevel = false;
            op.Controls.Add(cf);

            cf.Dock = DockStyle.Fill;
            cf.BringToFront();
            cf.Show();
            cf.MinimizeBox = false;
            cf.FormBorderStyle = FormBorderStyle.None;
            cf.FormClosed += (s, args) =>
            {
                this.Controls.Remove(op);
                op_con.Controls.Add(op);
            };

            op_con.Controls.Remove(op);
            this.Controls.Add(op);
            op.BringToFront();
            op.Dock = DockStyle.Fill;
            this.curForm = cf;
            isOpen = true;
        }

        private void op_ql_bh_Click(object sender, EventArgs e)
        {
            showChildForm<ql_ban_hang>(op_ql_bh);
        }

        private void op_ql_sp_Click(object sender, EventArgs e)
        {
            showChildForm<ql_san_pham>(op_ql_sp);
        }
        private void op_dm_Click(object sender, EventArgs e)
        {
            showChildForm<ql_danh_muc>(op_ql_dm);

        }
        private void op_ql_nv_Click(object sender, EventArgs e)
        {
            showChildForm<ql_nhan_vien>(op_ql_nv);
        }
        private void op_ql_hd_Click(object sender, EventArgs e)
        {
            showChildForm<ql_nhap_hang>(op_ql_hd);
        }

        private void op_bc_Click(object sender, EventArgs e)
        {
            showChildForm<bao_cao>(op_bc);
        }

        private void op_ql_nh_Click(object sender, EventArgs e)
        {
            showChildForm<ql_nhap_hang>(op_ql_nh);
        }
        private void op_ql_ncc_Click(object sender, EventArgs e)
        {
            showChildForm<ql_ncc>(op_ql_ncc);
        }

        private void close_child_form_Click(object sender, EventArgs e)
        {
            this.Controls.Remove(op_ql_bh);
            this.op_con.Controls.Add(this.op_ql_bh);
            if (isOpen)
            {
                this.curForm.Close();
                isOpen = false;
            }
        }

        private void menu_Load(object sender, EventArgs e)
        {
        }

        private void dang_xuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void doi_mk_Click(object sender, EventArgs e)
        {
            doi_mk doiMk = new doi_mk();
            doiMk.veriCode = this.veriCode;
            doiMk.isQuen = this.isQuen;
            doiMk.username = this.username;
            doiMk.ShowDialog();
        }
    }
}
