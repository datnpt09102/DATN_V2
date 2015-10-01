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
    public partial class floaikh : Form
    {
        public floaikh()
        {
            InitializeComponent();
        }
       loaikhachhangBUS data = new BUS.loaikhachhangBUS();
       loaikhachhangDTO laygiatri = new DTO.loaikhachhangDTO();

        private void floaikh_Load(object sender, EventArgs e)
        {
            dataload();
        }
        private void dataload()
        {
            dtgdsloaikh.DataSource = data.showtable();
            for (int i = 0; i < dtgdsloaikh.Rows.Count; i++)
            {
                dtgdsloaikh.Rows[i].Cells[0].Value = i + 1;
            }

        }
        public void addtable()
        {
            try
            {
                laygiatri.Tenloaikh = txttenloaikh.Text;
                data.addtable(laygiatri.Tenloaikh);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
       
        private void btnaddloaikh_Click(object sender, EventArgs e)
        {
            addtable();
            dataload();
        }
     
        private void btndelloaikh_Click(object sender, EventArgs e)
        {
            string columnten = dtgdsloaikh.CurrentRow.Cells["tenloaikh"].Value.ToString();
            data.delrows(columnten);
            dataload();
        }

        private void btneditloaikh_Click(object sender, EventArgs e)
        {
            int columnid = int.Parse(dtgdsloaikh.CurrentRow.Cells["idloaikh"].Value.ToString());
            laygiatri.Tenloaikh = txttenloaikh.Text;
            data.editrow(columnid, laygiatri.Tenloaikh);
            dataload();
        }
    }
}
