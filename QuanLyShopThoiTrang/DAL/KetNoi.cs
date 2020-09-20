using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DAL
{
    public class KetNoi
    {
        QLShopThoiTrangDataContext da;
        ConnectionStringSettings setting = ConfigurationManager.ConnectionStrings["QL_ShopQuanAoConnectionString"];
        SqlConnectionStringBuilder builder;
        public KetNoi() { }
        public void KetNoiLaiDL(string servername,string user,string pass)
        {
                string connection = setting.ConnectionString;
                builder = new SqlConnectionStringBuilder(connection);
                builder.DataSource = servername;
                builder.UserID = user;
                builder.Password = pass;
                builder.InitialCatalog = "QL_ShopQuanAo";
                da = new QLShopThoiTrangDataContext(builder.ConnectionString);
        }
    }
}
