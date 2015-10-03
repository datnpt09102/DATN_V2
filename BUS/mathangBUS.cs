using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BUS
{
    public class mathangBUS
    {
        ConnectDAL ketnoi = new ConnectDAL();
        public DataTable showtable()
        {
            DataTable dt = ketnoi.laydulieu("SELECT mathang.idmh, tenmh, soluong,donvimh,thongtinmh,gianhap,giaban, tenloaimh FROM mathang JOIN loaimathang ON loaimathang.idloaimh= mathang.idloaimh JOIN chitiethdnhap ON mathang.idmh = chitiethdnhap.idmh");
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
        public void editrow(string tenmh, string dvtinhmh, string thongtinmh, string giaban, int idloaimh, int idmh)
        {
            ketnoi.thucthisql("UPDATE mathang SET tenmh = N'" + tenmh + "', donvimh = N'" + dvtinhmh + "',thongtinmh= N'" + thongtinmh + "',giaban= '" + giaban + "', idloaimh = '" + idloaimh + "' WHERE idmh = '" + idmh + "'");
        }

        public DataTable gettable()
        {
            DataTable dt = ketnoi.laydulieu("SELECT * FROM loaimathang");
            return dt;
        }
    }
}
