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
    }
}
