using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class KhoiHoc_BLL
    {
        KhoiHoc_DAL kh = new KhoiHoc_DAL();

        public KhoiHoc_BLL() { }

        public DataTable getData()
        {
            return kh.getData();
        }

        public bool insertKH(string maKH, string tenKH)
        {
            return kh.insertKH(maKH, tenKH);

        }

        public bool updateKH(string tenKH, string maKH)
        {
            return kh.updateKH(tenKH, maKH);
        }
        public bool deleteKH(string maKH)
        {
            return kh.deleteKH(maKH);
        }

        public bool KTKC(string maKH)
        {
            return kh.KTKC(maKH);
        }
    }
}
