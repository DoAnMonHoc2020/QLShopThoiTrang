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
    public partial class frmCTPN : Form
    {
        PhieuNhap_BLL hd = new PhieuNhap_BLL();
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
        public frmCTPN()
        {
            InitializeComponent();
        }

        private void frmCTPN_Load(object sender, EventArgs e)
        {
            cboNV.DataSource = nv.getDSNhanVien();
            cboNV.DisplayMember = "tenNV";
            cboNV.ValueMember = "maNV";
            txtMaPN.Text = Mahd;
            txtNgayHD.Text = Ngayhd;
            cboNV.SelectedValue = Nv;
            dgvCTPN.DataSource = hd.GetCTPN(Mahd);
        }

        private void btnIN_Click(object sender, EventArgs e)
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
                d.THANHTIEN = int.Parse(dgvCTPN.Rows[i].Cells[2].Value.ToString()) * float.Parse(dgvCTPN.Rows[i].Cells[3].Value.ToString());
                d.STT = Stt.ToString();
                Stt++;
                plistdiem.Add(d);

                path = string.Empty;
                ex.ExportPhieuNhap(plistdiem, ref path, false, txtMaPN.Text, txtNgayHD.Text, cboNV.Text);
            }
            ex.OpenFile(path);
        }
    }
}
