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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        { if (cr11.Password.ToString() == "1001" && cr11.Name.ToString() == "hehe")
            {
                Form2 f = new Form2();
                f.Show();
            }
            else MessageBox.Show("nhap lai de");
           
        }
    }
}
