using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class NhanVien_BLL
    {
        NhanVien_DAL nv_dal = new NhanVien_DAL();
        public NhanVien_BLL() { }
        public IQueryable getDSNhanVien()
        {
            return nv_dal.getDSNhanVien();
        }
        public bool KTraNhanVienTonTai(string ma)
        {
            return nv_dal.KTraNhanVienTonTai(ma);
        }
        public void ThemNhanVien(string ma, string ten, string ngaysinh, string diachi, string dienthoai)
        {
            nv_dal.ThemNhanVien(ma, ten, ngaysinh, diachi, dienthoai);
        }
        public void XoaNhanVien(string ma)
        {
            nv_dal.XoaNhanVien(ma);
        }
        public void SuaNhanVien(string ma, string ten, string ngaysinh, string diachi, string dienthoai)
        {
            nv_dal.SuaNhanVien(ma, ten, ngaysinh, diachi, dienthoai);
        }
        public string getMANVLast()
        {
            return nv_dal.getMANVLast();
        }
        public bool KTraKhoaNgoai(string ma)
        {
            return nv_dal.KTraKhoaNgoai(ma);
        }
        public IQueryable TimKiemTheoTen(string ten)
        {
            return nv_dal.TimKiemTheoTen(ten);
        }
        public IQueryable TimKiemTheoSDT(string sdt)
        {
            return nv_dal.TimKiemTheoSDT(sdt);
        }
        public string GetTenNV(string ma)
        {
            return nv_dal.GetTenNV(ma);
        }
    }
}
