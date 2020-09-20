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
    public partial class frmNhapHang : Form
    {
        System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
        PhieuNhap_BLL hd = new PhieuNhap_BLL();
        NhanVien_BLL nv = new NhanVien_BLL();
        HangHoa_BLL hh = new HangHoa_BLL();
        int dong = 0;
        public frmNhapHang()
        {
            InitializeComponent();
        }

        private void frmNhapHang_Load(object sender, EventArgs e)
        {
            block();
            cboMH.DataSource = hh.getHangHoa();
            cboMH.DisplayMember = "tenMH";
            cboMH.ValueMember = "maMH";
            cboMH.SelectedIndex = -1;
            txtNgayHD.Text = DateTime.Now.Date.ToString();
            cboNV.DataSource = nv.getDSNhanVien();
            cboNV.DisplayMember = "tenNV";
            cboNV.ValueMember = "maNV";
            cboNV.SelectedValue = frmDangNhap.LuuThongTin.MANV;
            dgvMH.DataSource = hh.getDSHangHoa();

            dgvCTPN.MouseClick += new MouseEventHandler(dgvCTPN_MouseClick);
        }
        int nuttam;
        private void dgvCTPN_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

            }
            else
            {
                ContextMenuStrip menu = new System.Windows.Forms.ContextMenuStrip();
                int position_xy_mouse_row = dgvCTPN.HitTest(e.X, e.Y).RowIndex;
                nuttam = position_xy_mouse_row;
                if (position_xy_mouse_row >= 0)
                {
                    menu.Items.Add("Xóa").Name = "Xoa";
                }
                menu.Show(dgvCTPN, new Point(e.X, e.Y));
                menu.ItemClicked += new ToolStripItemClickedEventHandler(menu_ItemClicked);
            }
        }

        private void menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name.ToString())
            {
                case "Xoa":
                    try
                    {
                        dgvCTPN.Rows.RemoveAt(nuttam);
                    }
                    catch
                    {
                        return;
                    }
                    break;
            }
        }
        public string MaTuDong()
        {
            string kq = "";
            if (hd.getMAPNLast() == "")
            {
                kq = "PN001";
            }
            else
            {
                int so = int.Parse(hd.getMAPNLast().Remove(0, 2));

                int k = so + 1;
                if (k < 10)
                {
                    kq = "PN" + "00";
                }
                else if (k < 100)
                {
                    kq = "PN" + "0";
                }

                kq = kq + k.ToString();
            }
            return kq;
        }
        public void block()
        {
            btnTaoPN.Enabled = true;
            btnLuu.Enabled = false;
            dgvMH.Enabled = false;
            dgvCTPN.Enabled = false;
            btnHoanTat.Enabled = false;
            btnThem.Enabled = false;
            btnHuy.Enabled = false;

            txtMaPN.Enabled = false;
            txtNgayHD.Enabled = false;
            cboNV.Enabled = false;
        }
        public void unblock()
        {
            btnTaoPN.Enabled = false;
            btnLuu.Enabled = true;
            dgvCTPN.Enabled = false;
            btnThem.Enabled = false;
            dgvMH.Enabled = false;
            btnHuy.Enabled = false;

            txtMaPN.Enabled = false;
            txtNgayHD.Enabled = true;
            cboNV.Enabled = false;

        }
        public void ClearDL()
        {
            txtMaPN.Text = "";
            txtSoLuong.Text = "";
            txtDonGia.Text = "";
            cboMH.SelectedIndex = -1;
            txtTongTien.Text = "0";
        }

        private void btnTaoPN_Click(object sender, EventArgs e)
        {
            unblock();
            txtMaPN.Text = MaTuDong();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaPN.Text == "")
                {
                    MessageBox.Show("Mã phiếu nhập không được để trống!!");
                    txtMaPN.Focus();
                    return;
                }
                if (cboNV.Text == "")
                {
                    MessageBox.Show("Hãy chọn nhân viên!!");
                    cboNV.Focus();
                    return;
                }
                if (hd.KTraTonTai(txtMaPN.Text) == true)
                {

                    hd.ThemPhieuNhap(txtMaPN.Text, txtNgayHD.Text, cboNV.SelectedValue.ToString());
                    MessageBox.Show("Thành công");
                    block();
                    btnHuy.Enabled = true;
                    btnTaoPN.Enabled = false;
                    btnHoanTat.Enabled = true;
                    dgvCTPN.Enabled = true;
                    dgvMH.Enabled = true;
                    btnLuu.Enabled = false;
                    btnHoanTat.Enabled = true;

                }
                else
                {
                    MessageBox.Show("Phiếu nhập này đang tồn tại !!");
                }

            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void dgvMH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                cboMH.SelectedValue = dgvMH.Rows[index].Cells[0].Value.ToString();
                txtDonGia.Text = dgvMH.Rows[index].Cells[2].Value.ToString();
                btnThem.Enabled = true;
                txtSoLuong.Focus();
            }
            catch
            {
                return;
            }
        }
        public bool KiemTraTonTaiHang(string ma)
        {
            for (int i = 0; i < dgvCTPN.Rows.Count - 1; i++)
            {
                string mamh = dgvCTPN.Rows[i].Cells[0].Value.ToString();
                if (ma == mamh)
                    return true;
            }
            return false;
        }
        public void tinhTongTien()
        {
            double tongtien = 0;
            for (int i = 0; i < dgvCTPN.Rows.Count - 1; i++)
            {
                tongtien += float.Parse(dgvCTPN.Rows[i].Cells[4].Value.ToString());
            }
            txtTongTien.Text = tongtien.ToString();
            decimal value = decimal.Parse(txtTongTien.Text, System.Globalization.NumberStyles.AllowThousands);
            txtTongTien.Text = String.Format(culture, "{0:N0}", value);
            txtTongTien.Select(txtTongTien.Text.Length, 0);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSoLuong.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập số lượng");
                    txtSoLuong.Focus();
                    return;
                }
                if (int.Parse(txtSoLuong.Text) < 0)
                {
                    MessageBox.Show("Số lượng nhập phải lớn hơn 0");
                    txtSoLuong.Text = "";
                    txtSoLuong.Focus();
                    return;
                }
                if (KiemTraTonTaiHang(cboMH.SelectedValue.ToString()) == false)
                {

                    DataGridViewRow row = (DataGridViewRow)dgvCTPN.Rows[0].Clone();
                    row.Cells[0].Value = cboMH.SelectedValue.ToString();
                    row.Cells[1].Value = cboMH.Text;
                    row.Cells[2].Value = txtSoLuong.Text;
                    row.Cells[3].Value = txtDonGia.Text;
                    row.Cells[4].Value = ((double)int.Parse(txtSoLuong.Text) * float.Parse(txtDonGia.Text)).ToString();
                    dgvCTPN.Rows.Add(row);
                    tinhTongTien();
                    cboMH.SelectedIndex = -1;
                    txtDonGia.Text = "";
                    txtSoLuong.Text = "";
                    btnThem.Enabled = false;

                }
                else
                {
                    MessageBox.Show("Sản phẩm này đã có trong phiếu nhập");
                    cboMH.SelectedIndex = -1;
                    txtDonGia.Text = "";
                    txtSoLuong.Text = "";
                    btnThem.Enabled = false;
                }


            }
            catch
            {
                MessageBox.Show("Lỗi!!");
            }
        }

        private void btnHoanTat_Click(object sender, EventArgs e)
        {
            try
            {
                if (hd.KTraTonTai(txtMaPN.Text) == false)
                {
                    for (int i = 0; i < dgvCTPN.Rows.Count - 1; i++)
                    {
                        string mahh = dgvCTPN.Rows[i].Cells[0].Value.ToString();
                        string soluong = dgvCTPN.Rows[i].Cells[2].Value.ToString();
                        string dongia = dgvCTPN.Rows[i].Cells[3].Value.ToString();

                        hd.ThemHHVaoPhieuNhap(txtMaPN.Text, mahh, int.Parse(soluong), float.Parse(dongia));
                        hh.CapNhatSoLuongTonHHNhap(mahh, int.Parse(soluong));

                    }
                    float tongtien = 0;
                    for (int i = 0; i < dgvCTPN.Rows.Count - 1; i++)
                    {
                        tongtien += float.Parse(dgvCTPN.Rows[i].Cells[3].Value.ToString());
                    }
                    MessageBox.Show("Thanh toán thành công");
                    InHD();
                    for (int i = 0; i < dgvCTPN.Rows.Count - 1; i = 0)
                    {
                        dgvCTPN.Rows.RemoveAt(i);
                    }
                    btnHoanTat.Enabled = false;
                    block();
                    ClearDL();
                    dgvMH.DataSource = hh.getDSHangHoa();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi!!");
            }
        }
        public void InHD()
        {
            ExcelExport ex = new ExcelExport();
            if (dgvCTPN.Rows.Count == 0)
            {
                MessageBox.Show("Khong co du lieu de Xuat");
                return;
            }
            List<INPHIEUNHAP> plistdiem = new List<INPHIEUNHAP>();
            int Stt = 1;
            string path = "";
            for (int i = 0; i < dgvCTPN.Rows.Count - 1; i++)
            {
                INPHIEUNHAP d = new INPHIEUNHAP();
                d.TENHANG = dgvCTPN.Rows[i].Cells[1].Value.ToString();
                d.SOLUONG = int.Parse(dgvCTPN.Rows[i].Cells[2].Value.ToString());
                d.DONGIA = float.Parse(dgvCTPN.Rows[i].Cells[3].Value.ToString());
                d.THANHTIEN = float.Parse(dgvCTPN.Rows[i].Cells[4].Value.ToString());
                d.STT = Stt.ToString();
                Stt++;
                plistdiem.Add(d);

                path = string.Empty;
                ex.ExportPhieuNhap(plistdiem, ref path, false, txtMaPN.Text, txtNgayHD.Text, cboNV.Text);
            }
            ex.OpenFile(path);
        }
        private void frmPhieuNhapHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnHoanTat.Enabled == false)
            {
                e.Cancel = false;
            }
            else
            {
                MessageBox.Show("Phiếu nhập này chưa hoàn thành", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            try
            {
                if (hd.KTraTonTai(txtMaPN.Text) == false)
                {
                    for (int i = 0; i < dgvCTPN.Rows.Count - 1; i = 0)
                    {
                        dgvCTPN.Rows.RemoveAt(i);
                    }
                    hd.HuyPhieuNhap(txtMaPN.Text);
                    MessageBox.Show("Hủy thành công");
                    block();
                    ClearDL();
                }
                else
                {
                    MessageBox.Show("Phiếu nhập này không tồn tại");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Lỗi!!");
            }
        }

        private void dgvCTPN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
        }

        private void dgvCTPN_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                float tt = int.Parse(dgvCTPN.Rows[dong].Cells[2].Value.ToString()) * float.Parse(dgvCTPN.Rows[dong].Cells[3].Value.ToString());
                dgvCTPN.Rows[dong].Cells[4].Value = tt;
                tinhTongTien();
            }
            catch
            {
                return;
            }
        }

        private void txtTK_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTK.Text.Trim() == "")
                {
                    dgvMH.DataSource = hh.getDSHangHoa();
                }
                else
                {
                    dgvMH.DataSource = hh.TimKiemTheoTen(txtTK.Text);
                }
            }
            catch
            {
                return;
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
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
