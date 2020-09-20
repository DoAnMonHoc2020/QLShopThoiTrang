using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HoaDon_DAL
    {
        QLShopThoiTrangDataContext da = new QLShopThoiTrangDataContext();
        public HoaDon_DAL() { }
        //lay danh sach hoa don
        public IQueryable getCTHoaDon(string ma)
        {
            var ct = from t in da.ChiTietHoaDons join h in da.HangHoas on t.maMH equals h.maMH where t.maHD == ma select new { t.maMH,h.tenMH, t.SoLuong, t.DonGia, t.ThanhTien };
            return ct;
        }
        //Kiem tra hoa don co ton tai chua
        public bool KTraTonTai(string ma)
        {
            int hd = da.HoaDons.Where(t => t.maHD == ma).ToList().Count;
            if (hd > 0)
                return false;
            return true;
        }
        //them hoa don
        public void ThemHoaDon(string mahd, string ngaylap, string manv, string mathe)
        {
            HoaDon hd = new HoaDon();
            hd.maHD = mahd;
            hd.NgayLapHD = DateTime.Parse(ngaylap);
            hd.maNV = manv;
            hd.maThe = mathe;
            hd.TongTien = 0;

            da.HoaDons.InsertOnSubmit(hd);
            da.SubmitChanges();
        }
        //cập nhật tổng tiền
        public void CapNhatHD(string ma,float tongtien)
        {
            HoaDon hd = da.HoaDons.Where(t => t.maHD == ma).SingleOrDefault();
            hd.TongTien = tongtien;
            da.SubmitChanges();
        }
        //them hàng hóa vào đơn vào
        public void ThemHHVaoHoaDon(string mahd, string mahh, int sl, float dg)
        {
            ChiTietHoaDon ct = new ChiTietHoaDon();
            ct.maHD = mahd;
            ct.maMH = mahh;
            ct.SoLuong = sl;
            ct.DonGia = dg;
            ct.ThanhTien = sl * dg;

            da.ChiTietHoaDons.InsertOnSubmit(ct);
            da.SubmitChanges();
        }
        //Xoa mặt hàng ra khỏi hóa đơn
        public void XoaHH(string mahd, string mamh)
        {
            ChiTietHoaDon ct = da.ChiTietHoaDons.Where(t => t.maHD == mahd && t.maMH == mamh).SingleOrDefault();
            da.ChiTietHoaDons.DeleteOnSubmit(ct);
            da.SubmitChanges();
            da.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, ct);

            //ClearCache(da);
        }

        //Xóa bộ nhơ tạm

        //cập nhật chi tiết hóa đơn của 1 hóa đơn
        public void CapNhatSoLuong(string mahd, string mahh, int sl,float dg)
        {
            ChiTietHoaDon ct = da.ChiTietHoaDons.Where(t => t.maHD == mahd & t.maMH == mahh).SingleOrDefault();
            ct.SoLuong = sl;
            ct.DonGia = dg;
            ct.ThanhTien = sl * dg;

            da.SubmitChanges();
        }
        //Lây số lượng hàng hóa cũ
        public int GetSoLuongCu(string mahd, string mamh)
        {
            ChiTietHoaDon ct = da.ChiTietHoaDons.Where(t => t.maHD == mahd && t.maMH == mamh).SingleOrDefault();
            return (int)ct.SoLuong;
        }
        //kiểm tra hóa đơn đó có sản phẩm đó chưa
        public bool KiemTraMaMH(string mahd, string mamh)
        {
            int ct = da.ChiTietHoaDons.Where(t => t.maHD == mahd && t.maMH == mamh).ToList().Count;
            if (ct > 0)
                return false;
            return true;
        }
        // lay ma hoa don cuoi cung
        public string getMAHDLast()
        {
            List<HoaDon> a = da.HoaDons.ToList();
            if (a.Count == 0)// neu chua co hoa don nao
            { return ""; }
            //da co ma hoa don
            HoaDon b = da.HoaDons.ToList().OrderByDescending(t => t.maHD).First();// lay hoa don dau tien giam dan theo ma
            return b.maHD;
        }
        //huy don hang
        public void HuyHoaDon(string ma)
        {
            HoaDon hd = da.HoaDons.Where(t => t.maHD == ma).SingleOrDefault();
            da.HoaDons.DeleteOnSubmit(hd);
            da.SubmitChanges();
        }
        //Tính tổng tiền của 1 hóa đơn
        public float TinhTongTien(string mahd)
        {
            List<ChiTietHoaDon> ct = da.ChiTietHoaDons.Where(t => t.maHD == mahd).ToList();
            float tongtien=0;
            foreach (var item in ct)
            {
                tongtien += (float)item.ThanhTien;
            }
            return tongtien;
        }
        //Tìm kiếm hóa đơn
        public List<HoaDon> TimKiemHD(string ngay)
        {
            var tk = da.HoaDons.Where(t => t.NgayLapHD == DateTime.Parse(ngay)).ToList();
            return tk;
        }
    }
}
