using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;
using DTO;

namespace BUS
{
    public class loaikhachhangBUS
    {
        ConnectDAL ketnoi = new ConnectDAL();

        public DataTable showtable()
        {
            DataTable dt = ketnoi.laydulieu("select * from loaikhachhang");
            return dt;
        }
        public void addtable(string tenloaikh)
        {
            ketnoi.thucthisql("INSERT INTO loaikhachhang values(N'" + tenloaikh + "')");
        }
        public void delrows(int idloaikh)
        {
            ketnoi.thucthisql("DELETE loaikhachhang WHERE idloaikh = N'" + idloaikh + "'");
        }
 
        public void editrow(int idloaikh, string tenloaikh)
        {
            ketnoi.thucthisql("UPDATE loaikhachhang SET tenloaikh = N'" + tenloaikh + "' WHERE idloaikh = '" + idloaikh + "'");
        }
    }
}
