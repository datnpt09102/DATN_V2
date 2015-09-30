using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BUS
{
    public class nhanvienBUS
    {
        ConnectDAL ketnoi = new ConnectDAL();

        public DataTable showtable()
        {
            DataTable dt = ketnoi.laydulieu("SELECT idnv,tennv,ngaysinhnv,gioitinh,cmndnv,sdtnv,diachinv,emailnv,ngayvaolam,chucvu.tencv FROM nhanvien join chucvu ON nhanvien.idcv = chucvu.idcv");
            return dt;
        }
        public void addtable(string tennv, string ngaysinhnv, string gioitinh, string cmndnv, string diachinv, string emailnv, string sdtnv, string ngayvaolam, int idcv)
        {
            ketnoi.thucthisql("SET DATEFORMAT dmy  INSERT INTO nhanvien(tennv,ngaysinhnv,gioitinh,cmndnv,diachinv,emailnv,sdtnv,ngayvaolam,idcv) VALUES(N'" + tennv + "','" + ngaysinhnv + "','" + gioitinh + "','" + cmndnv + "',N'" + diachinv + "',N'" + emailnv + "','" + sdtnv + "','" + ngayvaolam + "','" + idcv + "')");
        }
        public void delrows(int idnv)
        {
            ketnoi.thucthisql("DELETE FROM nhanvien WHERE idnv = " + idnv + "");
        }
        public void editrow(string tennv, string ngaysinhnv, string gioitinh, string cmndnv, string diachinv, string emailnv, string sdtnv, string ngayvaolam, int idcv, int idnv)
        {
            ketnoi.thucthisql("SET DATEFORMAT dmy UPDATE nhanvien SET tennv = N'" + tennv + "',ngaysinhnv = '" + ngaysinhnv + "',gioitinh = '" + gioitinh + "',cmndnv = '" + cmndnv + "',diachinv=N'" + diachinv + "',emailnv='" + emailnv + "',sdtnv='" + sdtnv + "',ngayvaolam='" + ngayvaolam + "',idcv='" + idcv + "' WHERE idnv='" + idnv + "'");
        }
        public DataTable gettable()
        {
            DataTable dt = ketnoi.laydulieu("SELECT * FROM chucvu");
            return dt;
        }
    }
}
