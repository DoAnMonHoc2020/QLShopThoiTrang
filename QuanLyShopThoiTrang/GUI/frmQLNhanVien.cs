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
using System.Text.RegularExpressions;

namespace GUI
{
    public partial class frmQLNhanVien : Form
    {
        NhanVien_BLL nv = new NhanVien_BLL();
        public frmQLNhanVien()
        {
            InitializeComponent();
        }

        private void frmQLNhanVien_Load(object sender, EventArgs e)
        {
            dgvNhanVien.DataSource = nv.getDSNhanVien();
            blockButtonTextbox();
        }
        public void blockButtonTextbox()
        {
            btnThemMoi.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;

            txtMa.Enabled = false;
            txtTen.Enabled = false;
            txtngaysinh.Enabled = false;
            txtSDT.Enabled = false;
            txtDiachi.Enabled = false;
        }
        public void unblockButtonTextbox()
        {
            btnThemMoi.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;

            txtMa.Enabled = true;
            txtTen.Enabled = true;
            txtngaysinh.Enabled = true;
            txtSDT.Enabled = true;
            txtDiachi.Enabled = true;
        }
        public string MaTuDong()
        {
            string kq = "";
            if (nv.getMANVLast() == "")
            {
                kq = "NV001";
            }
            else
            {
                int so = int.Parse(nv.getMANVLast().Remove(0, 2));

                so = so + 1;
                if (so < 10)
                {
                    kq = "NV" + "00";
                }
                else if (so < 100)
                {
                    kq = "NV" + "0";
                }
                
                kq = kq + so.ToString();
            }
            return kq;
        }
        public void ClearDL()
        {
            txtMa.Text = "";
            txtTen.Text = "";
            txtngaysinh.Text = "";
            txtDiachi.Text = "";
            txtSDT.Text = "";
        }
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            ClearDL();
            unblockButtonTextbox();
            txtMa.Text = MaTuDong();
        }
        public static bool IsValidPhone(string value)
        {
            value = value ?? string.Empty;
            string pattern = @"^-*[0-9,\.?\-?\(?\)?\ ]+$";
            Regex re = new Regex(pattern);
            if (re.IsMatch(value) && value.Length == 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMa.Enabled == true)
                {
                    if (txtMa.Text == "")
                    {
                        MessageBox.Show("Mã nhân viên không được để trống!!");
                        txtMa.Focus();
                        return;
                    }
                    if (txtTen.Text == "")
                    {
                        MessageBox.Show("Tên nhân viên không được để trống!!");
                        txtTen.Focus();
                        return;
                    }
                    if (txtngaysinh.Text == "")
                    {
                        MessageBox.Show("Ngày sinh không được để trống!!");
                        txtngaysinh.Focus();
                        return;
                    }
                    if (txtSDT.Text == "")
                    {
                        MessageBox.Show("Số ĐT không được để trống!!");
                        txtSDT.Focus();
                        return;
                    }
                    if (IsValidPhone(txtSDT.Text) == false)
                    {
                        MessageBox.Show("Số ĐT không hợp lệ!!");
                        txtSDT.Focus();
                        return;
                    }
                    if (txtDiachi.Text == "")
                    {
                        MessageBox.Show("Địa chỉ không được để trống!!");
                        txtDiachi.Focus();
                        return;
                    }
                    if (nv.KTraNhanVienTonTai(txtMa.Text) == true)
                    {
                        nv.ThemNhanVien(txtMa.Text, txtTen.Text, txtngaysinh.Text, txtSDT.Text, txtDiachi.Text);
                        dgvNhanVien.DataSource = nv.getDSNhanVien();
                        blockButtonTextbox();
                    }
                    else
                    {
                        MessageBox.Show("Nhân viên " + txtTen.Text + "đã tồn tại rồi!!");
                        return;
                    }
                }
                else
                {
                    nv.SuaNhanVien(txtMa.Text, txtTen.Text, txtngaysinh.Text, txtSDT.Text, txtDiachi.Text);
                    dgvNhanVien.DataSource = nv.getDSNhanVien();
                    blockButtonTextbox();
                    MessageBox.Show("Sửa thành công ");
                }
            }
            catch
            {
                MessageBox.Show("Lỗi!! ","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                blockButtonTextbox();
                int index = e.RowIndex;
                txtMa.Text = dgvNhanVien.Rows[index].Cells[0].Value.ToString();
                txtTen.Text = dgvNhanVien.Rows[index].Cells[1].Value.ToString();
                txtngaysinh.Text = dgvNhanVien.Rows[index].Cells[2].Value.ToString();
                txtSDT.Text = dgvNhanVien.Rows[index].Cells[3].Value.ToString();
                txtDiachi.Text = dgvNhanVien.Rows[index].Cells[4].Value.ToString();
                btnLuu.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
            catch
            {
                return;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            unblockButtonTextbox();
            txtMa.Enabled = false;
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rs = MessageBox.Show("Bạn có muốn xóa chứ ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (rs == DialogResult.Yes)
                {
                    if (txtMa.Text == "")
                    {
                        MessageBox.Show("Mã nhân viên không được để trống!!");
                        txtMa.Focus();
                        return;
                    }
                    if (nv.KTraKhoaNgoai(txtMa.Text) == false)
                    {
                        nv.XoaNhanVien(txtMa.Text);
                        MessageBox.Show("Xóa thành công");
                        dgvNhanVien.DataSource = nv.getDSNhanVien();
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

        private void txtTimKiem_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTimKiem.Text.Trim() == "")
                {
                    dgvNhanVien.DataSource = nv.getDSNhanVien();
                }
                else
                {
                    if (rdTen.Checked)
                    {
                        dgvNhanVien.DataSource = nv.TimKiemTheoTen(txtTimKiem.Text);
                    }
                    else
                    {
                        dgvNhanVien.DataSource = nv.TimKiemTheoSDT(txtTimKiem.Text);
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private void dgvNhanVien_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            InDS();
        }
        public void InDS()
        {
            ExcelExport ex = new ExcelExport();
            if (dgvNhanVien.Rows.Count == 0)
            {
                MessageBox.Show("Khong co du lieu de Xuat");
                return;
            }
            List<INDSNHANVIEN> plistdiem = new List<INDSNHANVIEN>();
            int Stt = 1;
            string path = "";
            foreach (DataGridViewRow item in dgvNhanVien.Rows)
            {
                INDSNHANVIEN d = new INDSNHANVIEN();
                d.MaNV = item.Cells[0].Value.ToString();
                d.TenNV = item.Cells[1].Value.ToString();
                d.NgaySinh = item.Cells[2].Value.ToString();
                d.DiaChi = item.Cells[3].Value.ToString();
                d.DienThoai = item.Cells[4].Value.ToString();
                d.STT = Stt.ToString();
                Stt++;
                plistdiem.Add(d);

                path = string.Empty;
                ex.ExportDSNhanVien(plistdiem, ref path, false);
            }
            ex.OpenFile(path);
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch
            {
            }
        }
    }
}
