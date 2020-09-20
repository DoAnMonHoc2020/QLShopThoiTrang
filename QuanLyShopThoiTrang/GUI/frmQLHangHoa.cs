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
    public partial class frmQLHangHoa : Form
    {
        HangHoa_BLL hh = new HangHoa_BLL();
        public frmQLHangHoa()
        {
            InitializeComponent();
        }

        private void frmQLHangHoa_Load(object sender, EventArgs e)
        {
            cboMaLoai.DataSource = hh.getLoaiHangHoa();
            cboMaLoai.DisplayMember = "tenLoaiHH";
            cboMaLoai.ValueMember = "maLoaiHH";
            cboNCC.DataSource = hh.getNCC();
            cboNCC.DisplayMember = "tenNCC";
            cboNCC.ValueMember = "maNCC";
            blockButtonTextbox();
            dgvHangHoa.DataSource = hh.getDSHangHoa();
        }
        public void blockButtonTextbox()
        {
            btnThemMoi.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;

            txtMa.Enabled = false;
            txtTen.Enabled = false;
            cboMaLoai.Enabled = false;
            cboNCC.Enabled = false;
            txtDonGia.Enabled = false;
        }
        public void unblockButtonTextbox()
        {
            btnThemMoi.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;

            txtMa.Enabled = true;
            txtTen.Enabled = true;
            cboMaLoai.Enabled = true;
            cboNCC.Enabled = true;
            txtDonGia.Enabled = true;
        }
        public string MaTuDong()
        {
            string kq = "";
            if (hh.getMAMHLast() == "")
            {
                kq = "MHH001";
            }
            else
            {
                int so = int.Parse(hh.getMAMHLast().Remove(0, 3));

                so = so + 1;
                if (so < 10)
                {
                    kq = "MMH" + "00";
                }
                else if (so < 100)
                {
                    kq = "MMH" + "0";
                }
                
                kq = kq + so.ToString();
            }
            return kq;
        }
        public void ClearDL()
        {
            txtMa.Text = "";
            txtTen.Text = "";
            cboMaLoai.Text = "";
            cboNCC.Text = "";
            txtDonGia.Text = "";
        }

        private void cboMaLoai_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            ClearDL();
            unblockButtonTextbox();
            txtMa.Text = MaTuDong();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMa.Enabled == true)
                {
                    if (txtMa.Text == "")
                    {
                        MessageBox.Show("Mã Mặt hàng không được để trống!!");
                        txtMa.Focus();
                        return;
                    }
                    if (txtTen.Text == "")
                    {
                        MessageBox.Show("Tên Mặt hàng không được để trống!!");
                        txtTen.Focus();
                        return;
                    }
                    if (cboMaLoai.Text == "")
                    {
                        MessageBox.Show("Loại không được để trống!!");
                        cboMaLoai.Focus();
                        return;
                    }
                    if (cboNCC.Text == "")
                    {
                        MessageBox.Show("Nhà cung cấp không được để trống!!");
                        cboNCC.Focus();
                        return;
                    }
                    if (txtDonGia.Text == "")
                    {
                        MessageBox.Show("Đơn giá không được để trống!!");
                        txtDonGia.Focus();
                        return;
                    }
                    if (hh.KTraHangHoaTonTai(txtMa.Text) == true)
                    {
                        hh.ThemHangHoa(txtMa.Text, txtTen.Text,float.Parse(txtDonGia.Text),cboMaLoai.SelectedValue.ToString(), cboNCC.SelectedValue.ToString());
                        dgvHangHoa.DataSource = hh.getDSHangHoa();
                        blockButtonTextbox();
                    }
                    else
                    {
                        MessageBox.Show("Mặt hàng " + txtTen.Text + "đã tồn tại rồi!!");
                        return;
                    }
                }
                else
                {
                    hh.SuaHangHoa(txtMa.Text, txtTen.Text,float.Parse(txtDonGia.Text),cboMaLoai.SelectedValue.ToString(), cboNCC.SelectedValue.ToString());
                    dgvHangHoa.DataSource = hh.getDSHangHoa();
                    blockButtonTextbox();
                    MessageBox.Show("Sửa thành công ");
                }
            }
            catch
            {
                MessageBox.Show("Lỗi!! ","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                blockButtonTextbox();
                int index = e.RowIndex;
                txtMa.Text = dgvHangHoa.Rows[index].Cells[0].Value.ToString();
                txtTen.Text = dgvHangHoa.Rows[index].Cells[1].Value.ToString();
                cboMaLoai.SelectedValue = dgvHangHoa.Rows[index].Cells[4].Value.ToString();
                cboNCC.SelectedValue = dgvHangHoa.Rows[index].Cells[6].Value.ToString();
                txtDonGia.Text = dgvHangHoa.Rows[index].Cells[2].Value.ToString();
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
                        MessageBox.Show("Mã mặt hàng không được để trống!!");
                        txtMa.Focus();
                        return;
                    }
                    if (hh.KTraKhoaNgoai(txtMa.Text) == false)
                    {
                        hh.XoaHangHoa(txtMa.Text);
                        MessageBox.Show("Xóa thành công");
                        dgvHangHoa.DataSource = hh.getDSHangHoa();
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
                    dgvHangHoa.DataSource = hh.getDSHangHoa();
                }
                else
                {
                    if (rdTen.Checked)
                    {
                        dgvHangHoa.DataSource = hh.TimKiemTheoTen(txtTimKiem.Text);
                    }
                    else
                    {
                        dgvHangHoa.DataSource = hh.TimKiemTheoMa(txtTimKiem.Text);
                    }
                }
            }
            catch
            {
                return;
            }
        }
        public void InDS()
        {
            ExcelExport ex = new ExcelExport();
            if (dgvHangHoa.Rows.Count == 0)
            {
                MessageBox.Show("Khong co du lieu de Xuat");
                return;
            }
            List<INDSHANG> plistdiem = new List<INDSHANG>();
            int Stt = 1;
            string path = "";
            foreach (DataGridViewRow item in dgvHangHoa.Rows)
            {
                INDSHANG d = new INDSHANG();
                d.MaHH = item.Cells[0].Value.ToString();
                d.TenHH = item.Cells[1].Value.ToString();
                d.DonGia = float.Parse(item.Cells[2].Value.ToString());
                d.SoLuongTon = int.Parse(item.Cells[3].Value.ToString());
                d.Loai = item.Cells[5].Value.ToString();
                d.NCC = item.Cells[7].Value.ToString();
                d.STT = Stt.ToString();
                Stt++;
                plistdiem.Add(d);

                path = string.Empty;
                ex.ExportDSHang(plistdiem, ref path, false);
            }
            ex.OpenFile(path);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            InDS();
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
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
