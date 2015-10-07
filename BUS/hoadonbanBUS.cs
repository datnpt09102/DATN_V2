using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BUS
{
    public class hoadonbanBUS
    {
        ConnectDAL ketnoi = new ConnectDAL();

        public DataTable showtable()
        {
            DataTable dt = ketnoi.laydulieu("");
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

        public DataTable gettablemh()
        {
            DataTable dt = ketnoi.laydulieu("SELECT tenmh, soluong FROM mathang");
            return dt;
        }

        public DataTable gettableloaimh()
        {
            DataTable dt = ketnoi.laydulieu("SELECT * FROM loaimathang");
            return dt;
        }

        public DataTable gettablekh()
        {
            DataTable dt = ketnoi.laydulieu("SELECT hotenkh FROM khachhang");
            return dt;
        }
    }
}
