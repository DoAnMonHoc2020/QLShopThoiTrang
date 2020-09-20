using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NhanVien_DAL
    {
        QLShopThoiTrangDataContext da = new QLShopThoiTrangDataContext();
        public NhanVien_DAL() { }
        public IQueryable getDSNhanVien()
        {
            var nv = from n in da.NhanViens select new { n.maNV, n.tenNV, n.NgaySinh, n.DienThoai, n.DiaChi };
            return nv;
        }
        public bool KTraNhanVienTonTai(string ma)
        {
            int nv = da.NhanViens.Where(t => t.maNV == ma).ToList().Count;
            if (nv > 0)
                return false;//nhân viên này đã tồn tại
            return true;//chưa tồn tại
        }
        public void ThemNhanVien(string ma, string ten, string ngaysinh, string diachi, string dienthoai)
        {
            NhanVien nv = new NhanVien();
            nv.maNV = ma;
            nv.tenNV = ten;
            nv.NgaySinh = DateTime.Parse(ngaysinh);
            nv.DiaChi = diachi;
            nv.DienThoai = dienthoai;

            da.NhanViens.InsertOnSubmit(nv);
            da.SubmitChanges();
        }
        public void XoaNhanVien(string ma)
        {
            NhanVien nv = da.NhanViens.Where(t => t.maNV == ma).SingleOrDefault();
            da.NhanViens.DeleteOnSubmit(nv);
            da.SubmitChanges();
        }
        public void SuaNhanVien(string ma, string ten, string ngaysinh, string diachi, string dienthoai)
        {
            NhanVien nv = da.NhanViens.Where(t => t.maNV == ma).SingleOrDefault();
            nv.tenNV = ten;
            nv.NgaySinh = DateTime.Parse(ngaysinh);
            nv.DiaChi = diachi;
            nv.DienThoai = dienthoai;

            da.SubmitChanges();
        }
        public string getMANVLast()
        {
            List<NhanVien> a = da.NhanViens.ToList();
            if (a.Count == 0)// neu chua co nhan vien nao
            { return ""; }
            //da co ma nhan vien
            NhanVien b = da.NhanViens.ToList().OrderByDescending(t => t.maNV).First();
            return b.maNV;
        }
        public bool KTraKhoaNgoai(string ma)
        {
            int hoadon = da.HoaDons.Where(t => t.maNV == ma).ToList().Count;
            int phieunhap = da.PhieuNhapHangs.Where(t => t.maNV == ma).ToList().Count;
            int taikhoan = da.TaiKhoans.Where(t => t.maNV == ma).ToList().Count;
            if (hoadon > 0 || phieunhap > 0 || taikhoan > 0)
                return true;
            return false;
        }
        public IQueryable TimKiemTheoTen(string ten)
        {
            var tk = from t in da.NhanViens where t.tenNV.Contains(ten) == true select new { t.maNV, t.tenNV, t.NgaySinh, t.DienThoai, t.DiaChi };
            return tk;
        }
        public IQueryable TimKiemTheoSDT(string sdt)
        {
            var tk = from t in da.NhanViens where t.DienThoai.Contains(sdt) == true select new { t.maNV, t.tenNV, t.NgaySinh, t.DienThoai, t.DiaChi };
            return tk;
        }
        public string GetTenNV(string ma)
        {
            NhanVien nv = da.NhanViens.Where(t => t.maNV == ma).SingleOrDefault();
            return nv.tenNV;
        }
    }
}
