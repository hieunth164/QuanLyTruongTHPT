using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.QL_TruongTHPTNguyenHuuCanhTableAdapters;
using System.Data;

namespace DAL
{
    public class LopHoc_DAL
    {
        LopHocTableAdapter lh = new LopHocTableAdapter();

        public LopHoc_DAL() { }

        public DataTable getData()
        {
            DataTable dt = lh.GetData();

            DataRow dr = dt.NewRow();
            dr["MaLopHoc"] = "ALL";
            dr["TenLopHoc"] = "ALL";
            dr["SiSo"] = 0;
            dr["MaKhoiLop"] = "";
            dr["MaNamHoc"] = "";
            dr["MaGiaoVien"] = "";


            dt.Rows.InsertAt(dr, 0);
            return dt;
        }

        public DataTable loadComboBoxLop(string maNH)
        {
            return lh.GetDataByMaNamHoc(maNH);
        }
        
    }
}
