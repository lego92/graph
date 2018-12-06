using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace superGraph
{
    public partial class Form2 : Form
    {
        Form1 ff;
        public Form2(int count, Form1 f)
        {
            InitializeComponent();
            ff = f;
            for (int i = 0; i < count; i++)
            {
                comboBox1.Items.Add(i+1);
            }
            comboBox1.SelectedIndex = 0;
        }

        public void GetValues(ref string name, ref int chartAreaNumber)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ff.GraphName = textBox1.Text;
            ff.ChartArea = comboBox1.SelectedIndex + 1;
            this.Close();
        }
    }
}
