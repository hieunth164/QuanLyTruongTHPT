using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.QL_TruongTHPTNguyenHuuCanhTableAdapters;
using System.Data;

namespace DAL
{
    public class PhanCong_DAL
    {
        PhanCongTableAdapter pc = new PhanCongTableAdapter();

        public PhanCong_DAL() { }

        public DataTable getDataPhanCong()
        {
            return pc.GetDataByPhanCongGiangDay();
        }

        public bool insertPC(string maLH, string maGV)
        {
            try
            {
                pc.Insert(maLH, maGV);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updatePC(string maGV, string maLH)
        {
            try
            {
                pc.UpdatePhanCong(maGV, maLH);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deletePC(string maLH, string maGV)
        {
            try
            {
                pc.DeletePhanCong(maLH,maGV);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool KTKC(string maLH, string maGV)
        {
            try
            {
                if (pc.KTKC(maLH,maGV) > 0)
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
