using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using System.Text.RegularExpressions;

namespace superGraph
{    
    delegate void UpdaterDelegate<A, B>(A controlType, B valueType);

    public partial class Form1 : Form
    {
        public string GraphName { get; set; }
        public string ChartArea { get; set; }

        List<Graph> Graphs = new List<Graph>();

        // буфер UInt16
        List<ushort> buferU16 = new List<ushort>();

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

        //
        double sampleTime = 1.25;

        bool enter = false;

        ////////////////////////////////////////////////////

        public Form1()
        {
            InitializeComponent();
            UpdatePortComboBox();
            InitializeChartArea("ChartArea1");
        }

        private Graph CreateNewGraph(string name, string chartArea)
        {
            return new Graph(name, chartArea);
        }

        private Graph CreateNewGraph(string name, string chartArea, double sampleTime)
        {
            return new Graph(name, chartArea, sampleTime);
        }

        private void WriteToGraph(Graph graph, double value)
        {
            graph.Samples.Add(value);
        }

        private void AddGraphToSeriesAndGraphsAndShow(Graph graph, List<Graph> graphs)
        {
            dataChart.Series.Add(graph.Name);
            dataChart.Series[graph.Name].ChartType = SeriesChartType.Line;
            dataChart.Series[graph.Name].Legend = "Legend1";
            dataChart.Series[graph.Name].LegendText = graph.Name;
            dataChart.Series[graph.Name].ChartArea = graph.ChartArea;

            double x = 0.0;

            for (int i = 0; i < graph.Samples.Count; i++)
            {
                dataChart.Series[graph.Name].Points.AddXY(Math.Round(x, 5), graph.Samples[i]);
                x += graph.SampleTime;
            }

            graphs.Add(graph);

            lstbxGraphs.Items.Add(graph.Name);
        }

        private void RemoveGraphFromSeriesAndGraphs(string deletedGraphName, List<Graph> graphs)
        {
            dataChart.Series.Remove(dataChart.Series[deletedGraphName]);

            foreach (Graph graph in graphs)
            {
                if (graph.Name == deletedGraphName)
                {
                    Graphs.Remove(graph);
                    break;
                }
            }

            lstbxGraphs.Items.Remove(deletedGraphName);
        }

        private void CreateChartArea(string chartAreaName)
        {
            dataChart.ChartAreas.Add(chartAreaName);
            dataChart.ChartAreas[chartAreaName].AxisX.IsMarginVisible = false;
            dataChart.ChartAreas[chartAreaName].AxisX.MajorTickMark.Interval = 0.5D;
            dataChart.ChartAreas[chartAreaName].AxisX.MaximumAutoSize = 25F;
            dataChart.ChartAreas[chartAreaName].CursorX.Interval = 0.00125D;
            dataChart.ChartAreas[chartAreaName].InnerPlotPosition.Auto = false;
            dataChart.ChartAreas[chartAreaName].InnerPlotPosition.Height = 90F;
            dataChart.ChartAreas[chartAreaName].InnerPlotPosition.Width = 90F;
            dataChart.ChartAreas[chartAreaName].InnerPlotPosition.X = 10F;
            dataChart.ChartAreas[chartAreaName].IsSameFontSizeForAllAxes = true;
            dataChart.ChartAreas[chartAreaName].BackColor = Color.WhiteSmoke;
            dataChart.ChartAreas[chartAreaName].AxisX.MajorGrid.Interval = 0.1;

            InitializeChartArea(chartAreaName);
        }

        private void InitializeChartArea(string chartAreaName)
        {
            // включить возможность выделения курсором области по оси X
            dataChart.ChartAreas[chartAreaName].CursorX.IsUserSelectionEnabled = true;

            // минимальный интервал зума курсора по оси X      
            //dataChart.ChartAreas[graph.ChartArea].CursorX.Interval = graph.SampleTime;

            // включить возможность зума по оси X                      
            dataChart.ChartAreas[chartAreaName].AxisX.ScaleView.Zoomable = true;
            // включить панель прокрутки по оси X            
            dataChart.ChartAreas[chartAreaName].AxisX.ScrollBar.IsPositionedInside = true;
            // шаг панели прокрутки по оси X   
            dataChart.ChartAreas[chartAreaName].AxisX.ScaleView.SmallScrollSize = 0.2;

            // аналогично с осью Y
            dataChart.ChartAreas[chartAreaName].CursorY.IsUserSelectionEnabled = true;
            dataChart.ChartAreas[chartAreaName].CursorY.Interval = 0.005;
            dataChart.ChartAreas[chartAreaName].AxisY.ScaleView.Zoomable = true;
            dataChart.ChartAreas[chartAreaName].AxisY.ScrollBar.IsPositionedInside = true;
            dataChart.ChartAreas[chartAreaName].AxisY.ScaleView.SmallScrollSize = 0.005;
        }

        private void FormatChartAreaBasedOnGraph(Graph graph)
        {
            DataPoint a = dataChart.Series[graph.Name].Points.FindMaxByValue("Y1");
            yMax = (double)a.YValues.GetValue(0);
            a = dataChart.Series[graph.Name].Points.FindMinByValue("Y1");
            yMin = (double)a.YValues.GetValue(0);

            if (yMax >= dataChart.ChartAreas[graph.ChartArea].AxisY.Maximum ||
                                  double.IsNaN(dataChart.ChartAreas[graph.ChartArea].AxisY.Maximum))
            {
                // нижняя граница отображения по оси Y 
                dataChart.ChartAreas[graph.ChartArea].AxisY.Maximum = yMax;
            }
            if (yMin <= dataChart.ChartAreas[graph.ChartArea].AxisY.Minimum ||
                                  double.IsNaN(dataChart.ChartAreas[graph.ChartArea].AxisY.Minimum))
            {
                // верхняя граница отображения по оси Y 
                dataChart.ChartAreas[graph.ChartArea].AxisY.Minimum = yMin;
            }
        }

        private void FormatChartArea(string chartArea)
        {
            if (dataChart.ChartAreas[chartArea] != null)
            {
                foreach (Graph graph in Graphs)
                {
                    if (graph.ChartArea == chartArea)
                    {
                        FormatChartAreaBasedOnGraph(graph);
                    }
                }
            }
        }

        private void ResetChartAreaMaxMin(string chartArea)
        {
            dataChart.ChartAreas[chartArea].AxisY.Maximum = double.NaN;
            dataChart.ChartAreas[chartArea].AxisY.Minimum = double.NaN;
        }

        private void RemoveChartArea(string chartAreaName)
        {
            dataChart.ChartAreas.Remove(dataChart.ChartAreas[chartAreaName]);
        }

        private void LabelUpdater(Label label, string labelText)
        {
            if (label.InvokeRequired)
            {
                UpdaterDelegate<Label, string> d = new UpdaterDelegate<Label, string>(LabelUpdater);
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
                UpdaterDelegate<PictureBox, Color> d = new UpdaterDelegate<PictureBox, Color>(PictureBoxUpdater);
                this.Invoke(d, new object[] { pctrbox, color });
            }
            else
            {
                pctrbox.BackColor = color;
            }
        }

        private void UpdatePortComboBox()
        {
            cmbPorts.Items.Clear();

            string[] ports = SerialPort.GetPortNames();

            foreach (string port in ports)
            {
                cmbPorts.Items.Add(port);
            }

            if (ports.Length != 0)
            {
                cmbPorts.SelectedIndex = 0;
            }
        }

        private void OpenPort()
        {
            if (cmbPorts.SelectedItem != null)
            {
                serialPort1.PortName = cmbPorts.SelectedItem.ToString();
                serialPort1.DataReceived += new SerialDataReceivedEventHandler(OnDataReceived);
                serialPort1.Open();
                serialPort1.DiscardInBuffer();
                PictureBoxUpdater(pctrbxDataRecivingIndicator, Color.Red);
                lblRecieve.Text = "Нет приема";
                lblCountOfValues.Text = "Значений в буфере:\n" + buferU16.Count;
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

        private void KeysValidator(TextBox textbox, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 44 || e.KeyChar == 8 || e.KeyChar == 127)
            {
                e.Handled = false;
            }
            else if (e.KeyChar == 13)
            {
                enter = true;
                AcceptTextBoxValue(textbox);
                e.Handled = true;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void AcceptTextBoxValue(TextBox textbox)
        {
            lblSampleTimeText.Focus();
            double result;
            bool isParsed = Double.TryParse(textbox.Text, out result);
            sampleTime = result;
        }

        public void OnDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (serialPort1.IsOpen && serialPort1.ReadBufferSize != 0)
            {
                ushort x;

                int bufferSize = serialPort1.BytesToRead;

                buferIncoming.Clear();

                LabelUpdater(lblRecieve, "Прием данных из COM порта");

                PictureBoxUpdater(pctrbxDataRecivingIndicator, Color.Yellow);

                try
                {
                    for (int i = 0; i < bufferSize; i++)
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

                    LabelUpdater(lblCountOfValues, "Значений в буфере:\n" + buferU16.Count);

                    LabelUpdater(lblRecieve, "Данные получены!");

                    PictureBoxUpdater(pctrbxDataRecivingIndicator, Color.Green);
                }
                catch (IOException exc)
                {
                    serialPort1.DataReceived -= OnDataReceived;
                }
            }
        }



        /////////// Обработчики ///////////

        private void btnShowDataFrom_Click(object sender, EventArgs e)
        {
            // вывод из файла
            if (checkBoxSelectFileData.Checked)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Form2 f = new Form2(dataChart.ChartAreas.Count, dataChart.Series.Count, this);

                    f.ShowDialog();

                    Graph currentGraph = CreateNewGraph(GraphName, ChartArea);

                    StreamReader streamReader = new StreamReader(openFileDialog1.FileName);

                    double res = 1;

                    while (!streamReader.EndOfStream)
                    {
                        string currentString = streamReader.ReadLine();

                        if (currentString.Contains("Sample time"))
                        {
                            currentString = Regex.Replace(currentString, "[^0-9.,]", "");
                            currentGraph.SampleTime = Convert.ToDouble(currentString);
                        }
                        else if (Double.TryParse(currentString, out res))
                        {
                            double y = Convert.ToDouble(currentString);
                            WriteToGraph(currentGraph, Math.Round(y, 4));
                        }
                    }
                    streamReader.Close();

                    AddGraphToSeriesAndGraphsAndShow(currentGraph, Graphs);

                    ResetChartAreaMaxMin(currentGraph.ChartArea);

                    FormatChartArea(currentGraph.ChartArea);
                }
            }
            // вывод из буфера
            else if (checkBoxSelectBufferData.Checked)
            {
                Form2 f = new Form2(dataChart.ChartAreas.Count, dataChart.Series.Count, this);

                f.ShowDialog();

                Graph currentGraph = CreateNewGraph(GraphName, ChartArea, sampleTime);

                for (int i = 0; i < buferU16.Count; i++)
                {
                    double y = Convert.ToDouble(buferU16[i]);
                    WriteToGraph(currentGraph, Math.Round(y, 4));
                }

                AddGraphToSeriesAndGraphsAndShow(currentGraph, Graphs);

                ResetChartAreaMaxMin(currentGraph.ChartArea);

                FormatChartArea(currentGraph.ChartArea);
            }
        }

        private void btnOpenPort_Click(object sender, EventArgs e)
        {
            OpenPort();
        }

        private void btnClosePort_Click(object sender, EventArgs e)
        {
            ClosePort();
        }

        private void btnRefreshPortsList_Click(object sender, EventArgs e)
        {
            UpdatePortComboBox();
        }

        private void btnCreateSecondChartArea_Click(object sender, EventArgs e)
        {
            if (dataChart.ChartAreas.Count < 2)
            {
                CreateChartArea("ChartArea2");
            }
        }

        private void btnDeleteSecondChartArea_Click(object sender, EventArgs e)
        {
            if (dataChart.ChartAreas.Count == 2)
            {
                List<string> namesOfGraphs = new List<string>();

                foreach (Series series in dataChart.Series)
                {
                    if (series.ChartArea == dataChart.ChartAreas[1].Name)
                    {
                        namesOfGraphs.Add(series.Name);
                    }
                }

                for (int i = namesOfGraphs.Count - 1; i >= 0; i--)
                {
                    RemoveGraphFromSeriesAndGraphs(namesOfGraphs[i], Graphs);
                }

                RemoveChartArea(dataChart.ChartAreas[1].Name);

            }
        }

        private void btnDeleteChosenGraph_Click(object sender, EventArgs e)
        {
            if (lstbxGraphs.SelectedItem != null)
            {
                string deletedGraphName = lstbxGraphs.SelectedItem.ToString();

                string deletedGraphChartAreaName = dataChart.Series[deletedGraphName].ChartArea;

                RemoveGraphFromSeriesAndGraphs(deletedGraphName, Graphs);

                FormatChartArea(deletedGraphChartAreaName);
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

                    streamWriter.WriteLine("Date : " + DateTime.Now);

                    streamWriter.WriteLine("Sample time : " + sampleTime + " мс");

                    streamWriter.WriteLine();

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
            lblCountOfValues.Text = "Значений в буфере:\n" + buferU16.Count;
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
            btnSaveBufferToTextFile.Enabled = checkBoxSelectBufferData.Checked;
        }

        private void checkBoxSelectFileData_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxSelectBufferData.Checked = !checkBoxSelectFileData.Checked;
            btnSaveBufferToTextFile.Enabled = checkBoxSelectBufferData.Checked;
        }

        private void txtbxSampleTime_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AcceptTextBoxValue(txtbxSampleTime);
        }

        private void txtbxSampleTime_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

       
    }
}


