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
    public partial class frmBanHang : Form
    {
        System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
        HoaDon_BLL hd = new HoaDon_BLL();
        NhanVien_BLL nv = new NhanVien_BLL();
        KhachHang_BLL kh = new KhachHang_BLL();
        HangHoa_BLL hh = new HangHoa_BLL();
        int dong = 0;
        public frmBanHang()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public void block()
        {
            btnTaoHD.Enabled = true;
            btnLuu.Enabled = false;
            dgvMH.Enabled = false;
            dgvCTHD.Enabled = false;
            btnThanhToan.Enabled = false;
            //btnThem.Enabled = false;
            btnHuy.Enabled = false;

            txtMaHD.Enabled = false;
            txtNgayHD.Enabled = false;
            cboNV.Enabled = false;
            cboKH.Enabled = false;
        }
        public void unblock()
        {
            btnTaoHD.Enabled = false;
            btnLuu.Enabled = true;
            dgvCTHD.Enabled = false;
            //btnThem.Enabled = false;
            dgvMH.Enabled = false;
            btnHuy.Enabled = false;

            txtMaHD.Enabled = false;
            txtNgayHD.Enabled = true;
            cboNV.Enabled = false;
            cboKH.Enabled = true;

        }
        public void ClearDL()
        {
            txtMaHD.Text = "";
            cboKH.Text = "";
            txtSoLuong.Text = "";
            txtDonGia.Text = "";
            cboMH.SelectedIndex = -1;
            txtTongTien.Text = "0";
        }
        private void frmBanHang1_Load(object sender, EventArgs e)
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
            cboKH.DataSource = kh.getKhachHang();
            cboKH.DisplayMember = "tenKH";
            cboKH.ValueMember = "mathe";
            cboKH.Text = "";
            dgvMH.DataSource = hh.getDSHangHoa();

            dgvCTHD.MouseClick += new MouseEventHandler(dgvCTHD_MouseClick);
        }
        int nuttam;
        private void dgvCTHD_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

            }
            else
            {
                ContextMenuStrip menu = new System.Windows.Forms.ContextMenuStrip();
                int position_xy_mouse_row = dgvCTHD.HitTest(e.X, e.Y).RowIndex;
                nuttam = position_xy_mouse_row;
                if (position_xy_mouse_row >= 0)
                {
                    menu.Items.Add("Xóa").Name = "Xoa";
                }
                menu.Show(dgvCTHD, new Point(e.X, e.Y));
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
                        dgvCTHD.Rows.RemoveAt(nuttam);
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
            if (hd.getMAHDLast() == "")
            {
                kq = "HD00001";
            }
            else
            {
                int so = int.Parse(hd.getMAHDLast().Remove(0, 2));

                int k = so + 1;
                if (k < 10)
                {
                    kq = "HD" + "0000";
                }
                else if (k < 100)
                {
                    kq = "HD" + "000";
                }
                else if (k < 1000000)
                {
                    kq = "HD" + "00";
                }
                else if (k < 1000000000)
                {
                    kq = "HD" + "0";
                }
                kq = kq + k.ToString();
            }
            return kq;
        }

        private void btnTaoHD_Click(object sender, EventArgs e)
        {
            unblock();
            txtMaHD.Text = MaTuDong();
        }
        //public void loadCTHD()
        //{
        //    dgvCTHD.DataSource = hd.getCTHoaDon(txtMaHD.Text);
        //}
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaHD.Text == "")
                {
                    MessageBox.Show("Mã hóa đơn không được để trống!!");
                    txtMaHD.Focus();
                    return;
                }
                if (cboNV.Text == "")
                {
                    MessageBox.Show("Hãy chọn nhân viên!!");
                    cboNV.Focus();
                    return;
                }
                if (hd.KTraTonTai(txtMaHD.Text) == true)
                {
                    if (cboKH.Text == "")
                    {
                        hd.ThemHoaDon(txtMaHD.Text, txtNgayHD.Text, cboNV.SelectedValue.ToString(), null);
                        MessageBox.Show("Thành công");
                        txtTongTien.Text = hd.TinhTongTien(txtMaHD.Text).ToString();
                        block();
                        btnHuy.Enabled = true;
                        btnThanhToan.Enabled = true;
                        dgvCTHD.Enabled = true;
                        dgvMH.Enabled = true;
                        btnLuu.Enabled = false;
                        btnThanhToan.Enabled = true;
                        btnTaoHD.Enabled = false;
                    }
                    else
                    {
                        hd.ThemHoaDon(txtMaHD.Text, txtNgayHD.Text, cboNV.SelectedValue.ToString(), cboKH.SelectedValue.ToString());
                        MessageBox.Show("Thành công");
                        txtTongTien.Text = hd.TinhTongTien(txtMaHD.Text).ToString();
                        block();
                        btnHuy.Enabled = true;
                        btnTaoHD.Enabled = false;
                        btnThanhToan.Enabled = true;
                        dgvCTHD.Enabled = true;
                        dgvMH.Enabled = true;
                        btnLuu.Enabled = false;
                        btnThanhToan.Enabled = true;
                    }
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
                //btnThem.Enabled = true;
                txtSoLuong.Focus();
            }
            catch
            {
                return;
            }
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
                    if (int.Parse(txtSoLuong.Text) > hh.getCTHH(cboMH.SelectedValue.ToString()).SoLuongTon)
                    {
                        MessageBox.Show("Số lượng hàng không đủ cho bạn!!");
                        cboMH.SelectedIndex = -1;
                        txtDonGia.Text = "";
                        txtSoLuong.Text = "";
                        //btnThem.Enabled = false;
                    }
                    else
                    {
                        DataGridViewRow row = (DataGridViewRow)dgvCTHD.Rows[0].Clone();
                        row.Cells[0].Value = cboMH.SelectedValue.ToString();
                        row.Cells[1].Value = cboMH.Text;
                        row.Cells[2].Value = txtSoLuong.Text;
                        row.Cells[3].Value = txtDonGia.Text;
                        row.Cells[4].Value = (int.Parse(txtSoLuong.Text) * float.Parse(txtDonGia.Text)).ToString();
                        dgvCTHD.Rows.Add(row);
                        tinhTongTien();
                        cboMH.SelectedIndex = -1;
                        txtDonGia.Text = "";
                        txtSoLuong.Text = "";
                        //btnThem.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Sản phẩm này đã có trong hóa đơn");
                }


            }
            catch
            {
                MessageBox.Show("Lỗi!!");
            }
        }
        public bool KiemTraTonTaiHang(string ma)
        {
            for (int i = 0; i < dgvCTHD.Rows.Count - 1; i++)
            {
                string mamh = dgvCTHD.Rows[i].Cells[0].Value.ToString();
                if (ma == mamh)
                    return true;
            }
            return false;
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            try
            {
                if (hd.KTraTonTai(txtMaHD.Text) == false)
                {
                    for (int i = 0; i < dgvCTHD.Rows.Count - 1; i = 0)
                    {
                        dgvCTHD.Rows.RemoveAt(i);
                    }
                    hd.HuyHoaDon(txtMaHD.Text);
                    MessageBox.Show("Hủy thành công");
                    block();
                    ClearDL();
                }
                else
                {
                    MessageBox.Show("Hóa đơn này không tồn tại");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Lỗi!!");
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgvCTHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
        }
        public void tinhTongTien()
        {
            float tongtien = 0;
            for (int i = 0; i < dgvCTHD.Rows.Count - 1; i++)
            {
                tongtien += float.Parse(dgvCTHD.Rows[i].Cells[3].Value.ToString());
            }
            txtTongTien.Text = tongtien.ToString();
            decimal value = decimal.Parse(txtTongTien.Text, System.Globalization.NumberStyles.AllowThousands);
            txtTongTien.Text = String.Format(culture, "{0:N0}", value);
            txtTongTien.Select(txtTongTien.Text.Length, 0);
        }
        private void dgvCTHD_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                float tt = int.Parse(dgvCTHD.Rows[dong].Cells[2].Value.ToString()) * float.Parse(dgvCTHD.Rows[dong].Cells[3].Value.ToString());
                dgvCTHD.Rows[dong].Cells[4].Value = tt;
                tinhTongTien();
            }
            catch
            {
                return;
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                if (hd.KTraTonTai(txtMaHD.Text) == false)
                {
                    for (int i = 0; i < dgvCTHD.Rows.Count - 1; i++)
                    {
                        string mahh = dgvCTHD.Rows[i].Cells[0].Value.ToString();
                        string soluong = dgvCTHD.Rows[i].Cells[2].Value.ToString();
                        string dongia = dgvCTHD.Rows[i].Cells[3].Value.ToString();

                        hd.ThemHHVaoHoaDon(txtMaHD.Text, mahh, int.Parse(soluong), float.Parse(dongia));
                        hh.CapNhatSoLuongTonHH(mahh, int.Parse(soluong));

                    }
                    float tongtien = 0;
                    for (int i = 0; i < dgvCTHD.Rows.Count - 1; i++)
                    {
                        tongtien += float.Parse(dgvCTHD.Rows[i].Cells[3].Value.ToString());
                    }
                    hd.CapNhatHD(txtMaHD.Text, tongtien);
                    MessageBox.Show("Thanh toán thành công");
                    InHD();
                    for (int i = 0; i < dgvCTHD.Rows.Count - 1; i = 0)
                    {
                        dgvCTHD.Rows.RemoveAt(i);
                    }
                    btnThanhToan.Enabled = false;
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
            if (dgvCTHD.Rows.Count == 0)
            {
                MessageBox.Show("Khong co du lieu de Xuat");
                return;
            }
            List<INHOADON> plistdiem = new List<INHOADON>();
            int Stt = 1;
            string path = "";
            for (int i = 0; i < dgvCTHD.Rows.Count - 1; i++)
            {
                INHOADON d = new INHOADON();
                d.TENHANG = dgvCTHD.Rows[i].Cells[1].Value.ToString();
                d.SOLUONG = int.Parse(dgvCTHD.Rows[i].Cells[2].Value.ToString());
                d.DONGIA = float.Parse(dgvCTHD.Rows[i].Cells[3].Value.ToString());
                d.THANHTIEN = float.Parse(dgvCTHD.Rows[i].Cells[4].Value.ToString());
                d.STT = Stt.ToString();
                Stt++;
                plistdiem.Add(d);

                path = string.Empty;
                ex.ExportHOADON(plistdiem, ref path, false, txtMaHD.Text, txtNgayHD.Text, cboNV.Text, cboKH.Text);
            }
            ex.OpenFile(path);
        }

        private void dgvCTHD_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnSoLuong_KeyPress);
            if (dgvCTHD.CurrentCell.ColumnIndex == 1) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(ColumnSoLuong_KeyPress);
                }
            }
        }

        private void ColumnSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
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

        private void frmBanHang1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnThanhToan.Enabled == false)
            {
                e.Cancel = false;
            }
            else
            {
                MessageBox.Show("Hóa đơn này chưa thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            frmQLKhachHang frm = new frmQLKhachHang();
            frm.ShowDialog();
            cboKH.DataSource = kh.getKhachHang();
            cboKH.DisplayMember = "tenKH";
            cboKH.ValueMember = "mathe";
            cboKH.Text = "";
        }

        private void txtSoLuong_KeyPress_1(object sender, KeyPressEventArgs e)
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
