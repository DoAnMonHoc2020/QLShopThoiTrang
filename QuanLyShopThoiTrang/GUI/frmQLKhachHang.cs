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
    public partial class frmQLKhachHang : Form
    {
        KhachHang_BLL kh = new KhachHang_BLL();
        public frmQLKhachHang()
        {
            InitializeComponent();
        }
        
        
        private void frmQLKhachHang_Load(object sender, EventArgs e)
        {
            dgvKhachHang.DataSource = kh.getDSKhachHang();
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
            txtDiaChi.Enabled = false;
            txtDT.Enabled = false;
            txtDiem.Enabled = false;
        }
        public void unblockButtonTextbox()
        {
            btnThemMoi.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;

            txtMa.Enabled = true;
            txtTen.Enabled = true;
            txtDiaChi.Enabled = true;
            txtDT.Enabled = true;
            txtDiem.Enabled = true;
        }
        public string MaTuDong()
        {
            string kq = "";
            if (kh.getMAKHLast() == "")
            {
                kq = "KH0001";
            }
            else
            {
                int so = int.Parse(kh.getMAKHLast().Remove(0, 2));

                so = so + 1;
                if (so < 10)
                {
                    kq = "KH" + "000";
                }
                else if (so < 100)
                {
                    kq = "KH" + "00";
                }
                else if (so < 1000)
                {
                    kq = "KH" + "0";
                }

                kq = kq + so.ToString();
            }
            return kq;
        }
        public void ClearDL()
        {
            txtMa.Text = "";
            txtTen.Text = "";
            txtDiaChi.Text = "";
            txtDT.Text = "";
            txtDiem.Text = "";
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
                        MessageBox.Show("Mã khách hàng không được để trống!!");
                        txtMa.Focus();
                        return;
                    }
                    if (txtTen.Text == "")
                    {
                        MessageBox.Show("Tên khách hàng không được để trống!!");
                        txtTen.Focus();
                        return;
                    }
                    if (txtDiaChi.Text == "")
                    {
                        MessageBox.Show("Địa chỉ không được để trống!!");
                        txtDiaChi.Focus();
                        return;
                    }
                    if (txtDT.Text == "")
                    {
                        MessageBox.Show("Số ĐT không được để trống!!");
                        txtDT.Focus();
                        return;
                    }
                    if (IsValidPhone(txtDT.Text) == false)
                    {
                        MessageBox.Show("Số ĐT không hợp lệ!!");
                        txtDT.Focus();
                        return;
                    }
                    if (txtDiem.Text == "")
                    {
                        MessageBox.Show("Điểm không được để trống!!");
                        txtDiem.Focus();
                        return;
                    }
                    if (kh.KTraKhachHangTonTai(txtMa.Text) == true)
                    {
                        kh.ThemKhachHang(txtMa.Text, txtTen.Text, txtDiaChi.Text, txtDT.Text, int.Parse(txtDiem.Text));
                        dgvKhachHang.DataSource = kh.getDSKhachHang();
                        blockButtonTextbox();
                    }
                    else
                    {
                        MessageBox.Show("Khách hàng " + txtTen.Text + "đã tồn tại rồi!!");
                        return;
                    }
                }
                else
                {
                    kh.SuaKhachHang(txtMa.Text, txtTen.Text, txtDiaChi.Text, txtDT.Text, int.Parse(txtDiem.Text));
                    dgvKhachHang.DataSource = kh.getDSKhachHang();
                    blockButtonTextbox();
                    MessageBox.Show("Sửa thành công ");
                }
            }
            catch
            {
                MessageBox.Show("Lỗi!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                blockButtonTextbox();
                int index = e.RowIndex;
                txtMa.Text = dgvKhachHang.Rows[index].Cells[0].Value.ToString();
                txtTen.Text = dgvKhachHang.Rows[index].Cells[1].Value.ToString();
                txtDiaChi.Text = dgvKhachHang.Rows[index].Cells[2].Value.ToString();
                txtDT.Text = dgvKhachHang.Rows[index].Cells[3].Value.ToString();
                txtDiem.Text = dgvKhachHang.Rows[index].Cells[4].Value.ToString();
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
                        MessageBox.Show("Mã Khách hàng không được để trống!!");
                        txtMa.Focus();
                        return;
                    }
                    if (kh.KTraKhoaNgoai(txtMa.Text) == false)
                    {
                        kh.XoaKhachHang(txtMa.Text);
                        MessageBox.Show("Xóa thành công");
                        dgvKhachHang.DataSource = kh.getDSKhachHang();
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
                    dgvKhachHang.DataSource = kh.getDSKhachHang();
                }
                else
                {
                    if (rdTen.Checked)
                    {
                        dgvKhachHang.DataSource = kh.TimKiemTheoTen(txtTimKiem.Text);
                    }
                    else
                    {
                        dgvKhachHang.DataSource = kh.TimKiemTheoSDT(txtTimKiem.Text);
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
            if (dgvKhachHang.Rows.Count == 0)
            {
                MessageBox.Show("Khong co du lieu de Xuat");
                return;
            }
            List<INDSKHACHHANG> plistdiem = new List<INDSKHACHHANG>();
            int Stt = 1;
            string path = "";
            foreach (DataGridViewRow item in dgvKhachHang.Rows)
            {
                INDSKHACHHANG d = new INDSKHACHHANG();
                d.MaKH = item.Cells[0].Value.ToString();
                d.TenKH = item.Cells[1].Value.ToString();
                d.DiaChi = item.Cells[2].Value.ToString();
                d.DienThoai = item.Cells[3].Value.ToString();
                d.DiemTL = int.Parse(item.Cells[4].Value.ToString());
                d.STT = Stt.ToString();
                Stt++;
                plistdiem.Add(d);

                path = string.Empty;
                ex.ExportDSKH(plistdiem, ref path, false);
            }
            ex.OpenFile(path);
        }

        private void btnThemMoi_Click_1(object sender, EventArgs e)
        {
            ClearDL();
            unblockButtonTextbox();
            txtMa.Text = MaTuDong();
        }

        private void txtDT_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDiem_KeyPress(object sender, KeyPressEventArgs e)
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
