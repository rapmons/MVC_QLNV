using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GK_102190053_LeThiBinh
{
    public partial class Form3 : Form
    {

        public delegate void Mydel(int id, string name);
        public Mydel d { get; set; }
        public string MDT { get; set; }
        
        public Form3(string m)
        {
            InitializeComponent();
            MDT = m;
            setGui();
        }
        public void setGui()
        {
            foreach (HangDT i in CSDL_OOP.Instance.GetAllHDT())
            {
                comboBox1.Items.Add(new CBBITEM
                {
                    Value = i.MHDT,
                    Text = i.NameH
                });
            }
            if (CSDL_OOP.Instance.GetsvByMDT(MDT) != null)
            {
                DT s = new DT();
                s = CSDL_OOP.Instance.GetsvByMDT(MDT);
                textBox1.Text = s.MDT;
                textBox2.Text = s.NameDT;
                textBox3.Text = s.Gia.ToString();
                dateTimePicker1.Value = s.NSX;
                comboBox1.SelectedIndex = s.MHDT;
            }
            if (textBox1.Text != "")
            {
                textBox1.ReadOnly = true;

            }
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            DT s = new DT();
            if (textBox1.Text.Length == 5)
            {
                s.MDT = textBox1.Text;
                s.NameDT = textBox2.Text;
                s.Gia = Convert.ToDouble(textBox3.Text);
                s.NSX = dateTimePicker1.Value;
                s.MHDT = comboBox1.SelectedIndex + 1;

                CSDL_OOP.Instance.execute(s);


                d(((CBBITEM)comboBox1.SelectedItem).Value, "");
            }
            else MessageBox.Show("nhap lai de");
            

        }
    }
}
