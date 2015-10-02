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
    public partial class fncc : Form
    {
        public fncc()
        {
            InitializeComponent();
        }

        private void fncc_Load(object sender, EventArgs e)
        {
            dataload();
        }

        // Tạo đối tượng lấy các phương thức hoặc hàm từ Class nhacungcapBUS
        nhacungcapBUS data = new nhacungcapBUS();

        // Tạo đối tượng nhập các giá trị vào Class nhacungcapDTO
        nhacungcapDTO laygiatri = new nhacungcapDTO();


        // Hàm đổ dữ liệu vào DataGridView
        private void dataload()
        {
            
            dtgdsncc.DataSource = data.showtable();

            for (int i = 0; i < dtgdsncc.Rows.Count; i++)
            {
                dtgdsncc.Rows[i].Cells[0].Value = i + 1;
            }
        }

        public void datarenew()
        {
            txttenncc.Clear();
            txtdiachincc.Clear();
            txtmailncc.Clear();
            txtsdtncc.Clear();
            txtfaxncc.Clear();
        }

        //public void datacheck(KeyPressEventArgs e)
        //{
        //    char c = e.KeyChar;
        //    if (char.IsDigit(c) == true)
        //    {
        //        MessageBox.Show("Chỉ được phép nhập kí tự là chữ");
        //    }
        //}

        public void dataget()
        {
            laygiatri.Tenncc = txttenncc.Text;
            laygiatri.Diachincc = txtdiachincc.Text;
            laygiatri.Emailncc = txtmailncc.Text;
            laygiatri.Sdtncc = txtsdtncc.Text;
            laygiatri.Sofaxncc = txtfaxncc.Text;
        }

        public void datashow()
        {
            try
            {
                txttenncc.Text = dtgdsncc.CurrentRow.Cells["tenncc"].Value.ToString();
                txtdiachincc.Text = dtgdsncc.CurrentRow.Cells["diachincc"].Value.ToString();
                txtmailncc.Text = dtgdsncc.CurrentRow.Cells["mailncc"].Value.ToString();
                txtsdtncc.Text = dtgdsncc.CurrentRow.Cells["sdtncc"].Value.ToString();
                txtfaxncc.Text = dtgdsncc.CurrentRow.Cells["sofaxncc"].Value.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        public void addtable()
        {
            dataget();
            data.addtable(laygiatri.Tenncc,laygiatri.Diachincc,laygiatri.Emailncc,laygiatri.Sdtncc,laygiatri.Sofaxncc);
            dataload();
            datarenew();
        }

        public void delrows()
        {
            data.delrows(int.Parse(dtgdsncc.CurrentRow.Cells["idncc"].Value.ToString()));
            dataload();
            datarenew();
        }

        public void editrow()
        {
            try
            {
                dataget();
                laygiatri.Idncc = int.Parse(dtgdsncc.CurrentRow.Cells["idncc"].Value.ToString());
                data.editrow(laygiatri.Tenncc, laygiatri.Diachincc, laygiatri.Emailncc, laygiatri.Sdtncc, laygiatri.Sofaxncc, laygiatri.Idncc);
                dataload();
                datarenew();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnrefreshncc_Click(object sender, EventArgs e)
        {
            datarenew();
        }
        
        private void btneditncc_Click(object sender, EventArgs e)
        {
            editrow();
        }

        private void btndelncc_Click(object sender, EventArgs e)
        {
            delrows();
        }

        private void dtgdsncc_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            datashow();
        }

        private void btnaddncc_Click_1(object sender, EventArgs e)
        {
            addtable();
        }

        private void txtmailncc_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

    }
}
