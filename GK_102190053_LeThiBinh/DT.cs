using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_102190053_LeThiBinh
{
    class DT
    {
        public string MDT { get; set; }
        public string NameDT { get; set; }
        public DateTime NSX { get; set; }
        public double Gia { get; set; }
        public int MHDT { get; set; }
        public static bool comparems(DT s1, DT s2)
        {
            if (String.Compare(s1.MDT, s2.MDT) > 0)
                return true;
            else return false;
        }
        public static bool comparename(DT s1, DT s2)
        {
            if (String.Compare(s1.NameDT, s2.NameDT) > 0)
                return true;
            else return false;
        }

        public static bool CompareMHDT(DT s1, DT s2)
        {
            if (s1.MHDT > s2.MHDT)
                return true;
            else return false;
        }
        public static bool CompareNSX(DT s1, DT s2)
        {
            if (DateTime.Compare(s1.NSX, s2.NSX) >= 0)
                return true;
            else return false;
        }
        public static bool CompareGia(DT s1, DT s2)
        {
            if (s1.Gia >= s2.Gia)
                return true;
            else return false;
        }

    }
}
