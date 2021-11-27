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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            SetCBB();
            SetCBBSort();
        }
        public void SetCBBSort()
        {
            int t = 0;
            foreach (DataColumn i in CSDL.Instance.DSDT.Columns)
            {
                comboBox2.Items.Add(new CBBITEM
                {
                    Text = i.ColumnName,
                    Value = t++

                });
            }


        }
        public void SetCBB()
        {

            comboBox1.Items.Add(new CBBITEM
            {
                Value = 0,
                Text = "All"
            });
            //  cbbLopSH.SelectedIndex = 0;
            foreach (HangDT i in CSDL_OOP.Instance.GetAllHDT())
            {
                comboBox1.Items.Add(new CBBITEM
                {
                    Value = i.MHDT,
                    Text = i.NameH

                });
            }


        }
        public void Show1(int MHDT, string name)
        {
            dataGridView1.DataSource = CSDL_OOP.Instance.GetListSV(MHDT, name);

        }

        private void bt_show_Click(object sender, EventArgs e)
        {
            Show1(((CBBITEM)comboBox1.SelectedItem).Value, textBox1.Text);
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3(null);
            f.Show();
            f.d += new Form3.Mydel(Show1);
        }

        private void bt_edit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                string MDT = dataGridView1.SelectedRows[0].Cells["MDT"].Value.ToString();
                Form3 f = new Form3(MDT);
                f.d += new Form3.Mydel(Show1);
                f.Show();
            }
        }

        private void bt_det_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                string MDT = dataGridView1.SelectedRows[0].Cells["MDT"].Value.ToString();
                CSDL_OOP.Instance.delete(MDT);

            }

            Show1(((CBBITEM)comboBox1.SelectedItem).Value, textBox1.Text);
        }

        private void bt_sort_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.ToString() == "MDT")
            {
                dataGridView1.DataSource = CSDL_OOP.Instance.sort(new CSDL_OOP.Compare(DT.comparems), comboBox1.SelectedIndex, "");
            }
            if (comboBox2.SelectedItem.ToString() == "NameDT")
            {
                dataGridView1.DataSource = CSDL_OOP.Instance.sort(new CSDL_OOP.Compare(DT.comparename), comboBox1.SelectedIndex, "");
            }
            if (comboBox2.SelectedItem.ToString() == "Gia")
            {
                dataGridView1.DataSource = CSDL_OOP.Instance.sort(new CSDL_OOP.Compare(DT.CompareGia), comboBox1.SelectedIndex, "");
            }
            if (comboBox2.SelectedItem.ToString() == "NSX")
            {
                dataGridView1.DataSource = CSDL_OOP.Instance.sort(new CSDL_OOP.Compare(DT.CompareNSX), comboBox1.SelectedIndex, "");
            }
            if (comboBox2.SelectedItem.ToString() == "MHDT")
            {
                dataGridView1.DataSource = CSDL_OOP.Instance.sort(new CSDL_OOP.Compare(DT.CompareMHDT), comboBox1.SelectedIndex, "");
            }
        }
    }
}
