using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class KhachHang_BLL
    {
        KhachHang_DAL kh_dal = new KhachHang_DAL();
        public KhachHang_BLL() { }
        public List<KhachHang> getKhachHang()
        {
            return kh_dal.getKhachHang();
        }
        public IQueryable getDSKhachHang()
        {
            return kh_dal.getDSKhachHang();
        }
        public bool KTraKhachHangTonTai(string ma)
        {
            return kh_dal.KTraKhachHangTonTai(ma);
        }
        public void ThemKhachHang(string ma, string ten, string diachi, string dienthoai, int diem)
        {
            kh_dal.ThemKhachHang(ma, ten, diachi, dienthoai, diem);
        }
        public void XoaKhachHang(string ma)
        {
            kh_dal.XoaKhachHang(ma);
        }
        public void SuaKhachHang(string ma, string ten, string diachi, string dienthoai, int diem)
        {
            kh_dal.SuaKhachHang(ma, ten, diachi, dienthoai, diem);
        }
        public string getMAKHLast()
        {
            return kh_dal.getMAKHLast();
        }
        public bool KTraKhoaNgoai(string ma)
        {
            return kh_dal.KTraKhoaNgoai(ma);
        }
        public IQueryable TimKiemTheoTen(string ten)
        {
            return kh_dal.TimKiemTheoTen(ten);
        }
        public IQueryable TimKiemTheoSDT(string sdt)
        {
            return kh_dal.TimKiemTheoSDT(sdt);
        }
    }
}
