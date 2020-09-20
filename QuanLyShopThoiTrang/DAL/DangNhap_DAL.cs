using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DangNhap_DAL
    {
        QLShopThoiTrangDataContext da = new QLShopThoiTrangDataContext();
        public DangNhap_DAL() { }
        //public int Check_Config()
        //{
        //    if (Properties.Settings.Default.QL_ShopQuanAoConnectionString == string.Empty)
        //        return 1;// Chuỗi cấu hình không tồn tại 
        //    SqlConnection _Sqlconn = new SqlConnection(Properties.Settings.Default.QL_ShopQuanAoConnectionString);
        //    try
        //    {
        //        if (_Sqlconn.State == System.Data.ConnectionState.Closed)
        //            _Sqlconn.Open();
        //        return 0;
        //        // Kết nối thành công chuỗi cấu hình hợp lệ 
        //    }
        //    catch
        //    {
        //        return 2;// Chuỗi cấu hình không phù hợp. 
        //    }
        //}

        public int Check_Config()
        {
            return da.DatabaseExists() ? 0 : 2;

        }

        public int KiemTraDangNhap(string pUser, string pPass)
        {
            int dn = da.TaiKhoans.Where(t => t.TenTK == pUser && t.MatKhau == pPass).ToList().Count;
            var dt = da.TaiKhoans.Where(t => t.TenTK == pUser && t.MatKhau == pPass).FirstOrDefault();
            
            if (dn == 0)
                return 1000;
            else if (dt.HoatDong == null||dt.HoatDong.ToString()=="False")
                return 2000;
            return 3000;
        }
        public string GetMANV(string pUser, string pPass)
        {
            var dn = da.TaiKhoans.Where(t => t.TenTK == pUser && t.MatKhau == pPass).SingleOrDefault().maNV.ToString();
            return dn;
        }
        public bool GetQuyenNV(string manv)
        {
            int q = da.TaiKhoans.Where(t => t.maNV == manv & t.Quyen == "Admin").ToList().Count;
            if (q > 0)
                return true;
            return false;
        }
        public void KetNoi(string tenmay,string user,string pass)
        {
            SqlConnectionStringBuilder connStringBuilder;
            connStringBuilder = new SqlConnectionStringBuilder();
            connStringBuilder.DataSource = tenmay;
            connStringBuilder.InitialCatalog = "QL_ShopQuanAo";
            connStringBuilder.IntegratedSecurity = true;
            connStringBuilder.UserID = user;
            connStringBuilder.Password = pass;
            //string kn;
            //string a = connStringBuilder.ToString();
            da = new QLShopThoiTrangDataContext(connStringBuilder.ConnectionString);
        }
 
    }
}
