using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class DangNhap_BLL
    {
        DangNhap_DAL dn_dal = new DangNhap_DAL();
        public DangNhap_BLL() { }
        public int Check_Config()
        {
            return dn_dal.Check_Config();
        }
        public int KiemTraDangNhap(string pUser, string pPass)
        {
            return dn_dal.KiemTraDangNhap(pUser, pPass);
        }
        public string GetMANV(string pUser, string pPass)
        {
            return dn_dal.GetMANV(pUser, pPass);
        }
        public bool GetQuyenNV(string manv)
        {
            return dn_dal.GetQuyenNV(manv);
        }
        public void KetNoi(string tenmay, string user, string pass)
        {
            dn_dal.KetNoi(tenmay, user, pass);
        }
    }
}
