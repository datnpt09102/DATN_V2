using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BUS
{
    public class loaimathangBUS
    {
        ConnectDAL ketnoi = new ConnectDAL();
        public DataTable showtable()
        {
            DataTable dt = ketnoi.laydulieu("SELECT * FROM loaimathang");
            return dt;
        }
        public void addtable(string tenloaimh)
        {
            ketnoi.thucthisql("INSERT INTO loaimathang VALUES('" + tenloaimh + "')");
        }
        public void delrows(int idmh)
        {
            ketnoi.thucthisql("DELETE FROM loaimathang WHERE idloaimh = '" + idmh + "'");
        }
        public void editrow(int idloaimh, string tenloaimh)
        {
            ketnoi.thucthisql("UPDATE loaimathang SET tenloaimh = N'" + tenloaimh + "' WHERE idloaimh = '" + idloaimh + "'");
        }
    }
}
