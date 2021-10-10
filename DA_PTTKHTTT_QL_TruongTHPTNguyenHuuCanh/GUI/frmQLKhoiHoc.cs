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
    public partial class frmQLKhoiHoc : Form
    {
        KhoiHoc_BLL kh = new KhoiHoc_BLL();

        public frmQLKhoiHoc()
        {
            InitializeComponent();
        }

        private void frmQLKhoiHoc_Load(object sender, EventArgs e)
        {
            load_DGVKhoiHoc();
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }
        private void load_DGVKhoiHoc()
        {
            dgvKhoiHoc.DataSource = kh.getData();
        }

        private void dgvKhoiHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex == -1) return;
            txtMaKhoiLop.Text = dgvKhoiHoc.Rows[index].Cells[0].Value.ToString().Trim();
            txtTenKhoiLop.Text = dgvKhoiHoc.Rows[index].Cells[1].Value.ToString().Trim();

            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaKhoiLop.Clear();
            txtTenKhoiLop.Clear();
            txtMaKhoiLop.Focus();

            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;

            load_DGVKhoiHoc();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn xóa khối học", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                kh.deleteKH(dgvKhoiHoc.CurrentRow.Cells[0].Value.ToString());
                MessageBox.Show("Xóa thành công");
                load_DGVKhoiHoc();
            }
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (kh.KTKC(txtMaKhoiLop.Text) == false)
                {
                    DialogResult r = MessageBox.Show("Bạn muốn thay đổi thông tin khối học", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        if (kh.updateKH(txtTenKhoiLop.Text, txtMaKhoiLop.Text))
                        {
                            MessageBox.Show("Cập nhập thành công");
                            load_DGVKhoiHoc();
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
                    MessageBox.Show("Mã khối học không tồn tại!");
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
                if (txtMaKhoiLop.Text == "" || txtTenKhoiLop.Text == "")
                {
                    MessageBox.Show("Không được để trống");
                }
                else
                {
                    if (kh.KTKC(txtMaKhoiLop.Text) == true)
                    {
                        DialogResult r = MessageBox.Show("Xác nhận lưu thông tin khối học", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (r == DialogResult.Yes)
                        {
                            if (kh.insertKH(txtMaKhoiLop.Text, txtTenKhoiLop.Text))
                            {
                                MessageBox.Show("Lưu thành công");
                                load_DGVKhoiHoc();
                                btnLuu.Enabled = false;
                                btnXoa.Enabled = false;
                                btnSua.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã khối học bị trùng!");
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
