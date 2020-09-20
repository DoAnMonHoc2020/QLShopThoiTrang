using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class INPHIEUNHAP
    {
        string _STT;

        public string STT
        {
            get { return _STT; }
            set { _STT = value; }
        }
        string _MaPN;

        public string MaPN
        {
            get { return _MaPN; }
            set { _MaPN = value; }
        }
        string _TENHANG;

        public string TENHANG
        {
            get { return _TENHANG; }
            set { _TENHANG = value; }
        }
        int _SOLUONG;

        public int SOLUONG
        {
            get { return _SOLUONG; }
            set { _SOLUONG = value; }
        }
        float _DONGIA;

        public float DONGIA
        {
            get { return _DONGIA; }
            set { _DONGIA = value; }
        }
        float _THANHTIEN;

        public float THANHTIEN
        {
            get { return _THANHTIEN; }
            set { _THANHTIEN = value; }
        }

    }
}
