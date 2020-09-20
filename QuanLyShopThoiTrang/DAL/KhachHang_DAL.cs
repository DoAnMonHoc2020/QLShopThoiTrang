using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class KhachHang_DAL
    {
        QLShopThoiTrangDataContext da = new QLShopThoiTrangDataContext();
        public KhachHang_DAL() { }
        public List<KhachHang> getKhachHang()
        {
            var kh = da.KhachHangs.ToList();
            return kh;
        }
        public IQueryable getDSKhachHang()
        {
            var nv = from n in da.KhachHangs select new { n.maThe, n.tenKH, n.DiaChi, n.DienThoai, n.DiemTL };
            return nv;
        }
        public bool KTraKhachHangTonTai(string ma)
        {
            int nv = da.KhachHangs.Where(t => t.maThe == ma).ToList().Count;
            if (nv > 0)
                return false;//Khách hàng này đã tồn tại
            return true;//chưa tồn tại
        }
        public void ThemKhachHang(string ma, string ten, string diachi, string dienthoai,int diem)
        {
            KhachHang nv = new KhachHang();
            nv.maThe = ma;
            nv.tenKH = ten;
            nv.DiaChi = diachi;
            nv.DienThoai = dienthoai;
            nv.DiemTL = diem;

            da.KhachHangs.InsertOnSubmit(nv);
            da.SubmitChanges();
        }
        public void XoaKhachHang(string ma)
        {
            KhachHang nv = da.KhachHangs.Where(t => t.maThe == ma).SingleOrDefault();
            da.KhachHangs.DeleteOnSubmit(nv);
            da.SubmitChanges();
        }
        public void SuaKhachHang(string ma, string ten, string diachi, string dienthoai,int diem)
        {
            KhachHang nv = da.KhachHangs.Where(t => t.maThe == ma).SingleOrDefault();
            nv.tenKH = ten;
            nv.DiaChi = diachi;
            nv.DienThoai = dienthoai;
            nv.DiemTL = diem;

            da.SubmitChanges();
        }
        public string getMAKHLast()
        {
            List<KhachHang> a = da.KhachHangs.ToList();
            if (a.Count == 0)// neu chua co khách hàng nao
            { return ""; }
            //da co ma Khách hàng
            KhachHang b = da.KhachHangs.ToList().OrderByDescending(t => t.maThe).First();
            return b.maThe;
        }
        public bool KTraKhoaNgoai(string ma)
        {
            int hoadon = da.HoaDons.Where(t => t.maThe == ma).ToList().Count;
            if (hoadon > 0 )
                return true;
            return false;
        }
        public IQueryable TimKiemTheoTen(string ten)
        {
            var tk = from t in da.KhachHangs where t.tenKH.Contains(ten) == true select new { t.maThe, t.tenKH, t.DiaChi, t.DienThoai, t.DiemTL };
            return tk;
        }
        public IQueryable TimKiemTheoSDT(string sdt)
        {
            var tk = from t in da.KhachHangs where t.DienThoai.Contains(sdt) == true select new { t.maThe, t.tenKH, t.DiaChi, t.DienThoai, t.DiemTL };
            return tk;
        }
    }
}
