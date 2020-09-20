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
    public partial class frmLichSuHoaDon : Form
    {
        HoaDon_BLL hd = new HoaDon_BLL();
        public frmLichSuHoaDon()
        {
            InitializeComponent();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtngay.Text == "")
                {
                    MessageBox.Show("Hãy chọn ngày cần tìm");
                    return;
                }
                dgvHD.DataSource = hd.TimKiemHD(txtngay.Text);
            }
            catch
            {
            }
        }

        private void dgvHD_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                frmCTHD fr = new frmCTHD();
                fr.Mahd = dgvHD.Rows[index].Cells[0].Value.ToString();
                fr.Ngayhd = dgvHD.Rows[index].Cells[1].Value.ToString();
                fr.Nv = dgvHD.Rows[index].Cells[3].Value.ToString();
                if (dgvHD.Rows[index].Cells[4].Value == null)
                {
                    fr.Kh = "";
                }
                else
                {
                    fr.Kh = dgvHD.Rows[index].Cells[4].Value.ToString();
                }
                fr.Tongtien = dgvHD.Rows[index].Cells[2].Value.ToString();
                fr.ShowDialog();
            }
            catch
            {
                return;
            }
        }
    }
}
