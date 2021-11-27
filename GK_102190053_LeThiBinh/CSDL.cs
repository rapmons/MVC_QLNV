using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace GK_102190053_LeThiBinh
{
    class CSDL
    {
        public DataTable DSHDT { get; set; }
        public DataTable DSDT { get; set; }
        public static CSDL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CSDL();
                }
                return _Instance;
            }
            private set
            {

            }
        }
        private static CSDL _Instance;
        private CSDL()
        {
            DSDT = new DataTable();
            DSDT.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("MDT",typeof(string)),
                  new DataColumn("NameDT",typeof(string)),
                   new DataColumn("NSX",typeof(DateTime)),
                new DataColumn("Gia",typeof(double)),
                 new DataColumn("MHDT",typeof(int)),


            }

                );
            DataRow dr = DSDT.NewRow();
            dr["MDT"] = "10002"; dr["NameDT"] = "IPHONE7s";
            dr["NSX"] = DateTime.Now; dr["Gia"] = 100.999;
            dr["MHDT"] = 1;
            DSDT.Rows.Add(dr);
            DataRow dr1 = DSDT.NewRow();
            dr1["MDT"] = "10003"; dr1["NameDT"] = "samsung1";
            dr1["NSX"] = DateTime.Now; dr1["Gia"] = 109.999;
            dr1["MHDT"] = 2;
            DSDT.Rows.Add(dr1);
            DataRow dr2 = DSDT.NewRow();
            dr2["MDT"] = "10004"; dr2["NameDT"] = "samsung2";
            dr2["NSX"] = DateTime.Now; dr2["Gia"] = 110.999;
            dr2["MHDT"] = 2;
            DSDT.Rows.Add(dr2);
            DataRow dr3 = DSDT.NewRow();
            dr3["MDT"] = "10005"; dr3["NameDT"] = "convit1";
            dr3["NSX"] = DateTime.Now; dr3["Gia"] = 200.999;
            dr3["MHDT"] = 3;
            DSDT.Rows.Add(dr3);


            DSHDT = new DataTable();
            DSHDT.Columns.AddRange(new DataColumn[]
            {
                new DataColumn ("MHDT", typeof(int)),
                new DataColumn ("NameH", typeof(string)),
            });
            DataRow dr4 = DSHDT.NewRow();
            dr4["MHDT"] = 1; dr4["NameH"] = "iphone";
            DSHDT.Rows.Add(dr4);
            DataRow dr5 = DSHDT.NewRow();
            dr5["MHDT"] = 2; dr5["NameH"] = "SAMSUNG";
            DSHDT.Rows.Add(dr5);
            DataRow dr6 = DSHDT.NewRow();
            dr6["MHDT"] = 3; dr6["NameH"] = "CONVIT";
            DSHDT.Rows.Add(dr6);
        }
        public void ADD(DT s)
        {

            DataRow dr = DSDT.NewRow();
            dr["MDT"] = s.MDT; dr["NameDT"] = s.NameDT;
            dr["NSX"] = s.NSX; dr["Gia"] = s.Gia;
            dr["MHDT"] = s.MHDT;
            DSDT.Rows.Add(dr);

        }
        public void Edit(DT s)
        {

            foreach (DataRow dr in DSDT.Rows)
            {
                if (dr["MDT"].ToString() == s.MDT)
                {
                    dr["NameDT"] = s.NameDT;
                    dr["NSX"] = s.NSX; dr["Gia"] = s.Gia;
                    dr["MHDT"] = s.MHDT;

                }

            }
        }
        public void delete1(string MDT)
        {
           
            foreach (DataRow dr in DSDT.Rows)
            {
                
                if (dr["MDT"].ToString() == MDT)
                {
                    dr.Delete();
                }
               

            }


        }

    }
}

    
    

