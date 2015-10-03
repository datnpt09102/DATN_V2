using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BUS
{
    public class khachhangBUS
    {
        ConnectDAL ketnoi = new ConnectDAL();
        public DataTable showtable()
        {
            DataTable dt = ketnoi.laydulieu("SELECT idkh,hotenkh,ngaysinhkh,gioitinhkh,cmndkh,sdtkh,diachikh,emailkh,tenloaikh FROM khachhang join loaikhachhang ON khachhang.idloaikh = loaikhachhang.idloaikh");
            return dt;
        }
        public void addtable(string tenkh, string diachikh, string gioitinhkh, string ngaysinhkh, string emailkh, string cmndkh, string sdtkh, int idloaikh)
        {
            ketnoi.thucthisql("SET DATEFORMAT dmy INSERT INTO khachhang VALUES(N'" + tenkh + "','" + ngaysinhkh + "',N'" + gioitinhkh + "',N'" + cmndkh + "',N'" + sdtkh + "',N'" + diachikh + "',N'" + emailkh + "','" + idloaikh + "')");
        }
        public void delrows(int idkh)
        {
            ketnoi.thucthisql("DELETE FROM khachhang WHERE idkh = " + idkh + "");
        }
        public void editrow(string tenkh, string diachikh, string gioitinhkh, string ngaysinhkh, string emailkh, string cmndkh, string sdtkh, int idloaikh, int idkh)
        {
            ketnoi.thucthisql("SET DATEFORMAT dmy UPDATE khachhang SET hotenkh=N'" + tenkh + "',ngaysinhkh='" + ngaysinhkh + "',gioitinhkh=N'" + gioitinhkh + "',cmndkh=N'" + cmndkh + "',sdtkh=N'" + sdtkh + "',diachikh=N'" + diachikh + "',emailkh=N'" + emailkh + "',idloaikh='" + idloaikh + "' WHERE idkh='" + idkh + "'");
        }
        public DataTable gettable()
        {
            DataTable dt = ketnoi.laydulieu("SELECT * FROM loaikhachhang");
            return dt;
        }
    }
}
