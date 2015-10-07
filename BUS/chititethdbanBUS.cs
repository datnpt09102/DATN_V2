using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BUS
{
    public class chititethdbanBUS
    {
        ConnectDAL ketnoi = new ConnectDAL();
        public DataTable showtable()
        {
            DataTable dt = ketnoi.laydulieu("SELECT idhdban,tenmh,soluongmhban,giaban,thanhtien,donvimh FROM chitiethdban join mathang on chitiethdban.idmh = mathang.idmh");
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
