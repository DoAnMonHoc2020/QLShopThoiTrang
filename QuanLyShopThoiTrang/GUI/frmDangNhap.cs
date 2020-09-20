using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;

namespace GUI
{
    public partial class frmDangNhap : Form
    {
        DangNhap_BLL dn = new DangNhap_BLL();
        public frmDangNhap()
        {
            InitializeComponent();
        }
        public class LuuThongTin
        {
            public static string MANV = "";
            static public string tendn;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }
        public void ProcessConfig()
        {
            try
            {
                frmKetNoi frm = new frmKetNoi();
                frm.ShowDialog();
            }
            catch
            {


            }
        }
        public void ProcessLogin()
        {
            int result;
            result = dn.KiemTraDangNhap(txtUser.Text, txtPass.Text);
            if (result == 1000)
            {
                MessageBox.Show("Sai " + lblUsername.Text + " or " + lblPass.Text);
                return;
            }
            else if (result == 2000)
            {
                MessageBox.Show("Tai khoan bi khoa !!");
                return;
            }
            else
            {
                LuuThongTin.tendn = txtUser.Text.Trim();
                LuuThongTin.MANV = dn.GetMANV(txtUser.Text, txtPass.Text);
                frmMainNV frm = new frmMainNV();
                frm.ShowDialog();
            }
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUser.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống" + lblUsername.Text.ToLower());
                this.txtUser.Focus(); return;
            }
            if (string.IsNullOrEmpty(this.txtPass.Text))
            {
                MessageBox.Show("Không được bỏ trống" + lblPass.Text.ToLower());
                this.txtPass.Focus();
                return;
            }
            int kq = dn.Check_Config(); //hàm Check_Config() thuộc Class QL_NguoiDung 
            if (kq == 0)
            {
                ProcessLogin();// Cấu hình phù hợp xử lý đăng nhập 
            }
            if (kq == 1)
            {
                MessageBox.Show("Chuỗi cấu hình không tồn tại");// Xử lý cấu hình 
                ProcessConfig();
                return;
            }
            if (kq == 2)
            {
                MessageBox.Show("Chuỗi cấu hình không phù hợp");// Xử lý cấu hình 
                ProcessConfig();
                return;
            }
        }
    }
}
