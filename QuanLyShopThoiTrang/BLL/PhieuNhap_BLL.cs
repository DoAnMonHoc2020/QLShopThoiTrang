using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class PhieuNhap_BLL
    {
        PhieuNhap_DAL pn_dal = new PhieuNhap_DAL();
        public PhieuNhap_BLL() { }
        public IQueryable GetCTPN(string ma)
        {
            return pn_dal.GetCTPN(ma);
        }
        public bool KTraTonTai(string ma)
        {
            return pn_dal.KTraTonTai(ma);
        }
        //them phieu nhap
        public void ThemPhieuNhap(string ma, string ngaylap, string manv)
        {
            pn_dal.ThemPhieuNhap(ma, ngaylap, manv);
        }

        //them hàng hóa vào phieu nhap vào
        public void ThemHHVaoPhieuNhap(string ma, string mahh, int sl, float dg)
        {
            pn_dal.ThemHHVaoPhieuNhap(ma, mahh, sl, dg);
        }

        //kiểm tra sản phẩm có trong phieu do chưa
        public bool KiemTraMaMH(string mahd, string mamh)
        {
            return pn_dal.KiemTraMaMH(mahd, mamh);
        }
        // lay ma phiếu nhập cuoi cung
        public string getMAPNLast()
        {
            return pn_dal.getMAPNLast();
        }
        //huy don hang
        public void HuyPhieuNhap(string ma)
        {
            pn_dal.HuyPhieuNhap(ma);
        }
        public List<PhieuNhapHang> TimKiemPN(string ngay)
        {
            return pn_dal.TimKiemPN(ngay);
        }
    }
}
