using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NCC_DAL
    {
        QLShopThoiTrangDataContext da = new QLShopThoiTrangDataContext();
        public NCC_DAL() { }
        public IQueryable getDSNCC()
        {
            var nv = from n in da.NhaCungCaps select new { n.maNCC, n.tenNCC, n.DiaChi, n.DienThoai };
            return nv;
        }
        public bool KTraNCCTonTai(string ma)
        {
            int nv = da.NhaCungCaps.Where(t => t.maNCC == ma).ToList().Count;
            if (nv > 0)
                return false;// đã tồn tại
            return true;//chưa tồn tại
        }
        public void ThemNCC(string ma, string ten, string diachi, string dienthoai)
        {
            NhaCungCap nv = new NhaCungCap();
            nv.maNCC = ma;
            nv.tenNCC = ten;
            nv.DiaChi = diachi;
            nv.DienThoai = dienthoai;

            da.NhaCungCaps.InsertOnSubmit(nv);
            da.SubmitChanges();
        }
        public void XoaNCC(string ma)
        {
            NhaCungCap nv = da.NhaCungCaps.Where(t => t.maNCC == ma).SingleOrDefault();
            da.NhaCungCaps.DeleteOnSubmit(nv);
            da.SubmitChanges();
        }
        public void SuaNCC(string ma, string ten, string diachi, string dienthoai)
        {
            NhaCungCap nv = da.NhaCungCaps.Where(t => t.maNCC == ma).SingleOrDefault();
            nv.tenNCC = ten;
            nv.DiaChi = diachi;
            nv.DienThoai = dienthoai;

            da.SubmitChanges();
        }
        public string getMANCCLast()
        {
            List<NhaCungCap> a = da.NhaCungCaps.ToList();
            if (a.Count == 0)// neu chua co NCC nao
            { return ""; }
            //da co ma ncc
            NhaCungCap b = da.NhaCungCaps.ToList().OrderByDescending(t => t.maNCC).First();
            return b.maNCC;
        }
        public bool KTraKhoaNgoai(string ma)
        {
            int hanghoa = da.HangHoas.Where(t => t.maNCC == ma).ToList().Count;
            
            if (hanghoa > 0 )
                return true;
            return false;
        }
        public IQueryable TimKiemTheoTen(string ten)
        {
            var tk = from t in da.NhaCungCaps where t.tenNCC.Contains(ten) == true select new { t.maNCC, t.tenNCC, t.DienThoai, t.DiaChi };
            return tk;
        }
        public IQueryable TimKiemTheoSDT(string sdt)
        {
            var tk = from t in da.NhaCungCaps where t.DienThoai.Contains(sdt) == true select new { t.maNCC, t.tenNCC, t.DienThoai, t.DiaChi };
            return tk;
        }
    }
}
