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
        nhanvienDTO laygiatri = new nhanvienDTO();

        private void fnv_Load(object sender, EventArgs e)
        {
            dataload();
            cvload();
            dtgdsnv.AutoGenerateColumns = false;
            dtgdsnv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dtgdsnv.ClearSelection();
        }

        #region Lấy dữ liệu từ Control
        public void getData()
        {
            try
            {
                laygiatri.Tennv = txttennv.Text;

                laygiatri.Ngaysinhnv = dtngaysinhnv.Text;

                if (cbbgioitinhnv.Text == "Nam")
                {
                    laygiatri.Gioitinhnv = Convert.ToString("True");
                }
                else
                {
                    laygiatri.Gioitinhnv = Convert.ToString("False");
                }
                laygiatri.Cmndnv = txtcmndnv.Text;
                laygiatri.Diachinv = txtdiachinv.Text;
                laygiatri.Emailnv = txtmailnv.Text;
                laygiatri.Sdtnv = txtsdtnv.Text;
                laygiatri.Ngayvaolam = dtngayvaolam.Text;
                laygiatri.Idcv = Convert.ToInt16(cbbcvnv.SelectedValue.ToString());
                laygiatri.Anhnv = stranh;

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
            dtngayvaolam.Text = dtgdsnv.CurrentRow.Cells["ngayvaolam"].Value.ToString();
            cbbcvnv.Text = dtgdsnv.CurrentRow.Cells["idcv"].Value.ToString();
            if (!string.IsNullOrEmpty(Convert.ToString(dtgdsnv.CurrentRow.Cells["anhnv"].Value)))
            {
                picanhnv.Image = Image.FromFile(dtgdsnv.CurrentRow.Cells["anhnv"].Value.ToString());
            }
            else
            {
                picanhnv.Image = null;
            }
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

                for (int i = 0; i < dtgdsnv.Rows.Count; i++)
                {
                    dtgdsnv.Rows[i].Cells["stt"].Value = i + 1;

                    if(dtgdsnv.Rows[i].Cells["gioitinhnv"].Value.ToString() == "True")
                    {
                        dtgdsnv.Rows[i].Cells["gioitinh"].Value = "Nam";
                    }
                    else
                    {
                        dtgdsnv.Rows[i].Cells["gioitinh"].Value = "Nữ";
                    }
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
            data.addtable(
                laygiatri.Tennv, 
                laygiatri.Ngaysinhnv, 
                laygiatri.Gioitinhnv, 
                laygiatri.Cmndnv, 
                laygiatri.Diachinv, 
                laygiatri.Emailnv, 
                laygiatri.Sdtnv, 
                laygiatri.Ngayvaolam, 
                laygiatri.Idcv,
                laygiatri.Anhnv);
            datarenew();
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
            datarenew();
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
            laygiatri.Idnv = int.Parse(dtgdsnv.CurrentRow.Cells["idnv"].Value.ToString());
            data.editrow(laygiatri.Tennv, laygiatri.Ngaysinhnv, laygiatri.Gioitinhnv, laygiatri.Cmndnv, laygiatri.Diachinv, laygiatri.Emailnv, laygiatri.Sdtnv, laygiatri.Ngayvaolam, laygiatri.Idcv, laygiatri.Idnv,laygiatri.Anhnv);
            
        }
        private void btneditnv_Click(object sender, EventArgs e)
        {
            try
            {
                editRow();
                dataload();
                datarenew();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //throw ex;
            }
        }

        #endregion

        private void dtgdsnv_Sorted(object sender, EventArgs e)
        {
            for (int i = 0; i < dtgdsnv.Rows.Count; i++)
            {
                dtgdsnv.Rows[i].Cells["stt"].Value = i + 1;

                if (dtgdsnv.Rows[i].Cells["gioitinhnv"].Value.ToString() == "True")
                {
                    dtgdsnv.Rows[i].Cells["gioitinh"].Value = "Nam";
                }
                else
                {
                    dtgdsnv.Rows[i].Cells["gioitinh"].Value = "Nữ";
                }
            }
        }

        public void datarenew()
        {
            try
            {
                txttennv.Clear();
                txtdiachinv.Clear();
                txtmailnv.Clear();
                txtcmndnv.Clear();
                txtsdtnv.Clear();
                cbbcvnv.SelectedIndex = 0;
                cbbgioitinhnv.SelectedIndex = 0;
                //dtngaysinhnv.Text = DateTime.MinValue.ToString();
                dtngayvaolam.Value = DateTime.Now;
                txttennv.Focus();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void btnrefreshnv_Click(object sender, EventArgs e)
        {
            datarenew();
        }

        private void dtgdsnv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (e.ColumnIndex == 1)
            //{
            //    if (e.Value is bool)
            //    {
            //        bool value = (bool)e.Value;
            //        e.Value = (value) ? "Nam" : "Nữ";
            //        e.FormattingApplied = true;
            //    }
            //}
        }

        string stranh;

        private void btnchonanhnv_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.FileName = "Image";

                string fileanh = open.FileName;
                open.DefaultExt = ".jpg";
                open.Filter = "JPG|*.jpg|PNG|*.png|GIF|*.gif"; //"Image (.jpg)|*.jpg"; 
                open.InitialDirectory = @"D:\";

                if (string.IsNullOrEmpty(fileanh))
                    return;
                if (open.ShowDialog() == DialogResult.OK)
                {
                    picanhnv.Image = Image.FromFile(open.FileName);
                }
                stranh = open.FileName;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
    }
}
