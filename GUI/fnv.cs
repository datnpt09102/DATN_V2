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
    public partial class fnv : Form
    {
        
        public fnv()
        {
            InitializeComponent();
        }

        #region Liên kết Form
        private void btnchamluongnv_Click(object sender, EventArgs e)
        {
            fchamluong frm = new fchamluong();
            frm.ShowDialog();
        }

        private void btnviewcv_Click(object sender, EventArgs e)
        {
            fcv frm = new fcv();
            frm.ShowDialog();
        }
        #endregion

        nhanvienBUS data = new nhanvienBUS();
        nhanvienDTO laydulieu = new nhanvienDTO();

        private void fnv_Load(object sender, EventArgs e)
        {
            dataload();
            cvload();
        }

        #region Lấy dữ liệu từ Control
        public void getData()
        {
            try
            {
                laydulieu.Tennv = txttennv.Text;

                laydulieu.Ngaysinhnv = dtngaysinhnv.Text;

                if (cbbgioitinhnv.Text == "Nam")
                {
                    laydulieu.Gioitinhnv = Convert.ToString("True");
                }
                else
                {
                    laydulieu.Gioitinhnv = Convert.ToString("False");
                }
                laydulieu.Cmndnv = txtcmndnv.Text;
                laydulieu.Diachinv = txtdiachinv.Text;
                laydulieu.Emailnv = txtmailnv.Text;
                laydulieu.Sdtnv = txtsdtnv.Text;

                laydulieu.Ngayvaolam = dtpngayvaolam.Text;
                laydulieu.Idcv = Convert.ToInt16(cbbcvnv.SelectedValue.ToString());
                laydulieu.Anhnv = picanhnv.Image.ToString();

                #region
                //StringBuilder strbuil = new StringBuilder();
                //strbuil.Append(laydulieu.Tennv);
                //strbuil.Append("\n");
                //strbuil.Append(laydulieu.Ngaysinhnv);
                //strbuil.Append("\n");
                //strbuil.Append(laydulieu.Gioitinh);
                //strbuil.Append("\n");
                //strbuil.Append(laydulieu.Cmndnv);
                //strbuil.Append("\n");
                //strbuil.Append(laydulieu.Diachinv);
                //strbuil.Append("\n");
                //strbuil.Append(laydulieu.Emailnv);
                //strbuil.Append("\n");
                //strbuil.Append(laydulieu.Sdtnv);
                //strbuil.Append("\n");
                //strbuil.Append(laydulieu.Ngayvaolam);
                //strbuil.Append("\n");
                //strbuil.Append(laydulieu.Idcv);
                //strbuil.Append("\n");
                //strbuil.Append(laydulieu.Anhnv);

                //MessageBox.Show(strbuil.ToString());
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        public void cvload()
        {
            cbbcvnv.DataSource = data.gettable();
            cbbcvnv.DisplayMember = "tencv";
            cbbcvnv.ValueMember = "idcv";
        }

        #region Hiển thị dữ liệu lên Control

        public void dataShow()
        {
            txttennv.Text = dtgdsnv.CurrentRow.Cells["tennv"].Value.ToString();
            dtngaysinhnv.Text = dtgdsnv.CurrentRow.Cells["ngaysinhnv"].Value.ToString();
            if (dtgdsnv.CurrentRow.Cells["gioitinhnv"].Value.ToString() == "True")
            {
                cbbgioitinhnv.Text = "Nam";
            }
            else
            {
                cbbgioitinhnv.Text = "Nữ";
            }
            txtcmndnv.Text = dtgdsnv.CurrentRow.Cells["cmndnv"].Value.ToString();
            txtdiachinv.Text = dtgdsnv.CurrentRow.Cells["diachinv"].Value.ToString();
            txtmailnv.Text = dtgdsnv.CurrentRow.Cells["emailnv"].Value.ToString();
            txtsdtnv.Text = dtgdsnv.CurrentRow.Cells["sdtnv"].Value.ToString();
            dtpngayvaolam.Text = dtgdsnv.CurrentRow.Cells["ngayvaolam"].Value.ToString();
            cbbcvnv.Text = dtgdsnv.CurrentRow.Cells["idcv"].Value.ToString();
        }

        private void dtgdsnv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataShow();
        }
        #endregion

        public void dataload()
        {
            try
            {
                dtgdsnv.DataSource = data.showtable();

                for (int i = 0; i < dtgdsnv.Rows.Count - 1; i++)
                {
                    dtgdsnv.Rows[i].Cells["stt"].Value = i + 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #region Thêm nhân viên

        public void addtable()
        {
            //data.addtable(laydulieu.Tennv,laydulieu.Ngaysinhnv,laydulieu.Gioitinh,laydulieu.Cmndnv,laydulieu.Diachinv,laydulieu.Emailnv,laydulieu.Sdtnv,laydulieu.Ngayvaolam,laydulieu.Idcv);
        }

        private void btnaddnv_Click(object sender, EventArgs e)
        {
            try
            {
                getData();
                addtable();
                dataload();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region Xóa nhân viên

        public void delRows()
        {
            data.delrows(int.Parse(dtgdsnv.CurrentRow.Cells["idnv"].Value.ToString()));
        }

        private void btndelnv_Click(object sender, EventArgs e)
        {
            try
            {
                delRows();
                dataload();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region Sửa thông tin Nhân viên

        public void editRow()
        {
            getData();
            laydulieu.Idnv = int.Parse(dtgdsnv.CurrentRow.Cells["idnv"].Value.ToString());            
            //data.editrow(laydulieu.Tennv,laydulieu.Ngaysinhnv,laydulieu.Gioitinh,laydulieu.Cmndnv,laydulieu.Diachinv,laydulieu.Emailnv,laydulieu.Sdtnv,laydulieu.Ngayvaolam,laydulieu.Idcv,laydulieu.Idnv);
        }
        private void btneditnv_Click(object sender, EventArgs e)
        {
            try
            {
                editRow();
                dataload();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

    }
}
