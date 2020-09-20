using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class LOAIHH_BLL
    {
        LOAIHH_DAL lhh_dal = new LOAIHH_DAL();
        public LOAIHH_BLL() { }
        public IQueryable getLoaiHH()
        {
            return lhh_dal.getDSLoaiHH();

        }
        public bool KTraLoaiHHTonTai(string maloai)
        {
            return lhh_dal.KTraLoaiHangHoaTonTai(maloai);
        }

        public void themLoaiHH(string malhh, string tenlhh)
        {
            lhh_dal.insert_LoaiHangHoa(malhh, tenlhh);
        }
        public void suaLoaiHanHoa(string malhh, string tenlhh)
        {
            lhh_dal.SuaLoaiHangHoa(malhh, tenlhh);
        }
        public void xoaLoaiHangHoa(string malhh)
        {
            lhh_dal.delete_LoaiHangHoa(malhh);
        }
        public IQueryable TimKiemTheoTen(string ten)
        {
            return lhh_dal.TimKiemTheoTen(ten);
        }
        public IQueryable TimKiemTheoMa(string ma)
        {
            return lhh_dal.TimKiemTheoMa(ma);
        }
        public string getMALOAILast()
        {
            return lhh_dal.getMALOAILast();
        }
    }
}
