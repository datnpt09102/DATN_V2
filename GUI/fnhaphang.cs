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
    public partial class fnhaphang : Form
    {
        public fnhaphang()
        {
            InitializeComponent();
        }

        private void btnaddmhnhap_Click(object sender, EventArgs e)
        {
            fmh frm = new fmh();
            frm.ShowDialog();
        }

        private void btnxuathdnhap_Click(object sender, EventArgs e)
        {
            fhdnhap frm = new fhdnhap();
            frm.ShowDialog();
        }

        private void btnviewncc_Click(object sender, EventArgs e)
        {
            fncc frm = new fncc();
            frm.ShowDialog();
        }

        chitiethdnhapBUS data = new chitiethdnhapBUS();
        chitiethdnhapDTO laygiatri = new chitiethdnhapDTO();

        private void fnhaphang_Load(object sender, EventArgs e)
        {
            dataload();
            loaimhload();
        }

        public void loaimhload()
        {
            cbbloaimhhdnhap.DataSource = data.getloaimh();
            cbbloaimhhdnhap.DisplayMember = "tenloaimh";
        }

        private void dataload()
        {
            // Đổ dữ liệu vào DataGridView
            dtgdsmhnhap.DataSource = data.gettablemh();
            // Số thứ tự tăng tự động
            for (int i = 0; i < dtgdsmhnhap.Rows.Count; i++)
            {
                dtgdsmhnhap.Rows[i].Cells[0].Value = i + 1;
            }
        }

        public void chitietload(int i)
        {

            

            //MessageBox.Show(laygiatri.Idmh.ToString() + laygiatri.Soluongnhap.ToString());
            
            //for (int i = 0; dtgdschitiethdnhap.Rows.Count > i; i++)
            //{
            //    do
            //    {
                   
                    dtgdschitiethdnhap.Rows.Add();
                    dtgdschitiethdnhap.Rows[i].Cells["tenmhnhap"].Value = laygiatri.Idmh;
                    dtgdschitiethdnhap.Rows[i].Cells["soluongmhnhap"].Value = laygiatri.Soluongnhap;
                    
            //    }
            //    while (dtgdschitiethdnhap.Rows.Count > i);               
            //}
        }
        int i = 0;
        private void dtgdsmhnhap_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                laygiatri.Idmh = int.Parse(dtgdsmhnhap.CurrentRow.Cells["idmhnhap"].Value.ToString());
                laygiatri.Soluongnhap = int.Parse(dtgdsmhnhap.CurrentRow.Cells["soluongnhap"].Value.ToString());
                chitietload(i);
                i += 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
