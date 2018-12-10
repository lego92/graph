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
        public Form2(int chartAreasCount, int seriesCount, Form1 f)
        {
            InitializeComponent();
            ff = f;
            for (int i = 0; i < chartAreasCount; i++)
            {
                cmbbxChartArea.Items.Add(i + 1);
            }
            cmbbxChartArea.SelectedIndex = 0;

            txtbxGraphName.Text = "Без названия" + (int)(seriesCount + 1);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ff.GraphName = txtbxGraphName.Text;
            ff.ChartArea = "ChartArea" + (int)(cmbbxChartArea.SelectedIndex + 1);
            this.Close();
        }
    }
}
