using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PhieuNhap_DAL
    {
        QLShopThoiTrangDataContext da = new QLShopThoiTrangDataContext();
        public PhieuNhap_DAL() { }
        public IQueryable GetCTPN(string ma)
        {
            var ct = from t in da.ChiTietPhieuNhapHangs join h in da.HangHoas on t.maMH equals h.maMH select new { t.maMH,h.tenMH,t.SoLuong,t.DonGia};
            return ct;
        }
        //Kiem tra phieu co ton tai chua
        public bool KTraTonTai(string ma)
        {
            int hd = da.PhieuNhapHangs.Where(t => t.maPN == ma).ToList().Count;
            if (hd > 0)
                return false;
            return true;
        }
        //them phieu nhap
        public void ThemPhieuNhap(string ma, string ngaylap, string manv)
        {
            PhieuNhapHang hd = new PhieuNhapHang();
            hd.maPN = ma;
            hd.NgayNhap = DateTime.Parse(ngaylap);
            hd.maNV = manv;

            da.PhieuNhapHangs.InsertOnSubmit(hd);
            da.SubmitChanges();
        }
       
        //them hàng hóa vào phieu nhap vào
        public void ThemHHVaoPhieuNhap(string ma, string mahh, int sl, float dg)
        {
            ChiTietPhieuNhapHang ct = new ChiTietPhieuNhapHang();
            ct.maPN = ma;
            ct.maMH = mahh;
            ct.SoLuong = sl;
            ct.DonGia = dg;
            da.ChiTietPhieuNhapHangs.InsertOnSubmit(ct);
            da.SubmitChanges();
        }


        //Xóa bộ nhơ tạm



        //kiểm tra sản phẩm có trong phieu do chưa
        public bool KiemTraMaMH(string mahd, string mamh)
        {
            int ct = da.ChiTietPhieuNhapHangs.Where(t => t.maPN == mahd && t.maMH == mamh).ToList().Count;
            if (ct > 0)
                return false;
            return true;
        }
        // lay ma phiếu nhập cuoi cung
        public string getMAPNLast()
        {
            List<PhieuNhapHang> a = da.PhieuNhapHangs.ToList();
            if (a.Count == 0)// neu chua co hoa don nao
            { return ""; }
            //da co ma hoa don
            PhieuNhapHang b = da.PhieuNhapHangs.ToList().OrderByDescending(t => t.maPN).First();// lay hoa don dau tien giam dan theo ma
            return b.maPN;
        }
        //huy don hang
        public void HuyPhieuNhap(string ma)
        {
            PhieuNhapHang hd = da.PhieuNhapHangs.Where(t => t.maPN == ma).SingleOrDefault();
            da.PhieuNhapHangs.DeleteOnSubmit(hd);
            da.SubmitChanges();
        }
        public List<PhieuNhapHang> TimKiemPN(string ngay)
        {
            var tk = da.PhieuNhapHangs.Where(t => t.NgayNhap == DateTime.Parse(ngay)).ToList();
            return tk;
        }

    }
}
