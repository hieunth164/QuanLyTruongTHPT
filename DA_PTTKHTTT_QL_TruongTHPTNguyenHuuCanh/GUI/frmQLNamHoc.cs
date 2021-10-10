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
    public partial class frmQLNamHoc : Form
    {
        NamHoc_BLL nh = new NamHoc_BLL();
        public frmQLNamHoc()
        {
            InitializeComponent();
        }

        private void frmQLNamHoc_Load(object sender, EventArgs e)
        {
            load_DGVNamHoc();
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }
        private void load_DGVNamHoc()
        {
            dgvNamHoc.DataSource = nh.getData();
        }

        private void dgvNamHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex == -1) return;
            txtMaNamHoc.Text = dgvNamHoc.Rows[index].Cells[0].Value.ToString().Trim();
            txtTenNamHoc.Text = dgvNamHoc.Rows[index].Cells[1].Value.ToString().Trim();

            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaNamHoc.Clear();
            txtTenNamHoc.Clear();
            txtMaNamHoc.Focus();

            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;

            load_DGVNamHoc();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn xóa năm học", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                nh.deleteNH(dgvNamHoc.CurrentRow.Cells[0].Value.ToString());
                MessageBox.Show("Xóa thành công");
                load_DGVNamHoc();
            }
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (nh.KTKC(txtMaNamHoc.Text) == false)
                {
                    DialogResult r = MessageBox.Show("Bạn muốn thay đổi thông tin năm học", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        if (nh.updateNH(txtTenNamHoc.Text, txtMaNamHoc.Text))
                        {
                            MessageBox.Show("Cập nhập thành công");
                            load_DGVNamHoc();
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
                    MessageBox.Show("Mã năm học không tồn tại!");
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
                if (txtMaNamHoc.Text == "" || txtTenNamHoc.Text == "")
                {
                    MessageBox.Show("Không được để trống");
                }
                else
                {
                    if (nh.KTKC(txtMaNamHoc.Text) == true)
                    {
                        DialogResult r = MessageBox.Show("Xác nhận lưu thông tin năm học", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (r == DialogResult.Yes)
                        {
                            if (nh.insertNH(txtMaNamHoc.Text, txtTenNamHoc.Text))
                            {
                                MessageBox.Show("Lưu thành công");
                                load_DGVNamHoc();
                                btnLuu.Enabled = false;
                                btnXoa.Enabled = false;
                                btnSua.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã năm học bị trùng!");
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
