using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

namespace superGraph
{
    delegate void LabelUpdaterDelegate(Label lbl, string lblText);            /////
    delegate void ProgressBarUpdaterDelegate(int progressPrcnt);              /////
    delegate void PictureBoxUpdaterDelegate(PictureBox pctrbox, Color color); /////


    public partial class Form1 : Form
    {
        List<UInt16> buferU16 = new List<UInt16>();               // БУФЕР UINT16
        List<byte> buferWithoutPreambula = new List<byte>();      // БУФЕР BYTE БЕЗ АМБУЛЫ И ПРЕАМБУЛЫ  
        List<byte> buferIncoming = new List<byte>();              // БУФЕР BYTE ВХОДНЫХ ДАННЫХ   

        List<double> currentGraphY = new List<double>();          // МАССИВ ТОЧЕК ПО ОСИ У ТЕКУЩЕГО ВЫВОДИМОГО ГРАФИКА

        List<double> filteredCurrentGraph = new List<double>();

        List<double> sinusoida = new List<double>();

        const int buferIncomingSize = 4000; //32008;                      // РАЗМЕР ВХОДНОГО БУФЕРА COM ПОРТА 

        ////////////

        List<double> yPoints = new List<double>();

        ////////////

        double yMax;
        double yMin;
        int seriesCount = 0;

        // НОРМИРОВАНИЕ ГРАФИКА

        const double amplVoltage = 2.50;
        const double maxADC = 4095;
        const double sampleRate = 800;  // Samples/s

        // НОРМИРОВАНИЕ ГРАФИКА

        public Form1()
        {
            InitializeComponent();
            ComboBoxes();
            cmbChartAreaChoice.Items.Add(1);
            cmbChartAreaChoice.SelectedIndex = 0;
            txtBoxGraphName.Text = "Без названия";
        }

        #region ОТКРЫТИЕ И ОТОБРАЖЕНИЕ ТЕКСТОВОГО ФАЙЛА НА ГРАФИКЕ

        private void btnLoadTextFile_Click(object sender, EventArgs e)
        {
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
                        currentGraphY.Clear();
                        dataChart.Series.Add(txtBoxGraphName.Text);
                        dataChart.Series[txtBoxGraphName.Text].ChartType = System.Windows.Forms.DataVisualization.
                                                                                             Charting.SeriesChartType.Line;
                        dataChart.Series[txtBoxGraphName.Text].Legend = "Legend1";
                        dataChart.Series[txtBoxGraphName.Text].LegendText = txtBoxGraphName.Text;
                        dataChart.Series[txtBoxGraphName.Text].ChartArea = "ChartArea" + cmbChartAreaChoice.Text;

                        GetSeries();

                        StreamReader streamReader = new StreamReader(openFileDialog1.FileName);

                        double x = 0.0;

                        while (!streamReader.EndOfStream)
                        {
                            double y = Convert.ToDouble(streamReader.ReadLine());
                            if (chkbxIsGraphNormalized.Checked)
                            {
                                y = (double)(y * amplVoltage / maxADC);
                            }
                            currentGraphY.Add(y);
                            dataChart.Series[txtBoxGraphName.Text].Points.AddXY(x, Math.Round(y, 4));
                            x += 1 / sampleRate;
                        }
                        streamReader.Close();
                        yMax = Math.Ceiling(currentGraphY.Max());
                        yMin = Math.Floor(currentGraphY.Min());
                        FormatGraph(yMax, yMin, 1 / sampleRate, "ChartArea" + cmbChartAreaChoice.Text);
                    }

                }
            }
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
                        currentGraphY.Clear();
                        dataChart.Series.Add(txtBoxGraphName.Text);
                        dataChart.Series[txtBoxGraphName.Text].ChartType = System.Windows.Forms.DataVisualization.
                                                                                             Charting.SeriesChartType.Line;
                        dataChart.Series[txtBoxGraphName.Text].Legend = "Legend1";
                        dataChart.Series[txtBoxGraphName.Text].LegendText = txtBoxGraphName.Text;
                        dataChart.Series[txtBoxGraphName.Text].ChartArea = "ChartArea" + cmbChartAreaChoice.Text;

                        GetSeries();

                        double x = 0.0;

                        for (int i = 0; i < buferU16.Count; i++)
                        {
                            double y = Convert.ToDouble(buferU16[i]);
                            //y = (double)(y * amplVoltage / maxADC);
                            currentGraphY.Add(y);
                            dataChart.Series[txtBoxGraphName.Text].Points.AddXY(x, Math.Round(y, 4));
                            x += 1 / sampleRate;
                        }
                        yMax = Math.Ceiling(currentGraphY.Max());
                        yMin = Math.Floor(currentGraphY.Min());
                        FormatGraph(yMax, yMin, 1 / sampleRate, "ChartArea" + cmbChartAreaChoice.Text);
                    }

                }
            }

        }

        #endregion

        #region ФОРМАТИРОВАНИЕ ГРАФИКА

        private void FormatGraph(double ymax, double ymin, double stepX, string chartAreaName)
        {

            dataChart.ChartAreas[chartAreaName].CursorX.IsUserSelectionEnabled = true;      // ВКЛЮЧИТЬ ВОЗМОЖНОСТЬ ВЫДЕЛЕНИЯ КУРСОРОМ ОБЛАСТИ ПО ОСИ Х
            dataChart.ChartAreas[chartAreaName].CursorX.Interval = stepX;                   // МИНИМАЛЬНЫЙ ИНТЕРВАЛ ЗУМА КУРСОРА ПО ОСИ X
            dataChart.ChartAreas[chartAreaName].AxisX.ScaleView.Zoomable = true;            // ВКЛЮЧИТЬ ВОЗМОЖНОСТЬ ЗУМА ПО ОСИ Х  
            dataChart.ChartAreas[chartAreaName].AxisX.ScrollBar.IsPositionedInside = true;  // ВКЛЮЧИТЬ ПАНЕЛЬ ПРОКРУТКИ по ОСИ Х
            dataChart.ChartAreas[chartAreaName].AxisX.ScaleView.SmallScrollSize = 0.2;      // ШАГ ПАНЕЛИ ПРОКРУТКИ ПО ОСИ Х

            if (ymax >= dataChart.ChartAreas[chartAreaName].AxisY.Maximum || double.IsNaN(dataChart.ChartAreas[chartAreaName].AxisY.Maximum))
            {
                dataChart.ChartAreas[chartAreaName].AxisY.Maximum = ymax;                   // МИНИМАЛЬНАЯ ГРАНИЦА ОТОБРАЖЕНИЯ ПО ОСИ Y
            }
            if (ymin <= dataChart.ChartAreas[chartAreaName].AxisY.Minimum || double.IsNaN(dataChart.ChartAreas[chartAreaName].AxisY.Minimum))
            {
                dataChart.ChartAreas[chartAreaName].AxisY.Minimum = ymin;                   // МАКСИМАЛЬНАЯ ГРАНИЦА ОТОБРАЖЕНИЯ ПО ОСИ Y
            }
            dataChart.ChartAreas[chartAreaName].CursorY.IsUserSelectionEnabled = true;      // ВКЛЮЧИТЬ ВОЗМОДНОСТЬ ВЫДЕЛЕНИЯ КУРСОРОМ ОБЛАСТИ по ОСИ Y
            dataChart.ChartAreas[chartAreaName].CursorY.Interval = 0.005;                   // МИНИМАЛЬНЫЙ ИНТЕРВАЛ ЗУМА КУРСОРА ПО ОСИ Y
            dataChart.ChartAreas[chartAreaName].AxisY.ScaleView.Zoomable = true;            // ВКЛЮЧИТЬ ВОЗМОЖНОСТЬ ЗУМА ПО ОСИ Y  
            dataChart.ChartAreas[chartAreaName].AxisY.ScrollBar.IsPositionedInside = true;  // ВКЛЮЧИТЬ ПАНЕЛЬ ПРОКРУТКИ по ОСИ Y
            dataChart.ChartAreas[chartAreaName].AxisY.ScaleView.SmallScrollSize = 0.005;    // ШАГ ПАНЕЛИ ПРОКРУТКИ ПО ОСИ Y
        }

        #endregion                

        #region ОТКРЫТИЕ ПОРТА

        private void btnOpenPort_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == false)
            {
                serialPort1.PortName = cmbPort.SelectedItem.ToString();
                serialPort1.DataReceived += new SerialDataReceivedEventHandler(OnDataReceived);
                serialPort1.Open();
                btnOpenPort.Enabled = false;
                btnClosePort.Enabled = true;
                serialPort1.DiscardInBuffer();
                buferU16.Clear();
                PictureBoxUpdater(pctrbxDataRecivingIndicator, Color.Red);
                lblRecieve.Text = "Нет приема";
                lblCountOfValues.Text = "Получено значений: " + buferU16.Count;
            }
        }

        #endregion

        #region ЗАКРЫТИЕ ПОРТА

        private void btnClosePort_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.DiscardInBuffer();
                    serialPort1.BaseStream.Flush();
                    //serialPort1.BaseStream.Close();
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

        #endregion

        #region ПРИЕМ ДАННЫХ ИЗ COM ПОРТА
        public void OnDataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (serialPort1.IsOpen && serialPort1.ReadBufferSize != 0)
            {
                UInt16 x;

                int tt = 0;

                int size = serialPort1.BytesToRead;

                buferIncoming.Clear();

                buferWithoutPreambula.Clear();

                LabelUpdater(lblRecieve, "Прием данных из COM порта");

                //pctrbxDataRecivingIndicator.BackColor = Color.Yellow;
                PictureBoxUpdater(pctrbxDataRecivingIndicator, Color.Yellow);

                try
                {
                    for (int i = 0; i < size; i++)
                    {
                        if (i == 4000)
                        {

                        }

                        buferIncoming.Add((byte)serialPort1.ReadByte());
                    }

                    for (int t = 0; t < buferIncoming.Count - 1; t += 2)
                    {
                        x = buferIncoming[t];
                        x = (UInt16)(x << 8);
                        x = (UInt16)(x | buferIncoming[t + 1]);
                        buferU16.Add(x);
                        tt++;
                    }

                    LabelUpdater(lblCountOfValues, "Получено значений: " + buferU16.Count);

                    LabelUpdater(lblRecieve, "Данные получены!");

                    PictureBoxUpdater(pctrbxDataRecivingIndicator, Color.Green);
                }
                catch (IOException exc)
                {
                    serialPort1.DataReceived -= OnDataReceived;
                }
                catch (Exception)
                {

                }

            }



            // serialPort1.DiscardInBuffer();




        }


        #endregion

        #region ОБНОВЛЕНИЕ НАДПИСИ ПРИЕМА ДАННЫХ
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

        #endregion

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

        #region ВЫБОР COM ПОРТА - ComboBoxes
        private void ComboBoxes()
        {

            string[] ports = SerialPort.GetPortNames();

            foreach (string port in ports)
            {
                cmbPort.Items.Add(port);
            }

            cmbPort.SelectedIndex = 0;
        }


        #endregion

        #region ОБНОВЛЕНИЕ СПИСКА COM ПОРТОВ
        private void btnRefreshPortsList_Click(object sender, EventArgs e)
        {

            cmbPort.Items.Clear();

            string[] ports = SerialPort.GetPortNames();

            foreach (string port in ports)
            {
                cmbPort.Items.Add(port);
            }
        }

        #endregion

        #region СОЗДАНИЕ ВТОРОЙ ОБЛАСТИ ПОСТРОЕНИЯ
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
                cmbChartAreaChoice.Items.Add(2);
            }
            else
            {
                MessageBox.Show("Нельзя создать больше 2-х областей построения графиков!", "Ошибка");
            }
        }

        #endregion

        #region УДАЛЕНИЕ ВТОРОЙ ОБЛАСТИ ПОСТРОЕНИЯ
        private void btnDeleteSecondChartArea_Click(object sender, EventArgs e)
        {

            if (dataChart.ChartAreas.Count == 2)
            {
                dataChart.ChartAreas.RemoveAt(1);
                cmbChartAreaChoice.Items.RemoveAt(1);

                GetSeries();

                cmbChartAreaChoice.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Нельзя удалить основную область построения!", "Ошибка");
            }
        }

        #endregion 

        #region УДАЛЕНИЕ ВЫБРАННОГО ГРАФИКА
        private void btnDeleteChosenGraph_Click(object sender, EventArgs e)
        {

            if (cmbDeleteGraphChoise.Text == "")
            {
                MessageBox.Show("График не выбран!", "Ошибка");
            }
            else
            {
                dataChart.Series.Remove(dataChart.Series[cmbDeleteGraphChoise.Text]);
                GetSeries();
            }
        }

        #endregion

        #region ОБНОВИТЬ СПИСОК ГРАФИКОВ
        private void GetSeries()
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

        #endregion

        #region ВЫВЕСТИ ПОЛУЧЕННЫЙ БУФЕР НА ГРАФИК
        private void btnShowBufferOnGraph_Click(object sender, EventArgs e)
        {

            if (buferU16.Count == 0)
            {
                MessageBox.Show("Буфер пуст!", "Ошибка");
            }
            else
            {
                currentGraphY.Clear();

                dataChart.Series.Add("Входной буфер");
                dataChart.Series["Входной буфер"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                dataChart.Series["Входной буфер"].Legend = "Legend1";
                dataChart.Series["Входной буфер"].LegendText = txtBoxGraphName.Text;
                dataChart.Series["Входной буфер"].ChartArea = "ChartArea1";

                GetSeries();


                double x = 0.0;

                for (int i = 0; i < buferU16.Count; i++)
                {
                    double y = Convert.ToDouble(buferU16[i]);
                    y = (double)(y * amplVoltage / maxADC);
                    currentGraphY.Add(y);
                    dataChart.Series["Входной буфер"].Points.AddXY(x, Math.Round(y, 4));
                    x += 1 / sampleRate;
                }
                yMax = Math.Ceiling(currentGraphY.Max());
                yMin = Math.Floor(currentGraphY.Min());
                FormatGraph(yMax, yMin, 1 / sampleRate, "ChartArea1");
            }
        }

        #endregion

        #region СОХРАНИТЬ ПОЛУЧЕННЫЙ БУФЕР В ТЕКСТОВЫЙ ФАЙЛ

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

        #endregion

        #region ОЧИСТИТЬ ВЫХОДНОЙ БУФЕР
        private void btnClearBuffer_Click(object sender, EventArgs e)
        {
            if (buferU16.Count == 0)
            {
                MessageBox.Show("Буфер пуст!", "Ошибка");
            }
            else
            {
                buferU16.Clear();
                pctrbxDataRecivingIndicator.BackColor = Color.Red;
                lblRecieve.Text = "Нет приема";
                lblCountOfValues.Text = "Получено значений: " + buferU16.Count;
            }
        }

        #endregion

        private void btnFilteringAndVisual_Click(object sender, EventArgs e)
        {
            if (dataChart.Series[0].Points.Count != 0)
            {
                dataChart.Series.Add("Filtered");
                dataChart.Series[seriesCount].ChartType = System.Windows.Forms.
                                                   DataVisualization.Charting.SeriesChartType.Line;

                double x = 0.0;

                yPoints.Clear();

                for (int i = 0; i < currentGraphY.Count - 8; i++)
                {
                    double z = (currentGraphY[i] + currentGraphY[i + 8]) / 2;
                    filteredCurrentGraph.Add(z);
                    yPoints.Add(z);
                    dataChart.Series[seriesCount].Points.AddXY(x, Math.Round(z, 4));
                    x += 1 / sampleRate;
                }

                seriesCount++;
                yMax = Math.Ceiling(yPoints.Max());
                yMin = Math.Floor(yPoints.Min());
                //GraphFormatting(yMax, yMin, 1 / sampleRate);
            }
            else
            {
                MessageBox.Show("Сначала выведите неотфильтрованный график!", "Ошибка");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter streamWriter = new StreamWriter(saveFileDialog1.FileName);
                for (double i = 0.0; i < 20; i += 0.00125)
                {
                    double yy = Math.Sin(2 * Math.PI * 40 * i) + Math.Sin(2 * Math.PI * 50 * i);
                    sinusoida.Add(yy);
                    streamWriter.WriteLine(yy);
                }
                streamWriter.Close();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                try
                {
                    //serialPort1.DiscardInBuffer();
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

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}


