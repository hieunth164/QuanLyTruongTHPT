using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.QL_TruongTHPTNguyenHuuCanhTableAdapters;
using System.Data;

namespace DAL
{
    public class HocKy_DAL
    {
        HocKyTableAdapter hk = new HocKyTableAdapter();

        public HocKy_DAL()
        {

        }

        public DataTable getData()
        {
            return hk.GetData();
        }

        public bool insertHK(string maHK, string tenHK)
        {
            try
            {
                hk.Insert(maHK, tenHK);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updateHK(string tenHK, string maHK)
        {
            try
            {
                hk.UpdateHocKy(tenHK, maHK);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteHK(string maHK)
        {
            try
            {
                hk.DeleteHocKy(maHK);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool KTKC(string maHK)
        {
            try
            {
                if (hk.KTKC(maHK) > 0)
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
