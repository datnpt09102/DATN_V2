using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BUS
{
    public class nhacungcapBUS
    {
        ConnectDAL ketnoi = new ConnectDAL();

        public DataTable showtable()
        {
            DataTable dt = ketnoi.laydulieu("SELECT * FROM nhacungcap");
            return dt;
        }

        public void addtable(string tenncc, string diachincc, string emailncc, string sdtncc, string sofaxncc)
        {
            ketnoi.thucthisql("INSERT INTO nhacungcap VALUES(N'" + tenncc + "',N'" + diachincc + "',N'" + emailncc + "','" + sofaxncc + "','" + sdtncc + "')");
        }

        public void delrows(int idncc)
        {
            ketnoi.thucthisql("DELETE FROM nhacungcap WHERE idncc = " + idncc + "");
        }

        public void editrow(string tenncc, string diachincc, string emailncc, string sdtncc, string sofaxncc, int idncc)
        {
            ketnoi.thucthisql("UPDATE nhacungcap SET tencc = N'" + tenncc + "', diachincc = N'" + diachincc + "', emailncc = N'" + emailncc + "', sdtncc = '" + sdtncc + "', sofaxncc = '" + sofaxncc + "' WHERE idncc = '" + idncc + "'");
        }
    }
}
