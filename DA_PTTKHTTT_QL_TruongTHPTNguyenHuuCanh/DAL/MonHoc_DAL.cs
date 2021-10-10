using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.QL_TruongTHPTNguyenHuuCanhTableAdapters;

namespace DAL
{
    public class MonHoc_DAL
    {
        MonHocTableAdapter mh = new MonHocTableAdapter();

        public MonHoc_DAL() { }

        public DataTable getData()
        {
            return mh.GetData();
        }

        public int? getMaTuDong()
        {
            return mh.MaMHTuDong();
        }

         public bool insertMH(string maMH, string tenMH, int soTiet, int heSo)
        {
            try
            {
                mh.Insert(maMH, tenMH, soTiet, heSo);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updateMH(string tenMH, int soTiet, int heSo, string maMH)
        {
            try
            {
                mh.UpdateMonHoc(tenMH,soTiet,heSo, maMH);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteMH(string maMH)
        {
            try
            {
                mh.DeleteMonHoc(maMH);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool KTKC(string maMH)
        {
            try
            {
                if (mh.KTKC(maMH) > 0)
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

        public DataTable getDataByMaMH(string maMH)
        {
            return mh.GetDataByMaMH(maMH);
        }
    }
}
