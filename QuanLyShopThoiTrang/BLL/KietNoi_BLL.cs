using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class KietNoi_BLL
    {
        KetNoi kn = new KetNoi();
        public KietNoi_BLL() { }
        public void KetNoiLaiDL(string servername, string user, string pass)
        {
            kn.KetNoiLaiDL(servername, user, pass);
        }
    }
}
