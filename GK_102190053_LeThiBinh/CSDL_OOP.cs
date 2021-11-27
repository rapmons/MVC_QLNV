using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace GK_102190053_LeThiBinh
{
    class CSDL_OOP
    {
        private static CSDL_OOP _Instance;
        public static CSDL_OOP Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new CSDL_OOP();
                return _Instance;
            }


        }
        private CSDL_OOP()
        { }
        public List<DT> GetAllDT()
        {
            List<DT> data = new List<DT>();
            foreach (DataRow i in CSDL.Instance.DSDT.Rows)
            {
                data.Add(GetDT(i));
            }
            return data;

        }
        public DT GetDT(DataRow i)
        {
            return new DT
            {
                MDT = i["MDT"].ToString(),
                NameDT = i["NameDT"].ToString(),
                NSX = Convert.ToDateTime(i["NSX"].ToString()),
                Gia = Convert.ToDouble(i["Gia"].ToString()),
                MHDT = Convert.ToInt32(i["MHDT"].ToString()),
            };

        }
        public List<HangDT> GetAllHDT()
        {
            List<HangDT> data = new List<HangDT>();
            foreach (DataRow i in CSDL.Instance.DSHDT.Rows)
            {
                data.Add(GetHDT(i));
            }
            return data;

        }
        public HangDT GetHDT(DataRow i)
        {
            return new HangDT
            {
                MHDT = Convert.ToInt32(i["MHDT"].ToString()),
                NameH = i["NameH"].ToString()


            };

        }
        public List<DT> GetListSV(int MHDT, string name)
        {
            List<DT> data = new List<DT>();
            foreach (DT i in GetAllDT())
            {
                if (i.MHDT == MHDT && i.NameDT.Contains(name))
                {
                    data.Add(new DT
                    {
                        MDT = i.MDT,
                        NameDT = i.NameDT,
                        NSX = i.NSX,
                        Gia = i.Gia,
                        MHDT = i.MHDT

                    });

                }
                if (MHDT == 0 && i.NameDT.Contains(name))
                {
                    data.Add(i);
                }
            }


            return data;

        }
        public DT GetsvByMDT(string MDT)
        {
            if (MDT == null)
                return null;
            else
            {
                DT s = new DT();
                foreach (DT i in GetAllDT())
                {
                    if (i.MDT == MDT)
                    { s = i; }
                }
                return s;
            }
        }
        public List<DT> sort(Compare cmp, int MHDT, string name)
        {
            List<DT> data = CSDL_OOP.Instance.GetListSV(MHDT, name);
            for (int i = 0; i < data.Count - 1; i++)
            {
                for (int j = i + 1; j < data.Count; j++)
                {
                    if (cmp(data[i], data[j]))
                    {
                        DT t = data[i];
                        data[i] = data[j];
                        data[j] = t;
                    }
                }
            }
            return data;
        }
        public delegate Boolean Compare(DT s1, DT s2);

        public void delete(string MSSV)
        {
            CSDL.Instance.delete1(MSSV);
        }

        public void execute(DT s)
        {
            bool check = false;
            foreach (DT i in GetAllDT())
            {
                if (i.MDT == s.MDT)
                {
                    check = true;
                }

            }
            if (check)
            {
                CSDL.Instance.Edit(s);

            }
            else
            {
                CSDL.Instance.ADD(s);
            }
        }
    }
}
