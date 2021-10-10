using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.QL_TruongTHPTNguyenHuuCanhTableAdapters;
using System.Data;

namespace DAL
{
    public class KhoiHoc_DAL
    {
        KhoiHocTableAdapter kh = new KhoiHocTableAdapter();

        public KhoiHoc_DAL() { }

        public DataTable getData()
        {
            return kh.GetData();
        }

        public bool insertKH(string maKH, string tenKH)
        {
            try
            {
                kh.Insert(maKH, tenKH);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updateKH(string tenKH, string maKH)
        {
            try
            {
                kh.UpdateKhoiHoc(tenKH, maKH);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteKH(string maKH)
        {
            try
            {
                kh.DeleteKhoiHoc(maKH);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool KTKC(string maKH)
        {
            try
            {
                if (kh.KTKC(maKH) > 0)
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
