using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using BLL;

namespace GUI
{
    public partial class frmMainNV : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DangNhap_BLL dn = new DangNhap_BLL();
        NhanVien_BLL nv = new NhanVien_BLL();
        public frmMainNV()
        {
            InitializeComponent();
        }
        private Form KiemTraTonTai(Type ptype)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == ptype)
                {
                    return f;
                }
            }
            return null;
        }
        private void frmMain1_Load(object sender, EventArgs e)
        {
            if (dn.GetQuyenNV(frmDangNhap.LuuThongTin.MANV) == false)
            {
                rbQLTK.Visible = false;
                rbQLHang.Visible = false;
                rbQLNCC.Visible = false;
                rbQLNV.Visible = false;
                rbNhapHang.Visible = false;
                itemNhapHang.Visible = false;
                itemLSNhap.Visible = false;
            }
            lblTenNV.Caption = "Xin chào " + nv.GetTenNV(frmDangNhap.LuuThongTin.MANV);
        }



        private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(frmQLKhachHang));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmQLKhachHang f = new frmQLKhachHang();
                f.MdiParent = this;
                f.Show();
            }
        }



        private void btnBanHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(frmBanHang));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmBanHang f = new frmBanHang();
                f.MdiParent = this;
                f.Show();
            }
        }


        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn đăng xuất tài khoản hay không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
            if (rs == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
                return;
            }
        }

        private void btnQLTaiKhoan_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(frmQLTaiKhoan));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmQLTaiKhoan f = new frmQLTaiKhoan();
                f.MdiParent = this;
                f.Show();
            }
        }


        private void btnNhapHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(frmNhapHang));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmNhapHang f = new frmNhapHang();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnQLLoaiHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(FrmQLLoaiHH));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                FrmQLLoaiHH f = new FrmQLLoaiHH();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnQLHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(frmQLHangHoa));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmQLHangHoa f = new frmQLHangHoa();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnQLNCC_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(frmQLNCC));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmQLNCC f = new frmQLNCC();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnQLKhachHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(frmQLKhachHang));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmQLKhachHang f = new frmQLKhachHang();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnQLNhanVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(frmQLNhanVien));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmQLNhanVien f = new frmQLNhanVien();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnDangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void itemBanHang_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(frmBanHang));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmBanHang f = new frmBanHang();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void itemNhapHang_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(frmNhapHang));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmNhapHang f = new frmNhapHang();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void itemLSBan_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(frmLichSuHoaDon));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmLichSuHoaDon f = new frmLichSuHoaDon();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void itemLSNhap_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(frmLichSuNhapHang));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmLichSuNhapHang f = new frmLichSuNhapHang();
                f.MdiParent = this;
                f.Show();
            }
        }

    }
}