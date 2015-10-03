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
    public partial class fmh : Form
    {
        public fmh()
        {
            InitializeComponent();
        }
        
        private void btnloaimh_Click(object sender, EventArgs e)
        {
            floaimh frm = new floaimh();
            frm.ShowDialog();
        }
        
        mathangBUS data = new mathangBUS();
        mathangDTO laygiatri = new mathangDTO(); 

        private void fmh_Load(object sender, EventArgs e)
        {
            dataload();
            loaimhload();
        }

        private void dataload()
        {
            dtgdsmh.DataSource = data.showtable();

            for (int i = 0; i < dtgdsmh.Rows.Count; i++)
            {
                dtgdsmh.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void loaimhload()
        {
            cbbloaimh.DataSource = data.gettable();
            cbbloaimh.ValueMember = "idloaimh";
            cbbloaimh.DisplayMember = "tenloaimh";
        }

        private void dataget()
        {
            try
            {
                laygiatri.Tenmh = txttenmh.Text;
                laygiatri.Idloaimh = int.Parse(cbbloaimh.SelectedValue.ToString());
                laygiatri.Soluong = int.Parse(numsoluongmh.Value.ToString());
                laygiatri.Donvitinh = cbbdvtinhmh.Text;
                laygiatri.Gianhap = numgianhapmh.Value.ToString();
                laygiatri.Giaban = numgiabanmh.Value.ToString();
                laygiatri.Thongtinmh = txtthongtinmh.Text;
                #region
                //StringBuilder strbuil = new StringBuilder();
                //strbuil.Append(laygiatri.Tenmh);
                //strbuil.Append("\n");
                //strbuil.Append(laygiatri.Idloaimh);
                //strbuil.Append("\n");
                //strbuil.Append(laygiatri.Soluong);
                //strbuil.Append("\n");
                //strbuil.Append(laygiatri.Donvitinh);
                //strbuil.Append("\n");
                //strbuil.Append(laygiatri.Gianhap);
                //strbuil.Append("\n");
                //strbuil.Append(laygiatri.Giaban);
                //strbuil.Append("\n");
                //strbuil.Append(laygiatri.Thongtinmh);

                //MessageBox.Show(strbuil.ToString());
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnaddmh_Click(object sender, EventArgs e)
        {
            dataget();
        }

        public void datashow()
        {
            cbbloaimh.Text = dtgdsmh.CurrentRow.Cells["loaimh"].Value.ToString();
            txttenmh.Text = dtgdsmh.CurrentRow.Cells["tenmh"].Value.ToString();
            txtthongtinmh.Text = dtgdsmh.CurrentRow.Cells["thongtinmh"].Value.ToString();
            numsoluongmh.Value = int.Parse(dtgdsmh.CurrentRow.Cells["soluongmh"].Value.ToString());
            numgiabanmh.Value = int.Parse(dtgdsmh.CurrentRow.Cells["giaban"].Value.ToString());
            numgianhapmh.Value = int.Parse(dtgdsmh.CurrentRow.Cells["gianhap"].Value.ToString());
            cbbdvtinhmh.Text = dtgdsmh.CurrentRow.Cells["dvtinhmh"].Value.ToString();
        }

        private void dtgdsmh_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            datashow();
        }

        public void editrow()
        {
            dataget();
            laygiatri.Idloaimh = int.Parse(cbbloaimh.SelectedValue.ToString());
            laygiatri.Idmh = int.Parse(dtgdsmh.CurrentRow.Cells["idmh"].Value.ToString());
            data.editrow(laygiatri.Tenmh, laygiatri.Donvitinh, laygiatri.Thongtinmh, laygiatri.Giaban, laygiatri.Idloaimh, laygiatri.Idmh);
        }

        private void btneditmh_Click(object sender, EventArgs e)
        {
            editrow();
            dataload();
        }

        private void dtgdsmh_Sorted(object sender, EventArgs e)
        {
            for (int i = 0; i < dtgdsmh.Rows.Count; i++)
            {
                dtgdsmh.Rows[i].Cells[0].Value = i + 1;
            }
        }
    }
}
