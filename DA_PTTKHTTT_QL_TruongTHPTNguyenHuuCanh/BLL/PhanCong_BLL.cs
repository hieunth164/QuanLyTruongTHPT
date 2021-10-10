using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
    public class PhanCong_BLL
    {
        PhanCong_DAL pc = new PhanCong_DAL();

        public PhanCong_BLL() { }

        public DataTable getDataPhanCong()
        {
            return pc.getDataPhanCong();
        }

        public bool insertPC(string maLH, string maGV)
        {
            return pc.insertPC(maLH, maGV);
        }

        public bool updatePC(string maGV, string maLH)
        {
            return pc.updatePC(maGV, maLH);
        }
        public bool deletePC(string maLH, string maGV)
        {
            return pc.deletePC(maLH, maGV);
        }

        public bool KTKC(string maLH, string maGV)
        {
            return pc.KTKC(maLH, maGV);
        }

    }
}
