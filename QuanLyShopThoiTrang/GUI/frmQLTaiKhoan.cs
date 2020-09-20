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
    public partial class frmQLTaiKhoan : Form
    {
        string[] quyen = new string[] { "", "Admin", "User" };
        string[] hd = new string[] { "True", "False" };
        TaiKhoan_BLL tk = new TaiKhoan_BLL();
        public frmQLTaiKhoan()
        {
            InitializeComponent();
        }

        private void frmQLTaiKhoan_Load(object sender, EventArgs e)
        {
            cboQuyen.DataSource = quyen;
            cboHoatDong.DataSource = hd;
            dgvTaiKhoan.DataSource = tk.getDSTaiKhoan();
            cboMaNV.DataSource = tk.getNV();
            cboMaNV.DisplayMember = "tenNV";
            cboMaNV.ValueMember = "maNV";
            cboMaNV.Text = "";
            blockButtonTextbox();

        }
        public void ClearDL()
        {
            txtTenTK.Text = "";
            txtMK.Text = "";
            cboQuyen.Text = "";
            cboHoatDong.Text = "";
            cboMaNV.Text = "";
        }
        public void blockButtonTextbox()
        {
            btnThemMoi.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;

            txtTenTK.Enabled = false;
            txtMK.Enabled = false;
            cboQuyen.Enabled = false;
            cboHoatDong.Enabled = false;
            cboMaNV.Enabled = false;
        }
        public void unblockButtonTextbox()
        {
            btnThemMoi.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;

            txtTenTK.Enabled = true;
            txtMK.Enabled = true;
            cboQuyen.Enabled = true;
            cboHoatDong.Enabled = true;
            cboMaNV.Enabled = true;
        }
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            unblockButtonTextbox();
            ClearDL();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTenTK.Enabled == true)
                {
                    if (txtMK.Text == "")
                    {
                        MessageBox.Show("Tên tài khoản không được để trống!!");
                        txtMK.Focus();
                        return;
                    }
                    if (cboQuyen.Text == "")
                    {
                        MessageBox.Show("Hãy chọn quyền!!");
                        cboQuyen.Focus();
                        return;
                    }
                    if (cboHoatDong.Text == "")
                    {
                        MessageBox.Show("Hãy chọn hoạt động!!");
                        cboHoatDong.Focus();
                        return;
                    }
                    if (cboMaNV.Text == "")
                    {
                        MessageBox.Show("Hãy chọn nhân viên!!");
                        cboMaNV.Focus();
                        return;
                    }

                    if (tk.KTraTonTai(txtTenTK.Text) == true)
                    {
                        tk.Them(txtTenTK.Text, txtMK.Text, cboQuyen.Text, cboHoatDong.Text, cboMaNV.SelectedValue.ToString());
                        dgvTaiKhoan.DataSource = tk.getDSTaiKhoan();
                        blockButtonTextbox();
                    }
                    else
                    {
                        MessageBox.Show("Nhân viên " + cboMaNV.Text + "đã có tài khoản!!");
                        return;
                    }
                }
                else
                {
                    tk.Sua(txtTenTK.Text, txtMK.Text, cboQuyen.Text, cboHoatDong.Text, cboMaNV.SelectedValue.ToString());
                    dgvTaiKhoan.DataSource = tk.getDSTaiKhoan();
                    blockButtonTextbox();
                    MessageBox.Show("Sửa thành công ");
                }
            }
            catch
            {
                MessageBox.Show("Lỗi!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            unblockButtonTextbox();
            txtTenTK.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rs = MessageBox.Show("Bạn có muốn xóa chứ ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (rs == DialogResult.Yes)
                {
                    if (tk.KTraKhoaNgoai(cboMaNV.SelectedValue.ToString()) == false)
                    {
                        tk.Xoa(txtTenTK.Text);
                        MessageBox.Show("Xóa thành công");
                        dgvTaiKhoan.DataSource = tk.getDSTaiKhoan();
                        blockButtonTextbox();
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu này đang được sử dụng không thể xóa!!");
                        blockButtonTextbox();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Lỗi!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                blockButtonTextbox();
                int index = e.RowIndex;
                txtTenTK.Text = dgvTaiKhoan.Rows[index].Cells[0].Value.ToString();
                txtMK.Text = dgvTaiKhoan.Rows[index].Cells[1].Value.ToString();
                cboQuyen.Text = dgvTaiKhoan.Rows[index].Cells[2].Value.ToString();
                cboHoatDong.Text = dgvTaiKhoan.Rows[index].Cells[3].Value.ToString();
                cboMaNV.SelectedValue = dgvTaiKhoan.Rows[index].Cells[4].Value.ToString();
                btnLuu.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
            catch
            {
                return;
            }
        }

        private void txtTimKiem_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTimKiem.Text.Trim() == "")
                {
                    dgvTaiKhoan.DataSource = tk.getDSTaiKhoan();
                }
                else
                {
                    if (rdTenTK.Checked)
                    {
                        dgvTaiKhoan.DataSource = tk.TimKiemTheoTenTK(txtTimKiem.Text);
                    }
                    else
                    {
                        dgvTaiKhoan.DataSource = tk.TimKiemTheoMaNV(txtTimKiem.Text);
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {

            ExcelExport ex = new ExcelExport();
            if (dgvTaiKhoan.Rows.Count == 0)
            {
                MessageBox.Show("Khong co du lieu de Xuat");
                return;
            }
            List<INDSTAIKHOAN> plistdiem = new List<INDSTAIKHOAN>();
            int Stt = 1;
            string path = "";
            foreach (DataGridViewRow item in dgvTaiKhoan.Rows)
            {
                INDSTAIKHOAN d = new INDSTAIKHOAN();
                d.TenTK = item.Cells[0].Value.ToString();
                d.MatKhau = item.Cells[1].Value.ToString();
                d.Quyen = item.Cells[2].Value.ToString();
                d.HoatDong = item.Cells[3].Value.ToString();
                d.NhanVien = item.Cells[4].Value.ToString();
                d.STT = Stt.ToString();
                Stt++;
                plistdiem.Add(d);

                path = string.Empty;
                ex.ExportDSTaiKhoan(plistdiem, ref path, false);
            }
            ex.OpenFile(path);
        }

    }
}
