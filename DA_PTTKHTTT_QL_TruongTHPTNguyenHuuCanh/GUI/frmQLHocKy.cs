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
    public partial class frmQLHocKy : Form
    {
        HocKy_BLL hk = new HocKy_BLL();
        public frmQLHocKy()
        {
            InitializeComponent();
        }

        private void frmQLHocKy_Load(object sender, EventArgs e)
        {
            load_DGVHocKy();
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }

        private void load_DGVHocKy()
        {
            dgvHocKy.DataSource = hk.getData();
        }

        private void dgvHocKy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex == -1) return;
            txtMaHocKy.Text = dgvHocKy.Rows[index].Cells[0].Value.ToString().Trim();
            txtTenHocKy.Text = dgvHocKy.Rows[index].Cells[1].Value.ToString().Trim();

            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaHocKy.Clear();
            txtTenHocKy.Clear();
            txtMaHocKy.Focus();

            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;

            load_DGVHocKy();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn xóa học kỳ", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                hk.deleteHK(dgvHocKy.CurrentRow.Cells[0].Value.ToString());
                MessageBox.Show("Xóa thành công");
                load_DGVHocKy();
            }
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (hk.KTKC(txtMaHocKy.Text) == false)
                {
                    DialogResult r = MessageBox.Show("Bạn muốn thay đổi thông tin học kỳ", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        if (hk.updateHK(txtTenHocKy.Text, txtMaHocKy.Text))
                        {
                            MessageBox.Show("Cập nhập thành công");
                            load_DGVHocKy();
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
                    MessageBox.Show("Mã học kỳ không tồn tại!");
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
                if (txtMaHocKy.Text == "" || txtTenHocKy.Text == "")
                {
                    MessageBox.Show("Không được để trống");
                }
                else
                {
                    if (hk.KTKC(txtMaHocKy.Text) == true)
                    {
                        DialogResult r = MessageBox.Show("Xác nhận lưu thông tin học kỳ", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (r == DialogResult.Yes)
                        {
                            if (hk.insertHK(txtMaHocKy.Text, txtTenHocKy.Text))
                            {
                                MessageBox.Show("Lưu thành công");
                                load_DGVHocKy();
                                btnLuu.Enabled = false;
                                btnXoa.Enabled = false;
                                btnSua.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã học kỳ bị trùng!");
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
