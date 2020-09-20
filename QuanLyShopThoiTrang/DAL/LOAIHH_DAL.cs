using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LOAIHH_DAL
    {
        QLShopThoiTrangDataContext lhh = new QLShopThoiTrangDataContext();
        public LOAIHH_DAL() 
        {}
        public IQueryable getDSLoaiHH()
        {
            var ds = from hh in lhh.LoaiHangHoas select hh;
            return ds;
        }
        public bool KTraLoaiHangHoaTonTai(string ma)
        {
            int dshh = lhh.LoaiHangHoas.Where(t => t.maLoaiHH == ma).ToList().Count;
            if (dshh > 0)
                return false;//loại hàng hóa này đã tồn tại
            return true;//loại hàng hóa chưa tồn tại
        }
        public void SuaLoaiHangHoa(string ma, string ten)
        {
            LoaiHangHoa hh = lhh.LoaiHangHoas.Where(t => t.maLoaiHH == ma).FirstOrDefault();
            hh.maLoaiHH = ma;
            hh.tenLoaiHH = ten;
            lhh.SubmitChanges();
        }
        public void insert_LoaiHangHoa(string makh, string tekh)
        {
            LoaiHangHoa hh = new LoaiHangHoa();
            hh.maLoaiHH = makh;
            hh.tenLoaiHH = tekh;
        
            lhh.LoaiHangHoas.InsertOnSubmit(hh);
            lhh.SubmitChanges();
        }
        public void delete_LoaiHangHoa(string ma)
        {
            LoaiHangHoa hh = lhh.LoaiHangHoas.Where(t => t.maLoaiHH == ma).FirstOrDefault();
            lhh.LoaiHangHoas.DeleteOnSubmit(hh);
            lhh.SubmitChanges();
        }
        public IQueryable TimKiemTheoTen(string ten)
        {
            var tk = from t in lhh.LoaiHangHoas where t.tenLoaiHH.Contains(ten) == true select t;
            return tk;
        }
        public IQueryable TimKiemTheoMa(string ma)
        {
            var tk = from t in lhh.LoaiHangHoas where t.maLoaiHH.Contains(ma) == true select t;
            return tk;
        }
        public string getMALOAILast()
        {
            List<LoaiHangHoa> a = lhh.LoaiHangHoas.ToList();
            if (a.Count == 0)// neu chua co nhan vien nao
            { return ""; }
            //da co ma nhan vien
            LoaiHangHoa b = lhh.LoaiHangHoas.ToList().OrderByDescending(t => t.maLoaiHH).First();
            return b.maLoaiHH;
        }
    }
}
