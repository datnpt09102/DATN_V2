using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BUS
{
    public class calamBUS
    {
        ConnectDAL ketnoi = new ConnectDAL();

        public DataTable showtable()
        {
            DataTable dt = ketnoi.laydulieu("SELECT * FROM calam");
            return dt;
        }

        public void addtable(string tenca, string thoigiancl)
        {
            ketnoi.thucthisql("INSERT INTO calam values(N'" + tenca + "',N'" + thoigiancl + "')");
        }

        public void delrows(int idcl)
        {
            ketnoi.thucthisql("DELETE FROM calam WHERE idcl = " + idcl + "");
        }

        public void editrow(int idcl, string tenca, string thoigiancl)
        {
            ketnoi.thucthisql("UPDATE calam SET tencl = N'" + tenca + "', thoigiancl = N'" + thoigiancl + "' WHERE idcl = '" + idcl + "'");
        }
    }
}
