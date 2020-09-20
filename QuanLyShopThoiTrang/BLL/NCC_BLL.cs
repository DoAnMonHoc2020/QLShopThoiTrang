using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class NCC_BLL
    {
        NCC_DAL ncc_dal = new NCC_DAL();
        public NCC_BLL() { }
        public IQueryable getDSNCC()
        {
            return ncc_dal.getDSNCC();
        }
        public bool KTraNCCTonTai(string ma)
        {
            return ncc_dal.KTraNCCTonTai(ma);
        }
        public void ThemNCC(string ma, string ten, string diachi, string dienthoai)
        {
            ncc_dal.ThemNCC(ma, ten, diachi, dienthoai);
        }
        public void XoaNCC(string ma)
        {
            ncc_dal.XoaNCC(ma);
        }
        public void SuaNCC(string ma, string ten, string diachi, string dienthoai)
        {
            ncc_dal.SuaNCC(ma, ten, diachi, dienthoai);
        }
        public string getMANCCLast()
        {
            return ncc_dal.getMANCCLast();
        }
        public bool KTraKhoaNgoai(string ma)
        {
            return ncc_dal.KTraKhoaNgoai(ma);
        }
        public IQueryable TimKiemTheoTen(string ten)
        {
            return ncc_dal.TimKiemTheoTen(ten);
        }
        public IQueryable TimKiemTheoSDT(string sdt)
        {
            return ncc_dal.TimKiemTheoSDT(sdt);
        }
    }
}
