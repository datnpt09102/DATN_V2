using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BUS
{
    public class chitiethdnhapBUS
    {
        ConnectDAL ketnoi = new ConnectDAL();
        public DataTable gettablemh()
        {
            DataTable dt = ketnoi.laydulieu("SELECT tenmh,soluong, idmh FROM mathang");
            return dt;
        }

        public DataTable getloaimh()
        {
            DataTable dt = ketnoi.laydulieu("SELECT * FROM loaimathang");
            return dt;
        }

        public void addtable()
        {
            ketnoi.thucthisql("");
        }
        public void delrows()
        {
            ketnoi.thucthisql("");
        }
        public void editrow()
        {
            ketnoi.thucthisql("");
        }
    }
}
