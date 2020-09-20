using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class HoaDon_BLL
    {
        HoaDon_DAL hd_dal = new HoaDon_DAL();
        public HoaDon_BLL() { }
        
        public IQueryable getCTHoaDon(string ma)
        {
            return hd_dal.getCTHoaDon(ma);
        }
        public void ThemHoaDon(string mahd, string ngaylap, string manv, string mathe)
        {
            hd_dal.ThemHoaDon(mahd, ngaylap, manv, mathe);
        }
        public void CapNhatHD(string ma, float tongtien)
        {
            hd_dal.CapNhatHD(ma, tongtien);
        }
        public void HuyHoaDon(string mahd)
        {
            hd_dal.HuyHoaDon(mahd);
        }
        public string getMAHDLast()
        {
            return hd_dal.getMAHDLast();
        }
        public bool KTraTonTai(string ma)
        {
            return hd_dal.KTraTonTai(ma);
        }
        public void ThemHHVaoHoaDon(string mahd, string mahh, int sl, float dg)
        {
            hd_dal.ThemHHVaoHoaDon(mahd, mahh, sl, dg);
        }
        public bool KiemTraMaMH(string mahd, string mamh)
        {
            return hd_dal.KiemTraMaMH(mahd, mamh);
        }
        public void CapNhatSoLuong(string mahd, string mahh, int sl,float dg)
        {
            hd_dal.CapNhatSoLuong(mahd, mahh, sl,dg);
        }
        public int GetSoLuongCu(string mahd, string mamh)
        {
            return hd_dal.GetSoLuongCu(mahd, mamh);
        }
        public void XoaHH(string mahd, string mamh)
        {
            hd_dal.XoaHH(mahd, mamh);
        }
        public float TinhTongTien(string mahd)
        {
            return hd_dal.TinhTongTien(mahd);
        }
        public List<HoaDon> TimKiemHD(string ngay)
        {
            return hd_dal.TimKiemHD(ngay);
        }
        //Cập nhật tổng tiền trong hóa đơn
        
        //huy hoa don
      
        ////lay danh sach nhan vien
        //public IQueryable getNhanVien()
        //{
        //    return getNhanVien();
        //}
    }
}
