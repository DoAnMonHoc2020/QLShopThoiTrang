using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class INDSHANG
    {
        string _STT;

        public string STT
        {
            get { return _STT; }
            set { _STT = value; }
        }
        string _MaHH;

        public string MaHH
        {
            get { return _MaHH; }
            set { _MaHH = value; }
        }
        string _TenHH;

        public string TenHH
        {
            get { return _TenHH; }
            set { _TenHH = value; }
        }
        float _DonGia;

        public float DonGia
        {
            get { return _DonGia; }
            set { _DonGia = value; }
        }
        string _Loai;

        public string Loai
        {
            get { return _Loai; }
            set { _Loai = value; }
        }
        int _SoLuongTon;

        public int SoLuongTon
        {
            get { return _SoLuongTon; }
            set { _SoLuongTon = value; }
        }
        string _NCC;

        public string NCC
        {
            get { return _NCC; }
            set { _NCC = value; }
        }
    }
}
