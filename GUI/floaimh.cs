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
    public partial class floaimh : Form
    {
        public floaimh()
        {
            InitializeComponent();
        }

        loaimathangBUS data = new loaimathangBUS();
        loaimathangDTO laygiatri = new loaimathangDTO();
        
        private void floaimh_Load(object sender, EventArgs e)
        {
            dataload();
        }

        private void dataload()
        {
            dtgdsloaimh.DataSource = data.showtable();
            for (int i = 0; i < dtgdsloaimh.Rows.Count; i++)
            {
                dtgdsloaimh.Rows[i].Cells[0].Value = i + 1;
            }
        }

        public void addtable()
        {
            try
            {
                laygiatri.Tenloaimh = txttenloaimh.Text;
                data.addtable(laygiatri.Tenloaimh);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void clear()
        {
            txttenloaimh.Text = null;
        }

        private void btnaddloaimh_Click(object sender, EventArgs e)
        {
            addtable();
            dataload();
            clear();
        }

        public void editrow()
        {
            laygiatri.Tenloaimh = txttenloaimh.Text;
            laygiatri.Idloaimh = int.Parse(dtgdsloaimh.CurrentRow.Cells["idloaimh"].Value.ToString());
            data.editrow(laygiatri.Idloaimh,laygiatri.Tenloaimh);
            dataload();
            clear();
        }

        private void btneditloaimh_Click(object sender, EventArgs e)
        {
            editrow();
        }

        private void dtgdsloaimh_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txttenloaimh.Text = dtgdsloaimh.CurrentRow.Cells["tenloaimh"].Value.ToString();
        }

        private void dtgdsloaimh_Sorted(object sender, EventArgs e)
        {
            for (int i = 0; i < dtgdsloaimh.Rows.Count; i++)
            {
                dtgdsloaimh.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void btndelloaimh_Click(object sender, EventArgs e)
        {
            laygiatri.Idloaimh = int.Parse(dtgdsloaimh.CurrentRow.Cells["idloaimh"].Value.ToString());
            data.delrows(laygiatri.Idloaimh);
            dataload();
            clear();
        }
    }
}
