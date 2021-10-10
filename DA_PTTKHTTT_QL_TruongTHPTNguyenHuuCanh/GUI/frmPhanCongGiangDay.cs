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
    public partial class frmPhanCongGiangDay : Form
    {
        NamHoc_BLL nh = new NamHoc_BLL();
        LopHoc_BLL lh = new LopHoc_BLL();
        GiaoVien_BLL gv = new GiaoVien_BLL();
        MonHoc_BLL mh = new MonHoc_BLL();
        PhanCong_BLL pc = new PhanCong_BLL();
        public frmPhanCongGiangDay()
        {
            InitializeComponent();
        }

        private void frmPhanCongGiangDay_Load(object sender, EventArgs e)
        {
            loadComboBoxNamHoc();
            loadComboBoxGiaoVien();
            cbGiaoVien.SelectedIndex = -1;
            txtTenMH.Text = "";
            load_DGVPhanCong();
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void load_DGVPhanCong()
        {
            dgvPhanCong.DataSource = pc.getDataPhanCong();
        }

        private void loadComboBoxNamHoc()
        {
            cbNamHoc.DataSource = nh.loadComboBoxNamHoc();
            cbNamHoc.DisplayMember = nh.loadComboBoxNamHoc().Columns[1].ToString();
            cbNamHoc.ValueMember = nh.loadComboBoxNamHoc().Columns[0].ToString();
        }

        private void loadComboBoxGiaoVien()
        {
            cbGiaoVien.DataSource = gv.getData();
            cbGiaoVien.DisplayMember = gv.getData().Columns[1].ToString();
            cbGiaoVien.ValueMember = gv.getData().Columns[0].ToString();
        }

        private void cbNamHoc_SelectedValueChanged(object sender, EventArgs e)
        {
            cbLopHoc.SelectedIndex = -1;
            if (cbNamHoc.SelectedValue.ToString() == "ALL")
            {
                cbLopHoc.DataSource = lh.getData();
                cbLopHoc.DisplayMember = lh.getData().Columns[1].ToString();
                cbLopHoc.ValueMember = lh.getData().Columns[0].ToString();
            }
            else
            {
                cbLopHoc.DataSource = lh.loadComboBoxLop(cbNamHoc.SelectedValue.ToString());
                cbLopHoc.DisplayMember = lh.loadComboBoxLop(cbNamHoc.SelectedValue.ToString()).Columns[1].ToString();
                cbLopHoc.ValueMember = lh.loadComboBoxLop(cbNamHoc.SelectedValue.ToString()).Columns[0].ToString();
            }
        }

        private void cbGiaoVien_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbGiaoVien.SelectedIndex == -1)
            {
                txtMonHoc.Clear();
            }
            else
            {
                foreach (DataRow dr in gv.getDataByMaGV(cbGiaoVien.SelectedValue.ToString()).Rows)
                {
                    txtMonHoc.Text = (dr["MaMonHoc"].ToString());
                }
            }
        }

        private void txtMonHoc_TextChanged(object sender, EventArgs e)
        {
            foreach (DataRow dr in mh.getDataByMaMH(txtMonHoc.Text).Rows)
            {
                txtTenMH.Text = (dr["TenMonHoc"].ToString());
            }
        }

        private void dgvPhanCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (pc.KTKC(cbLopHoc.SelectedValue.ToString(), cbGiaoVien.SelectedValue.ToString()) == true)
                {
                    DialogResult r = MessageBox.Show("Xác nhận lưu thông tin phân công", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        if (pc.insertPC(cbLopHoc.SelectedValue.ToString(), cbGiaoVien.SelectedValue.ToString()))
                        {
                            MessageBox.Show("Lưu thành công");
                            btnLuu.Enabled = false;
                            btnXoa.Enabled = false;
                            load_DGVPhanCong();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Phân công bị trùng!");
                    return;
                }

            }
            catch
            {
                MessageBox.Show("Thất bại");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn xóa phân công", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                pc.deletePC(dgvPhanCong.CurrentRow.Cells[0].Value.ToString(), dgvPhanCong.CurrentRow.Cells[1].Value.ToString());
                MessageBox.Show("Xóa thành công");

            }
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            load_DGVPhanCong();
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            loadComboBoxNamHoc();
            loadComboBoxGiaoVien();
            cbGiaoVien.SelectedIndex = -1;
            txtTenMH.Text = "";
            txtMonHoc.Text = "";
            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
        }
    }
}
