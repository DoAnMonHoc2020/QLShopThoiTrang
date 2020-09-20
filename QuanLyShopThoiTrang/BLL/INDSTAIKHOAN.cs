using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class INDSTAIKHOAN
    {
        string _STT;

        public string STT
        {
            get { return _STT; }
            set { _STT = value; }
        }
        string _TenTK;

        public string TenTK
        {
            get { return _TenTK; }
            set { _TenTK = value; }
        }
        string _MatKhau;

        public string MatKhau
        {
            get { return _MatKhau; }
            set { _MatKhau = value; }
        }
        string _Quyen;

        public string Quyen
        {
            get { return _Quyen; }
            set { _Quyen = value; }
        }
        string _NhanVien;

        public string NhanVien
        {
            get { return _NhanVien; }
            set { _NhanVien = value; }
        }
        string _HoatDong;

        public string HoatDong
        {
            get { return _HoatDong; }
            set { _HoatDong = value; }
        }
    }
}
