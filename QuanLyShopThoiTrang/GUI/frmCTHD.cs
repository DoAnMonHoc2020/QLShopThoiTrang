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
    public partial class frmCTHD : Form
    {
        HoaDon_BLL hd = new HoaDon_BLL();
        NhanVien_BLL nv = new NhanVien_BLL();
        KhachHang_BLL kh = new KhachHang_BLL();
        string _mahd;

        public string Mahd
        {
            get { return _mahd; }
            set { _mahd = value; }
        }
        string _ngayhd;

        public string Ngayhd
        {
            get { return _ngayhd; }
            set { _ngayhd = value; }
        }
        string _nv;

        public string Nv
        {
            get { return _nv; }
            set { _nv = value; }
        }
        string _kh;

        public string Kh
        {
            get { return _kh; }
            set { _kh = value; }
        }
        string _tongtien;

        public string Tongtien
        {
            get { return _tongtien; }
            set { _tongtien = value; }
        }
        public frmCTHD()
        {
            InitializeComponent();
        }

        private void frmCTHD_Load(object sender, EventArgs e)
        {
            cboNV.DataSource = nv.getDSNhanVien();
            cboNV.DisplayMember = "tenNV";
            cboNV.ValueMember = "maNV";
            cboKH.DataSource = kh.getDSKhachHang();
            cboKH.DisplayMember = "tenKH";
            cboKH.ValueMember = "maThe";
            txtMaHD.Text = Mahd;
            txtNgayHD.Text = Ngayhd;
            cboNV.SelectedValue = Nv;
            cboKH.SelectedValue = Kh;
            txtTongTien.Text = Tongtien;
            dgvCTHD.DataSource = hd.getCTHoaDon(Mahd);
        }

        private void btnIN_Click(object sender, EventArgs e)
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
    }
}
