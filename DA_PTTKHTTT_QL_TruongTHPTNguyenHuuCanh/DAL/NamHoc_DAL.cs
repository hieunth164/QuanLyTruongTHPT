using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.QL_TruongTHPTNguyenHuuCanhTableAdapters;
using System.Data;

namespace DAL
{
    public class NamHoc_DAL
    {
        NamHocTableAdapter nh = new NamHocTableAdapter();

        public NamHoc_DAL() { }

        public DataTable getData()
        {
            return nh.GetData();
        }

        public DataTable loadComboBoxNamHoc()
        {
            //return daKhoa.GetData();
            DataTable dt = nh.GetData();

            DataRow dr = dt.NewRow();
            dr["MaNamHoc"] = "ALL";
            dr["TenNamHoc"] = "ALL";

            dt.Rows.InsertAt(dr, 0);
            return dt;
        }

        public bool insertNH(string maNH, string tenNH)
        {
            try
            {
                nh.Insert(maNH, tenNH);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updateNH(string tenNH, string maNH)
        {
            try
            {
                nh.UpdateNamHoc(tenNH, maNH);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteNH(string maNH)
        {
            try
            {
                nh.DeleteNamHoc(maNH);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool KTKC(string maNH)
        {
            try
            {
                if (nh.KTKC(maNH) > 0)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
