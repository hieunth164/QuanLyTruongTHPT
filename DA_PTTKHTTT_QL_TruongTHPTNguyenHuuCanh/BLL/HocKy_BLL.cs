using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
namespace BLL
{
    public class HocKy_BLL
    {
        HocKy_DAL hk = new HocKy_DAL();

        public HocKy_BLL() { }

        public DataTable getData()
        {
            return hk.getData();
        }

        public bool insertHK(string maHK, string tenHK)
        {
            return hk.insertHK(maHK, tenHK);

        }

        public bool updateHK(string tenHK, string maHK)
        {
            return hk.updateHK(tenHK, maHK);
        }
        public bool deleteHK(string maHK)
        {
            return hk.deleteHK(maHK);
        }

        public bool KTKC(string maHK)
        {
            return hk.KTKC(maHK);
        }
    }
}
