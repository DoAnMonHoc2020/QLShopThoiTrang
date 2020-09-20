using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class INDSNCC
    {
        string _STT;

        public string STT
        {
            get { return _STT; }
            set { _STT = value; }
        }
        string _MaNCC;

        public string MaNCC
        {
            get { return _MaNCC; }
            set { _MaNCC = value; }
        }
        string _TenNCC;

        public string TenNCC
        {
            get { return _TenNCC; }
            set { _TenNCC = value; }
        }
        string _DiaChi;

        public string DiaChi
        {
            get { return _DiaChi; }
            set { _DiaChi = value; }
        }
        string _DienThoai;

        public string DienThoai
        {
            get { return _DienThoai; }
            set { _DienThoai = value; }
        }
    }
}
