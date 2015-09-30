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
        loaikhachhangDTO laythongtin = new loaikhachhangDTO();

        public DataTable showtable()
        {
            DataTable dt = ketnoi.laydulieu("select * from loaikhachhang");
            return dt;
        }
        public void addtable(String tenloaikh)
        {
            ketnoi.thucthisql("insert into loaikhachhang(tenloaikh) values(N'" + tenloaikh + "')");
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
