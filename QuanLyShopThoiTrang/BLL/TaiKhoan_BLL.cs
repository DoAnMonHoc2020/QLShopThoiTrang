using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class TaiKhoan_BLL
    {
        TaiKhoan_DAL tk_dal = new TaiKhoan_DAL();
        public TaiKhoan_BLL() { }
        public IQueryable getDSTaiKhoan()
        {
            return tk_dal.getDSTaiKhoan();
        }
        public bool KTraTonTai(string tentk)
        {
            return tk_dal.KTraTonTai(tentk);
        }
        public void Them(string tentk, string mk, string quyen, string hd, string manv)
        {
            tk_dal.Them(tentk, mk, quyen, hd, manv);
        }
        public void Xoa(string tentk)
        {
            tk_dal.Xoa(tentk);
        }
        public void Sua(string tentk, string mk, string quyen, string hoatdong, string manv)
        {
            tk_dal.Sua(tentk, mk, quyen, hoatdong, manv);
        }
        public IQueryable getNV()
        {
            return tk_dal.getNV();
        }
        public bool KTraKhoaNgoai(string ma)
        {
            return tk_dal.KTraKhoaNgoai(ma);
        }
        public IQueryable TimKiemTheoTenTK(string tentk)
        {
            return tk_dal.TimKiemTheoTenTK(tentk);
        }
        public IQueryable TimKiemTheoMaNV(string manv)
        {
            return tk_dal.TimKiemTheoMaNV(manv);
        }
    }
}
