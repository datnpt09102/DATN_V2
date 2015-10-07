using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BUS;
using DTO;

namespace QLBanHang
{
    public partial class fbanhang : Form
    {
        public fbanhang()
        {
            InitializeComponent();
        }

            //fhdban frm = new fhdban();
            //frm.ShowDialog();

        hoadonbanBUS data = new hoadonbanBUS();
        hoadonbanDTO laygiatri = new hoadonbanDTO();

        chititethdbanBUS datahdban = new chititethdbanBUS();
        chitiethdbanDTO laygiatrihdban = new chitiethdbanDTO();

        private void dataloadmh()
        {
            dtgdsmhhdban.DataSource = data.gettablemh();

            for (int i = 0; i < dtgdsmhhdban.Rows.Count; i++)
            {
                dtgdsmhhdban.Rows[i].Cells[0].Value = i + 1;
            }
        }

        public void loaimh()
        {
            cbbloaimhban.DataSource = data.gettableloaimh();
            cbbloaimhban.DisplayMember = "tenloaimh";
            cbbloaimhban.ValueMember = "idloaimh";
        }

        public void khachhang()
        {
            cbbkhhdban.DataSource = data.gettablekh();
            cbbkhhdban.DisplayMember = "hotenkh";
        }

        public void dataloadchitiet()
        {
            dtgchitiethdban.DataSource = datahdban.showtable();

            for (int i = 0; i < dtgchitiethdban.Rows.Count; i++)
            {
                dtgchitiethdban.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void fbanhang_Load(object sender, EventArgs e)
        {
            dataloadmh();
            loaimh();
            khachhang();
            cbbkhhdban.Text = "";
        }

        private void btnaddkhhdban_Click(object sender, EventArgs e)
        {
            fkh frm = new fkh();
            frm.ShowDialog();
        }

        private void btndshdban_Click(object sender, EventArgs e)
        {
            fhdban frm = new fhdban();
            frm.ShowDialog();
        }

        private void btnaddhdban_Click(object sender, EventArgs e)
        {
            laygiatrihdban.Idhdban = 0;
            lbltenhdban.Text = "HD" + laygiatrihdban.Idhdban;
        }
    }
}
