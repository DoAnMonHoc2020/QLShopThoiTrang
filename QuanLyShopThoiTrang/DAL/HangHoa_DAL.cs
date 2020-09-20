using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HangHoa_DAL
    {
        QLShopThoiTrangDataContext da = new QLShopThoiTrangDataContext();
        public HangHoa_DAL() { }
        public List<LoaiHangHoa> getLoaiHang()
        {
            List<LoaiHangHoa> l = da.LoaiHangHoas.ToList();
            return l;
        }
        //cap nhat so luong ton cua hang hoa khi ban hang
        public void CapNhatSoLuongTonHH(string mahh, int soluong)
        {
            HangHoa hh = da.HangHoas.Where(t => t.maMH == mahh).SingleOrDefault();
            hh.SoLuongTon = hh.SoLuongTon - soluong;
            da.SubmitChanges();
        }
        //cap nhat so luong ton cua hang hoa khi nhap hang
        public void CapNhatSoLuongTonHHNhap(string mahh, int soluong)
        {
            HangHoa hh = da.HangHoas.Where(t => t.maMH == mahh).SingleOrDefault();
            hh.SoLuongTon = hh.SoLuongTon + soluong;
            da.SubmitChanges();
        }
        //lay thong tin chi tiet cua mot mat hang
        public HangHoa getCTHH(string ma)
        {
            var hh = da.HangHoas.Where(t => t.maMH == ma).SingleOrDefault();
            return hh;
        }
        //lay danh sach hang hoa
        public IQueryable getHangHoa()
        {
            var hh = from h in da.HangHoas select h;
            return hh;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        public IQueryable getNCC()
        {
            var hh = from h in da.NhaCungCaps select h;
            return hh;
        }
        public IQueryable getDSHangHoa()
        {
            var nv = from n in da.HangHoas join l in da.LoaiHangHoas on n.maLoaiHH equals l.maLoaiHH  join ncc in da.NhaCungCaps on n.maNCC equals ncc.maNCC select new { n.maMH, n.tenMH, n.DonGia, n.SoLuongTon,n.maLoaiHH, l.tenLoaiHH,n.maNCC,ncc.tenNCC };
            return nv;
        }
        public bool KTraHangHoaTonTai(string ma)
        {
            int nv = da.HangHoas.Where(t => t.maMH == ma).ToList().Count;
            if (nv > 0)
                return false;//HangHoas này đã tồn tại
            return true;//chưa tồn tại
        }
        public void ThemHangHoa(string ma, string ten, float dongia, string maloai,string mancc)
        {
            HangHoa nv = new HangHoa();
            nv.maMH = ma;
            nv.tenMH = ten;
            nv.DonGia = dongia;
            nv.maLoaiHH = maloai;
            nv.SoLuongTon = 0;
            nv.maNCC = mancc;

            da.HangHoas.InsertOnSubmit(nv);
            da.SubmitChanges();
        }
        public void XoaHangHoa(string ma)
        {
            HangHoa nv = da.HangHoas.Where(t => t.maMH == ma).SingleOrDefault();
            da.HangHoas.DeleteOnSubmit(nv);
            da.SubmitChanges();
        }
        public void SuaHangHoa(string ma, string ten, float dongia, string  maloai,string mancc)
        {
            HangHoa nv = da.HangHoas.Where(t => t.maMH == ma).SingleOrDefault();
            nv.tenMH = ten;
            nv.DonGia = dongia;
            nv.maLoaiHH = maloai;
            nv.maNCC = mancc;

            da.SubmitChanges();
        }
        public string getMAMHLast()
        {
            List<HangHoa> a = da.HangHoas.ToList();
            if (a.Count == 0)// neu chua co nhan vien nao
            { return ""; }
            //da co ma nhan vien
            HangHoa b = da.HangHoas.ToList().OrderByDescending(t => t.maMH).First();
            return b.maMH;
        }
        public bool KTraKhoaNgoai(string ma)
        {
            int hoadon = da.ChiTietHoaDons.Where(t => t.maMH == ma).ToList().Count;
            int phieunhap = da.ChiTietPhieuNhapHangs.Where(t => t.maMH == ma).ToList().Count;
            if (hoadon > 0 || phieunhap > 0)
                return true;
            return false;
        }
        public IQueryable TimKiemTheoTen(string ten)
        {
            var tk = from t in da.HangHoas where t.tenMH.Contains(ten) == true select new { t.maMH, t.tenMH, t.DonGia, t.SoLuongTon, t.maLoaiHH,t.maNCC };
            return tk;
        }
        public IQueryable TimKiemTheoMa(string ma)
        {
            var tk = from t in da.HangHoas where t.maMH.Contains(ma) == true select new { t.maMH, t.tenMH, t.DonGia, t.SoLuongTon, t.maLoaiHH,t.maNCC };
            return tk;
        }
       
    }
}
