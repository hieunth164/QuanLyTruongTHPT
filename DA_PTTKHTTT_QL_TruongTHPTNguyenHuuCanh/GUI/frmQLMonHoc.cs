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
    public partial class frmQLMonHoc : Form
    {
        MonHoc_BLL mh = new MonHoc_BLL();
        public frmQLMonHoc()
        {
            InitializeComponent();
        }

        private void frmQLMonHoc_Load(object sender, EventArgs e)
        {
            load_DGVMonHoc();
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }

        private void load_DGVMonHoc()
        {
            dgvMonHoc.DataSource = mh.getData();
        }

        private void chkMaTuDong_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMaTuDong.Checked == true)
            {
                int coso = int.Parse(mh.getMaTuDong().ToString());
                coso++;
                if (coso < 10)
                    txtMaMonHoc.Text = "MH00" + coso.ToString();
                else if (coso < 100)
                    txtMaMonHoc.Text = "MH0" + coso.ToString();
                else
                    txtMaMonHoc.Text = "MH" + coso.ToString();
                txtMaMonHoc.Enabled = false;
            }
            else
            {
                txtMaMonHoc.Clear();
                txtMaMonHoc.Enabled = true;

            }
        }

        private void txtSoTiet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ được nhập số");
            }
        }

        private void txtHeSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ được nhập số");
            }
        }

        private void dgvMonHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex == -1) return;
            txtMaMonHoc.Text = dgvMonHoc.Rows[index].Cells[0].Value.ToString().Trim();
            txtTenMonHoc.Text = dgvMonHoc.Rows[index].Cells[1].Value.ToString().Trim();
            txtSoTiet.Text = dgvMonHoc.Rows[index].Cells[2].Value.ToString().Trim();
            txtHeSo.Text = dgvMonHoc.Rows[index].Cells[3].Value.ToString().Trim();

            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaMonHoc.Clear();
            txtTenMonHoc.Clear();
            txtHeSo.Clear();
            txtSoTiet.Clear();
            txtMaMonHoc.Enabled = true;
            chkMaTuDong.Checked = false;
            txtMaMonHoc.Focus();

            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;

            load_DGVMonHoc();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn xóa môn học", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                mh.deleteMH(dgvMonHoc.CurrentRow.Cells[0].Value.ToString());
                MessageBox.Show("Xóa thành công");
                load_DGVMonHoc();
            }
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (mh.KTKC(txtMaMonHoc.Text) == false)
                {
                    DialogResult r = MessageBox.Show("Bạn muốn thay đổi thông tin môn học", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        if (mh.updateMH(txtTenMonHoc.Text, int.Parse(txtSoTiet.Text), int.Parse(txtHeSo.Text), txtMaMonHoc.Text))
                        {
                            MessageBox.Show("Cập nhập thành công");
                            load_DGVMonHoc();
                            btnLuu.Enabled = false;
                            btnXoa.Enabled = false;
                            btnSua.Enabled = false;
                        }
                        else
                            MessageBox.Show("Thất bại");
                    }
                }
                else
                {
                    MessageBox.Show("Mã môn học không tồn tại!");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Thất bại");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaMonHoc.Text == "" || txtTenMonHoc.Text == "" || txtHeSo.Text == "" || txtSoTiet.Text == "")
                {
                    MessageBox.Show("Không được để trống");
                }
                else
                {
                    if (mh.KTKC(txtMaMonHoc.Text) == true)
                    {
                        DialogResult r = MessageBox.Show("Xác nhận lưu thông tin môn học", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (r == DialogResult.Yes)
                        {
                            if (mh.insertMH(txtMaMonHoc.Text, txtTenMonHoc.Text, int.Parse(txtSoTiet.Text), int.Parse(txtHeSo.Text)))
                            {
                                MessageBox.Show("Lưu thành công");
                                load_DGVMonHoc();
                                btnLuu.Enabled = false;
                                btnXoa.Enabled = false;
                                btnSua.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã môn học bị trùng!");
                        return;
                    }

                }
            }
            catch
            {
                MessageBox.Show("Thất bại");
            }
        }
    }
}
