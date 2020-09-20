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
    public partial class FrmQLLoaiHH : Form
    {
        LOAIHH_BLL lhh_bll = new LOAIHH_BLL();
        public FrmQLLoaiHH()
        {
            InitializeComponent();
        }
        public void loadLoaiHangHoa()
        {
            dgvLoaiHH.DataSource = lhh_bll.getLoaiHH();

        }
        private void FrmQLLoaiHH_Load(object sender, EventArgs e)
        {
            ReadOnlyTrue();
            loadLoaiHangHoa();
            EnabledFalse();
        }
        public void ReadOnlyFalse()
        {
            txtTenLoai.ReadOnly = false;

            txtMaLoai.ReadOnly = false;
        }
        public void ReadOnlyTrue()
        {
            txtTenLoai.ReadOnly = true;

            txtMaLoai.ReadOnly = true;
        }
        public void EnabledFalse()
        {
            btnThemMoi.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
        }
        public void EnabledTrue()
        {
            btnThemMoi.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = true;

        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            txtMaLoai.Text = MaTuDong();
            txtTK.Enabled = false;
            rdMa.Enabled = false;
            rdTen.Enabled = false;
            txtMaLoai.Text = "";
            txtTenLoai.Text = "";
            ReadOnlyFalse();
            EnabledFalse();
            btnLuu.Enabled = true;
        }

        private void dgvLoaiHH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ReadOnlyTrue();
            EnabledTrue();
            txtTK.Enabled = true;
            rdMa.Enabled = true;
            rdTen.Enabled = true;
            btnLuu.Enabled = false;
            int rowIndex = e.RowIndex;
            try
            {
                DataGridViewRow row = dgvLoaiHH.Rows[rowIndex];
                txtMaLoai.Text = row.Cells[0].Value.ToString();
                txtTenLoai.Text = row.Cells[1].Value.ToString();

            }
            catch
            {
                return;
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rs = MessageBox.Show("Bạn có muốn xóa chứ ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (rs == DialogResult.Yes)
                {
                    lhh_bll.xoaLoaiHangHoa(txtMaLoai.Text);
                    MessageBox.Show("Xóa thành công");
                    loadLoaiHangHoa();
                }


            }
            catch
            {
                MessageBox.Show("Xóa  không thành công");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            EnabledFalse();
            btnLuu.Enabled = true;
            ReadOnlyFalse();
            txtMaLoai.ReadOnly = true;
        }
        public string MaTuDong()
        {
            string kq = "";
            if (lhh_bll.getMALOAILast() == "")
            {
                kq = "MH001";
            }
            else
            {
                int so = int.Parse(lhh_bll.getMALOAILast().Remove(0, 2));

                so = so + 1;
                if (so < 10)
                {
                    kq = "MH" + "00";
                }
                else if (so < 100)
                {
                    kq = "MH" + "0";
                }

                kq = kq + so.ToString();
            }
            return kq;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaLoai.ReadOnly == false)
                {
                    if (txtMaLoai.Text == "")
                    {
                        MessageBox.Show("Mã loại hàng hóa không được để trống!!");
                        txtMaLoai.Focus();
                        return;
                    }
                    if (txtTenLoai.Text == "")
                    {
                        MessageBox.Show("Tên loại hàng hóa không được để trống!!");
                        txtTenLoai.Focus();
                        return;
                    }

                    if (lhh_bll.KTraLoaiHHTonTai(txtMaLoai.Text) == true)
                    {
                        lhh_bll.themLoaiHH(txtMaLoai.Text, txtTenLoai.Text);
                        MessageBox.Show("Thêm " + txtTenLoai.Text + " thành công");
                        loadLoaiHangHoa();
                        txtMaLoai.Text = "";
                        txtTenLoai.Text = "";

                        txtTK.Enabled = true;
                        rdMa.Enabled = true;
                        rdTen.Enabled = true;

                        ReadOnlyTrue();
                        btnLuu.Enabled = false;

                    }
                    else
                    {
                        MessageBox.Show("Mã loại " + txtMaLoai.Text + " " + "đã tồn tại rồi!!");
                        return;
                    }
                }
                else
                {
                    lhh_bll.suaLoaiHanHoa(txtMaLoai.Text, txtTenLoai.Text);
                    dgvLoaiHH.DataSource = lhh_bll.getLoaiHH();

                    MessageBox.Show("Sửa thành công ");
                    txtTK.Enabled = true;
                    rdMa.Enabled = true;
                    rdTen.Enabled = true;

                    ReadOnlyTrue();
                    btnLuu.Enabled = false;
                }
            }
            catch
            {
                MessageBox.Show("Lỗi!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtTK_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTK.Text.Trim() == "")
                {
                    dgvLoaiHH.DataSource = lhh_bll.getLoaiHH();
                }
                else
                {
                    if (rdTen.Checked)
                    {
                        dgvLoaiHH.DataSource = lhh_bll.TimKiemTheoTen(txtTK.Text);
                    }
                    else
                    {
                        dgvLoaiHH.DataSource = lhh_bll.TimKiemTheoMa(txtTK.Text);
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTK.Text.Trim() == "")
                {
                    dgvLoaiHH.DataSource = lhh_bll.getLoaiHH();
                }
                else
                {
                    if (rdTen.Checked)
                    {
                        dgvLoaiHH.DataSource = lhh_bll.TimKiemTheoTen(txtTK.Text);
                    }
                    else
                    {
                        dgvLoaiHH.DataSource = lhh_bll.TimKiemTheoMa(txtTK.Text);
                    }
                }
            }
            catch
            {
                return;
            }
        }
    }
}
