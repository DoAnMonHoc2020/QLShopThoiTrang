using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class HangHoa_BLL
    {
        HangHoa_DAL hh_dal = new HangHoa_DAL();
        public HangHoa_BLL(){}
        public List<LoaiHangHoa> getLoaiHangHoa()
        {
            return hh_dal.getLoaiHang();
        }
        //cap nhat so luong ton cua hang hoa do
        public void CapNhatSoLuongTonHH(string mahh, int soluong)
        {
            hh_dal.CapNhatSoLuongTonHH(mahh, soluong);
        }
        //cap nhat so luong ton cua hang hoa khi nhap hang
        public void CapNhatSoLuongTonHHNhap(string mahh, int soluong)
        {
            hh_dal.CapNhatSoLuongTonHHNhap(mahh, soluong);
        }
        public IQueryable getNCC()
        {
            return hh_dal.getNCC();
        }
        public HangHoa getCTHH(string ma)
        {
            return hh_dal.getCTHH(ma);
        }
        public IQueryable getHangHoa()
        {
            return hh_dal.getHangHoa();
        }
        public IQueryable getDSHangHoa()
        {
            return hh_dal.getDSHangHoa();
        }
        public bool KTraHangHoaTonTai(string ma)
        {
            return hh_dal.KTraHangHoaTonTai(ma);
        }
        public void ThemHangHoa(string ma, string ten, float dongia, string maloai, string mancc)
        {
            hh_dal.ThemHangHoa(ma, ten, dongia, maloai, mancc);
        }
        public void XoaHangHoa(string ma)
        {
            hh_dal.XoaHangHoa(ma);
        }
        public void SuaHangHoa(string ma, string ten, float dongia, string maloai, string mancc)
        {
            hh_dal.SuaHangHoa(ma, ten, dongia, maloai, mancc);
        }
        public string getMAMHLast()
        {
            return hh_dal.getMAMHLast();
        }
        public bool KTraKhoaNgoai(string ma)
        {
            return hh_dal.KTraKhoaNgoai(ma);
        }
        public IQueryable TimKiemTheoTen(string ten)
        {
            return hh_dal.TimKiemTheoTen(ten);
        }
        public IQueryable TimKiemTheoMa(string ma)
        {
            return hh_dal.TimKiemTheoMa(ma);
        }
       
    }
}
