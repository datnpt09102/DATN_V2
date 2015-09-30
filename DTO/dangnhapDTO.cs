using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class dangnhapDTO
    {
        private string _taikhoan;

        public string Taikhoan
        {
            get { return _taikhoan; }
            set { _taikhoan = value; }
        }
        private string _matkhau;

        public string Matkhau
        {
            get { return _matkhau; }
            set { _matkhau = value; }
        }

        public dangnhapDTO()
        {
            Matkhau = null;
            Taikhoan = null;
        }
        public dangnhapDTO(string matkhau, string taikhoan)
        {
            Matkhau = matkhau;
            Taikhoan = taikhoan;
        }
    }
}
