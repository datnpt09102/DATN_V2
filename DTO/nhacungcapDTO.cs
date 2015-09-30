using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class nhacungcapDTO
    {
        private int _idncc;

        public int Idncc
        {
            get { return _idncc; }
            set { _idncc = value; }
        }
        private string _tenncc;

        public string Tenncc
        {
            get { return _tenncc; }
            set { _tenncc = value; }
        }
        private string _diachincc;

        public string Diachincc
        {
            get { return _diachincc; }
            set { _diachincc = value; }
        }
        private string _emailncc;

        public string Emailncc
        {
            get { return _emailncc; }
            set { _emailncc = value; }
        }
        private string _sofaxncc;

        public string Sofaxncc
        {
            get { return _sofaxncc; }
            set { _sofaxncc = value; }
        }
        private string _sdtncc;

        public string Sdtncc
        {
            get { return _sdtncc; }
            set { _sdtncc = value; }
        }
    }
}
