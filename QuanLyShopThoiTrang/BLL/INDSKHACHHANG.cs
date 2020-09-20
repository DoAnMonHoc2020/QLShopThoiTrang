using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class INDSKHACHHANG
    {
        string _STT;

        public string STT
        {
            get { return _STT; }
            set { _STT = value; }
        }
        string _MaKH;

        public string MaKH
        {
            get { return _MaKH; }
            set { _MaKH = value; }
        }
        string _TenKH;

        public string TenKH
        {
            get { return _TenKH; }
            set { _TenKH = value; }
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
        int _DiemTL;

        public int DiemTL
        {
            get { return _DiemTL; }
            set { _DiemTL = value; }
        }
    }
}
