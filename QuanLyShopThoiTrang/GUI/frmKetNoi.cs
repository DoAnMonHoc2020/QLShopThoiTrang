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

namespace GUI
{
    public partial class frmKetNoi : Form
    {
        KietNoi_BLL kn = new KietNoi_BLL();
        public frmKetNoi()
        {
            InitializeComponent();
        }

        private void frmKetNoi_Load(object sender, EventArgs e)
        {
            try
            {
                string[] s = { @"\SQLEXPRESS", @"\SQL2012", "" };
                foreach (var i in s)
                {
                    cboTenMay.Items.Add(SystemInformation.UserDomainName.ToString() + i);
                }

                cboTenMay.Text = "";
            }
            catch
            {
                MessageBox.Show("Lỗi");
                return;
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)// nếu nhấp nút enter sẽ gọi lại click Kết nối
            {

                btnKetNoi_Click(sender, e);// gọi lại click Kết nối
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void btnKetNoi_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboTenMay.Text == "")
                {
                    MessageBox.Show("Hãy chọn Tên máy!", "Chú ý!");
                    return;
                }
                if (txtUser.Text == "")
                {
                    MessageBox.Show("Hãy nhập User!", "Chú ý!");
                    return;
                }
                if (txtPass.Text == "")
                {
                    MessageBox.Show("Hãy nhập mật khẩu!", "Chú ý!");
                    return;
                }
                kn.KetNoiLaiDL(cboTenMay.Text.Trim(), txtUser.Text.Trim(), txtPass.Text.Trim());
                this.Close();
            }
            catch
            {
                MessageBox.Show("Kết nối thất bại");
                return;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
