using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TaiKhoan_DAL
    {
        QLShopThoiTrangDataContext da = new QLShopThoiTrangDataContext();
        public TaiKhoan_DAL() { }
        public IQueryable getDSTaiKhoan()
        {
            var tk = from t in da.TaiKhoans join nv in da.NhanViens on t.maNV equals nv.maNV  select new { t.TenTK,t.MatKhau,t.Quyen,t.HoatDong,nv.tenNV};
            return tk;
        }
        public bool KTraTonTai(string tentk)
        {
            int tk = da.TaiKhoans.Where(t => t.TenTK == tentk).ToList().Count;
            if (tk > 0)
                return true;// có tài khoản rồi
            return false;
        }
        public void Them(string tentk, string mk, string quyen, string hd, string manv)
        {
            TaiKhoan tk = new TaiKhoan();
            tk.TenTK = tentk;
            tk.MatKhau = mk;
            tk.Quyen = quyen;
            tk.HoatDong = bool.Parse(hd);
            tk.maNV = manv;

            da.TaiKhoans.InsertOnSubmit(tk);
            da.SubmitChanges();
        }
        public void Xoa(string tentk)
        {
            TaiKhoan tk = da.TaiKhoans.Where(t => t.TenTK == tentk).SingleOrDefault();
            da.TaiKhoans.DeleteOnSubmit(tk);
            da.SubmitChanges();

        }
        public void Sua(string tentk,string mk, string quyen, string hoatdong,string manv)
        {
            TaiKhoan tk = da.TaiKhoans.Where(t => t.TenTK == tentk).SingleOrDefault();
            tk.MatKhau = mk;
            tk.Quyen = quyen;
            tk.HoatDong = bool.Parse(hoatdong);
            tk.maNV = manv;
            da.SubmitChanges();
        }
        public IQueryable getNV()
        {
            var nv = from n in da.NhanViens select n;
            return nv;
        }
        public bool KTraKhoaNgoai(string ma)
        {
            int nv = da.NhanViens.Where(t => t.maNV == ma).ToList().Count;
            if (nv > 0)
                return true;
            return false;
        }
        public IQueryable TimKiemTheoTenTK(string tentk)
        {
            var tk = from t in da.TaiKhoans where t.TenTK.Contains(tentk) == true select new { t.TenTK, t.MatKhau, t.Quyen, t.HoatDong, t.maNV };
            return tk;
        }
        public IQueryable TimKiemTheoMaNV(string manv)
        {
            var tk = from t in da.TaiKhoans where t.maNV.Contains(manv) == true select new { t.TenTK, t.MatKhau, t.Quyen, t.HoatDong, t.maNV };
            return tk;
        }
    }
}
