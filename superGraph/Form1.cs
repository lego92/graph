using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace superGraph
{
    delegate void LabelUpdaterDelegate(Label lbl, string lblText);
    delegate void PictureBoxUpdaterDelegate(PictureBox pctrbox, Color color);

    public partial class Form1 : Form
    {
        // буфер UInt16
        List<UInt16> buferU16 = new List<UInt16>();

        // буфер входных данных без амбулы и преамбулы                 
        List<byte> buferWithoutPreambula = new List<byte>();

        // буфер входных данных с амбулой и преамбулой   
        List<byte> buferIncoming = new List<byte>();

        // размер входного буфера в байтах 
        const int buferIncomingSize = 4000; //32008;                      

        // нормирование и форматирование
        double yMax;
        double yMin;

        const double amplVoltage = 2.50;
        const double maxADC = 4095;

        // Samples/s
        const double sampleRate = 800;


        public Form1()
        {
            InitializeComponent();
            UpdatePortComboBox();
            cmbChartAreaChoice.Items.Add(1);
            cmbChartAreaChoice.SelectedIndex = 0;
            txtBoxGraphName.Text = "Без названия";
        }

        private void btnShowDataFrom_Click(object sender, EventArgs e)
        {
            // вывод из файла
            if (checkBoxSelectFileData.Checked)
            {
                if (dataChart.Series.Contains(dataChart.Series.FindByName(txtBoxGraphName.Text)))
                {
                    MessageBox.Show("График с таким названием уже существует!", "Ошибка");
                }
                else
                {
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        dataChart.Series.Add(txtBoxGraphName.Text);
                        dataChart.Series[txtBoxGraphName.Text].ChartType = SeriesChartType.Line;
                        dataChart.Series[txtBoxGraphName.Text].Legend = "Legend1";
                        dataChart.Series[txtBoxGraphName.Text].LegendText = txtBoxGraphName.Text;
                        dataChart.Series[txtBoxGraphName.Text].ChartArea = "ChartArea" + cmbChartAreaChoice.Text;

                        UpdateGraphsComboBox();

                        StreamReader streamReader = new StreamReader(openFileDialog1.FileName);

                        double x = 0.0;

                        double multiplier = 1;

                        if (chkbxIsGraphNormalized.Checked)
                        {
                            multiplier = amplVoltage / maxADC;
                        }

                        while (!streamReader.EndOfStream)
                        {
                            double y = Convert.ToDouble(streamReader.ReadLine());
                            y = y * multiplier;
                            dataChart.Series[txtBoxGraphName.Text].Points.AddXY(Math.Round(x, 5), Math.Round(y, 4));
                            x += 1 / sampleRate;
                        }
                        streamReader.Close();

                        // форматирование относительно yMax и yMin
                        DataPoint a = dataChart.Series[txtBoxGraphName.Text].Points.FindMaxByValue("Y1");
                        yMax = (double)a.YValues.GetValue(0);
                        a = dataChart.Series[txtBoxGraphName.Text].Points.FindMinByValue("Y1");
                        yMin = (double)a.YValues.GetValue(0);

                        FormatGraph(yMax, yMin, 1 / sampleRate, "ChartArea" + cmbChartAreaChoice.Text);
                    }
                }
            }
            // вывод из буфера
            else if (checkBoxSelectBufferData.Checked)
            {
                if (buferU16.Count == 0)
                {
                    MessageBox.Show("Буфер пуст!", "Ошибка");
                }
                else
                {
                    if (dataChart.Series.Contains(dataChart.Series.FindByName(txtBoxGraphName.Text)))
                    {
                        MessageBox.Show("График с таким названием уже существует!", "Ошибка");
                    }
                    else
                    {
                        dataChart.Series.Add(txtBoxGraphName.Text);
                        dataChart.Series[txtBoxGraphName.Text].ChartType = SeriesChartType.Line;
                        dataChart.Series[txtBoxGraphName.Text].Legend = "Legend1";
                        dataChart.Series[txtBoxGraphName.Text].LegendText = txtBoxGraphName.Text;
                        dataChart.Series[txtBoxGraphName.Text].ChartArea = "ChartArea" + cmbChartAreaChoice.Text;

                        UpdateGraphsComboBox();

                        double x = 0.0;

                        double multiplier = 1;

                        if (chkbxIsGraphNormalized.Checked)
                        {
                            multiplier = amplVoltage / maxADC;
                        }

                        for (int i = 0; i < buferU16.Count; i++)
                        {
                            double y = Convert.ToDouble(buferU16[i]);
                            y = y * multiplier;
                            dataChart.Series[txtBoxGraphName.Text].Points.AddXY(x, Math.Round(y, 4));
                            x += 1 / sampleRate;
                        }

                        // форматирование относительно yMax и yMin
                        DataPoint a = dataChart.Series[txtBoxGraphName.Text].Points.FindMaxByValue("Y1");
                        yMax = (double)a.YValues.GetValue(0);
                        a = dataChart.Series[txtBoxGraphName.Text].Points.FindMinByValue("Y1");
                        yMin = (double)a.YValues.GetValue(0);

                        FormatGraph(yMax, yMin, 1 / sampleRate, "ChartArea" + cmbChartAreaChoice.Text);

                    }
                }
            }
        }

        private void FormatGraph(double ymax, double ymin, double stepX, string chartAreaName)
        {
            // включить возможность выделения курсором области по оси X
            dataChart.ChartAreas[chartAreaName].CursorX.IsUserSelectionEnabled = true;
            // минимальный интервал зума курсора по оси X      
            dataChart.ChartAreas[chartAreaName].CursorX.Interval = stepX;
            // включить возможность зума по оси X                      
            dataChart.ChartAreas[chartAreaName].AxisX.ScaleView.Zoomable = true;
            // включить панель прокрутки по оси X            
            dataChart.ChartAreas[chartAreaName].AxisX.ScrollBar.IsPositionedInside = true;
            // шаг панели прокрутки по оси X   
            dataChart.ChartAreas[chartAreaName].AxisX.ScaleView.SmallScrollSize = 0.2;

            if (ymax >= dataChart.ChartAreas[chartAreaName].AxisY.Maximum ||
                                  double.IsNaN(dataChart.ChartAreas[chartAreaName].AxisY.Maximum))
            {
                // нижняя граница отображения по оси Y 
                dataChart.ChartAreas[chartAreaName].AxisY.Maximum = ymax;
            }
            if (ymin <= dataChart.ChartAreas[chartAreaName].AxisY.Minimum ||
                                  double.IsNaN(dataChart.ChartAreas[chartAreaName].AxisY.Minimum))
            {
                // верхняя граница отображения по оси Y 
                dataChart.ChartAreas[chartAreaName].AxisY.Minimum = ymin;
            }

            // аналогично с осью X
            dataChart.ChartAreas[chartAreaName].CursorY.IsUserSelectionEnabled = true;
            dataChart.ChartAreas[chartAreaName].CursorY.Interval = 0.005;
            dataChart.ChartAreas[chartAreaName].AxisY.ScaleView.Zoomable = true;
            dataChart.ChartAreas[chartAreaName].AxisY.ScrollBar.IsPositionedInside = true;
            dataChart.ChartAreas[chartAreaName].AxisY.ScaleView.SmallScrollSize = 0.005;
        }

        private void btnOpenPort_Click(object sender, EventArgs e)
        {
            OpenPort();
        }

        private void btnClosePort_Click(object sender, EventArgs e)
        {
            ClosePort();
        }

        public void OnDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (serialPort1.IsOpen && serialPort1.ReadBufferSize != 0)
            {
                UInt16 x;

                int size = serialPort1.BytesToRead;

                buferIncoming.Clear();

                buferWithoutPreambula.Clear();

                LabelUpdater(lblRecieve, "Прием данных из COM порта");

                PictureBoxUpdater(pctrbxDataRecivingIndicator, Color.Yellow);

                try
                {
                    for (int i = 0; i < size; i++)
                    {
                        buferIncoming.Add((byte)serialPort1.ReadByte());
                    }

                    for (int t = 0; t < buferIncoming.Count - 1; t += 2)
                    {
                        x = buferIncoming[t];
                        x = (UInt16)(x << 8);
                        x = (UInt16)(x | buferIncoming[t + 1]);
                        buferU16.Add(x);
                    }

                    LabelUpdater(lblCountOfValues, "Значений в буфере: " + buferU16.Count);

                    LabelUpdater(lblRecieve, "Данные получены!");

                    PictureBoxUpdater(pctrbxDataRecivingIndicator, Color.Green);
                }
                catch (IOException exc)
                {
                    serialPort1.DataReceived -= OnDataReceived;
                }                
            } 
        }

        private void LabelUpdater(Label label, string labelText)
        {

            if (label.InvokeRequired)
            {
                LabelUpdaterDelegate d = new LabelUpdaterDelegate(LabelUpdater);
                this.Invoke(d, new object[] { label, labelText });
            }
            else
            {
                label.Text = labelText;
            }
        }

        private void PictureBoxUpdater(PictureBox pctrbox, Color color)
        {

            if (pctrbox.InvokeRequired)
            {
                PictureBoxUpdaterDelegate d = new PictureBoxUpdaterDelegate(PictureBoxUpdater);
                this.Invoke(d, new object[] { pctrbox, color });
            }
            else
            {
                pctrbox.BackColor = color;
            }
        }

        private void UpdatePortComboBox()
        {
            cmbPort.Items.Clear();

            string[] ports = SerialPort.GetPortNames();

            foreach (string port in ports)
            {
                cmbPort.Items.Add(port);
            }

            if (ports.Length != 0)
            {
                cmbPort.SelectedIndex = 0;
            }            
        }

        private void btnRefreshPortsList_Click(object sender, EventArgs e)
        {
            UpdatePortComboBox();
        }

        private void btnCreateSecondChartArea_Click(object sender, EventArgs e)
        {
            if (dataChart.ChartAreas.Count != 2)
            {
                dataChart.ChartAreas.Add("ChartArea2");
                dataChart.ChartAreas["ChartArea2"].AxisX.IsMarginVisible = false;
                dataChart.ChartAreas["ChartArea2"].AxisX.MajorTickMark.Interval = 0.5D;
                dataChart.ChartAreas["ChartArea2"].AxisX.MaximumAutoSize = 25F;
                dataChart.ChartAreas["ChartArea2"].CursorX.Interval = 0.00125D;
                dataChart.ChartAreas["ChartArea2"].InnerPlotPosition.Auto = false;
                dataChart.ChartAreas["ChartArea2"].InnerPlotPosition.Height = 90F;
                dataChart.ChartAreas["ChartArea2"].InnerPlotPosition.Width = 90F;
                dataChart.ChartAreas["ChartArea2"].InnerPlotPosition.X = 10F;
                dataChart.ChartAreas["ChartArea2"].IsSameFontSizeForAllAxes = true;
                dataChart.ChartAreas["ChartArea2"].BackColor = Color.WhiteSmoke;
                dataChart.ChartAreas["ChartArea2"].AxisX.MajorGrid.Interval = 0.1;
                cmbChartAreaChoice.Items.Add(2);
            }
        }

        private void btnDeleteSecondChartArea_Click(object sender, EventArgs e)
        {
            if (dataChart.ChartAreas.Count == 2)
            {
                dataChart.ChartAreas.RemoveAt(1);
                cmbChartAreaChoice.Items.RemoveAt(1);

                UpdateGraphsComboBox();

                cmbChartAreaChoice.SelectedIndex = 0;
            }
        }

        private void btnDeleteChosenGraph_Click(object sender, EventArgs e)
        {
            if (cmbDeleteGraphChoise.Text != "")
            {
                bool format = true;
                string delGraphChartAreaName = dataChart.Series[cmbDeleteGraphChoise.Text].ChartArea;
                dataChart.Series.Remove(dataChart.Series[cmbDeleteGraphChoise.Text]);
                foreach (Series serie in dataChart.Series)
                {
                    if (serie.ChartArea == delGraphChartAreaName)
                    {
                        format = false;
                        break;
                    }
                }

                if (format)
                {
                    dataChart.ChartAreas[delGraphChartAreaName].AxisY.Maximum = Double.NaN;
                    dataChart.ChartAreas[delGraphChartAreaName].AxisY.Minimum = Double.NaN;
                }

                UpdateGraphsComboBox();
            }
        }

        private void UpdateGraphsComboBox()
        {
            cmbDeleteGraphChoise.Items.Clear();
            cmbDeleteGraphChoise.Text = "";
            if (dataChart.Series.Count != 0)
            {
                foreach (var serie in dataChart.Series)
                {
                    cmbDeleteGraphChoise.Items.Add(serie.Name);
                }
                cmbDeleteGraphChoise.SelectedIndex = 0;
            }
        }

        private void btnSaveBufferToTextFile_Click(object sender, EventArgs e)
        {
            if (buferU16.Count == 0)
            {
                MessageBox.Show("Буфер пуст!", "Ошибка");
            }
            else
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter streamWriter = new StreamWriter(saveFileDialog1.FileName);

                    for (int i = 0; i < buferU16.Count; i++)
                    {
                        streamWriter.WriteLine(buferU16[i]);
                    }
                    streamWriter.Close();
                }
            }
        }

        private void btnClearBuffer_Click(object sender, EventArgs e)
        {
            buferU16.Clear();
            pctrbxDataRecivingIndicator.BackColor = Color.Red;
            lblRecieve.Text = "Нет приема";
            lblCountOfValues.Text = "Значений в буфере: " + buferU16.Count;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.DataReceived -= OnDataReceived;
                    serialPort1.Dispose();
                    serialPort1.Close();
                    btnClosePort.Enabled = false;
                    btnOpenPort.Enabled = true;
                }
                catch (Exception exc)
                {

                }

            }
        }

        private void checkBoxSelectBufferData_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxSelectFileData.Checked = !checkBoxSelectBufferData.Checked;
            btnSaveBufferToTextFile.Enabled = true;
        }

        private void checkBoxSelectFileData_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxSelectBufferData.Checked = !checkBoxSelectFileData.Checked;
            btnSaveBufferToTextFile.Enabled = false;
        }

        private void OpenPort()
        {
            if (!serialPort1.IsOpen)
            {
                serialPort1.PortName = cmbPort.SelectedItem.ToString();
                serialPort1.DataReceived += new SerialDataReceivedEventHandler(OnDataReceived);
                serialPort1.Open();
                serialPort1.DiscardInBuffer();
                PictureBoxUpdater(pctrbxDataRecivingIndicator, Color.Red);
                lblRecieve.Text = "Нет приема";
                lblCountOfValues.Text = "Значений в буфере: " + buferU16.Count;
                btnOpenPort.Enabled = false;
                btnClosePort.Enabled = true;
            }
        }

        private void ClosePort()
        {
            if (serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.DiscardInBuffer();
                    serialPort1.BaseStream.Flush();
                    serialPort1.DataReceived -= OnDataReceived;
                    serialPort1.Close();
                    btnClosePort.Enabled = false;
                    btnOpenPort.Enabled = true;
                }
                catch (Exception exc)
                {
                }
            }
        }
    }
}


