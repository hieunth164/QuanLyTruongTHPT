using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class MonHoc_BLL
    {
        MonHoc_DAL mh = new MonHoc_DAL();

        public MonHoc_BLL() { }

        public DataTable getData()
        {
            return mh.getData();
        }

        public int? getMaTuDong()
        {
            return mh.getMaTuDong();
        }

        public bool insertMH(string maMH, string tenMH, int soTiet, int heSo)
        {
            return mh.insertMH(maMH, tenMH, soTiet, heSo);
        }

        public bool updateMH(string tenMH, int soTiet, int heSo, string maMH)
        {
            return mh.updateMH(tenMH, soTiet, heSo, maMH);
        }
        public bool deleteMH(string maMH)
        {
            return mh.deleteMH(maMH);
        }

        public bool KTKC(string maMH)
        {
            return mh.KTKC(maMH);
        }

        public DataTable getDataByMaMH(string maMH)
        {
            return mh.getDataByMaMH(maMH);
        }
    }
}
