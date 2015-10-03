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
    public partial class fkh : Form
    {
        public fkh()
        {
            InitializeComponent();
        }

        private void btnxemloaikh_Click(object sender, EventArgs e)
        {
            floaikh frm = new floaikh();
            frm.ShowDialog();
        }

        khachhangBUS data = new khachhangBUS();
        khachhangDTO laygiatri = new khachhangDTO();

        private void fkh_Load(object sender, EventArgs e)
        {
            dataload();
            cvload();
        }
        private void dataload()
        {
            dtgdskh.DataSource = data.showtable();
            for (int i = 0; i < dtgdskh.Rows.Count; i++)
            {
                dtgdskh.Rows[i].Cells[0].Value = i + 1;

                if (dtgdskh.Rows[i].Cells["gioitinh"].Value.ToString() == "True")
                {
                    dtgdskh.Rows[i].Cells["gioitinhkh"].Value = "Nam";
                }
                else
                {
                    dtgdskh.Rows[i].Cells["gioitinhkh"].Value = "Nữ";
                }
            }
        }

        public void dataget()
        {
            laygiatri.Hotenkh = txttenkh.Text;
            laygiatri.Ngaysinhkh = dtngaysinhkh.Text;
            if (cbgioitinhkh.Text == "Nam")
            {
                laygiatri.Gioitinhkh = Convert.ToString("True");
            }
            else
            {
                laygiatri.Gioitinhkh = Convert.ToString("False");
            }
            laygiatri.Cmndkh = txtcmndkh.Text;
            laygiatri.Sdtkh = txtsdtkh.Text;
            laygiatri.Diachikh = txtdiachikh.Text;
            laygiatri.Email = txtmailkh.Text;
            laygiatri.Idloaikh = int.Parse(cbloaikh.SelectedValue.ToString());
        }

        public void cvload()
        {
            cbloaikh.DataSource = data.gettable();
            cbloaikh.DisplayMember = "tenloaikh";
            cbloaikh.ValueMember = "idloaikh";
        }

        public void addtable()
        {
            data.addtable(laygiatri.Hotenkh, laygiatri.Diachikh, laygiatri.Gioitinhkh, laygiatri.Ngaysinhkh, laygiatri.Email, laygiatri.Cmndkh, laygiatri.Sdtkh, laygiatri.Idloaikh);
            dataload();
        }

        public void delrows()
        {
            laygiatri.Idkh = Convert.ToInt16(dtgdskh.CurrentRow.Cells["idkh"].Value.ToString());
            //MessageBox.Show(dtgdskh.CurrentRow.Cells["idkh"].Value.ToString());
            try
            {
                data.delrows(laygiatri.Idkh);
                dataload();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void editrow()
        {
            dataget();
            laygiatri.Idkh = Convert.ToInt16(dtgdskh.CurrentRow.Cells["idkh"].Value.ToString());
            data.editrow(laygiatri.Hotenkh,laygiatri.Diachikh,laygiatri.Gioitinhkh,laygiatri.Ngaysinhkh,laygiatri.Email,laygiatri.Cmndkh,laygiatri.Sdtkh,laygiatri.Idloaikh,laygiatri.Idkh);
            dataload();
        }

        private void btnaddkh_Click(object sender, EventArgs e)
        {
            dataget();
            addtable();
            dataload();
            #region
            //StringBuilder strbuil = new StringBuilder();
            //strbuil.Append(laygiatri.Hotenkh);
            //strbuil.Append("\n");
            //strbuil.Append(laygiatri.Ngaysinhkh);
            //strbuil.Append("\n");
            //strbuil.Append(laygiatri.Gioitinhkh);
            //strbuil.Append("\n");
            //strbuil.Append(laygiatri.Cmndkh);
            //strbuil.Append("\n");
            //strbuil.Append(laygiatri.Diachikh);
            //strbuil.Append("\n");
            //strbuil.Append(laygiatri.Email);
            //strbuil.Append("\n");
            //strbuil.Append(laygiatri.Sdtkh);
            //strbuil.Append("\n");
            //strbuil.Append(laygiatri.Idloaikh);

            //MessageBox.Show(strbuil.ToString());
            #endregion
        }

        private void dtgdskh_Sorted(object sender, EventArgs e)
        {
            for (int i = 0; i < dtgdskh.Rows.Count; i++)
            {
                dtgdskh.Rows[i].Cells[0].Value = i + 1;

                if (dtgdskh.Rows[i].Cells["gioitinh"].Value.ToString() == "True")
                {
                    dtgdskh.Rows[i].Cells["gioitinhkh"].Value = "Nam";
                }
                else
                {
                    dtgdskh.Rows[i].Cells["gioitinhkh"].Value = "Nữ";
                }
            }
        }

        private void btndelkh_Click(object sender, EventArgs e)
        {
            delrows();
        }

        private void dtgdskh_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txttenkh.Text = dtgdskh.CurrentRow.Cells["tenkh"].Value.ToString();
            txtcmndkh.Text = dtgdskh.CurrentRow.Cells["cmndkh"].Value.ToString();
            txtdiachikh.Text = dtgdskh.CurrentRow.Cells["diachikh"].Value.ToString();
            txtmailkh.Text = dtgdskh.CurrentRow.Cells["mailkh"].Value.ToString();
            txtsdtkh.Text = dtgdskh.CurrentRow.Cells["sdtkh"].Value.ToString();
            if (dtgdskh.CurrentRow.Cells["gioitinh"].Value.ToString() == "True")
            {
                cbgioitinhkh.Text = "Nam";
            }
            else
            {
                cbgioitinhkh.Text = "Nữ";
            }
            cbloaikh.Text = dtgdskh.CurrentRow.Cells["loaikh"].Value.ToString();
        }

        private void btneditkh_Click(object sender, EventArgs e)
        {
            editrow();
        }
    }
}
