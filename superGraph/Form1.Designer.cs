namespace superGraph
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnShowDataFrom = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.btnOpenPort = new System.Windows.Forms.Button();
            this.btnClosePort = new System.Windows.Forms.Button();
            this.cmbPorts = new System.Windows.Forms.ComboBox();
            this.btnCreateSecondChartArea = new System.Windows.Forms.Button();
            this.btnDeleteSecondChartArea = new System.Windows.Forms.Button();
            this.btnDeleteChosenGraph = new System.Windows.Forms.Button();
            this.lblRecieve = new System.Windows.Forms.Label();
            this.btnSaveBufferToTextFile = new System.Windows.Forms.Button();
            this.btnClearBuffer = new System.Windows.Forms.Button();
            this.lblCountOfValues = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxSelectBufferData = new System.Windows.Forms.CheckBox();
            this.checkBoxSelectFileData = new System.Windows.Forms.CheckBox();
            this.lblSampleTimeText = new System.Windows.Forms.Label();
            this.txtbxSampleTime = new System.Windows.Forms.TextBox();
            this.lstbxGraphs = new System.Windows.Forms.ListBox();
            this.lblGraphs = new System.Windows.Forms.Label();
            this.lblPorts = new System.Windows.Forms.Label();
            this.pctrbxDataRecivingIndicator = new System.Windows.Forms.PictureBox();
            this.btnRefreshPortsList = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrbxDataRecivingIndicator)).BeginInit();
            this.SuspendLayout();
            // 
            // dataChart
            // 
            chartArea1.AxisX.IsMarginVisible = false;
            chartArea1.AxisX.MajorGrid.Interval = 0D;
            chartArea1.AxisX.MajorTickMark.Interval = 0D;
            chartArea1.AxisX.MaximumAutoSize = 25F;
            chartArea1.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.BackSecondaryColor = System.Drawing.Color.White;
            chartArea1.CursorX.Interval = 0.00125D;
            chartArea1.InnerPlotPosition.Auto = false;
            chartArea1.InnerPlotPosition.Height = 90F;
            chartArea1.InnerPlotPosition.Width = 90F;
            chartArea1.InnerPlotPosition.X = 10F;
            chartArea1.IsSameFontSizeForAllAxes = true;
            chartArea1.Name = "ChartArea1";
            this.dataChart.ChartAreas.Add(chartArea1);
            this.dataChart.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            legend1.Name = "Legend1";
            this.dataChart.Legends.Add(legend1);
            this.dataChart.Location = new System.Drawing.Point(12, 12);
            this.dataChart.Name = "dataChart";
            this.dataChart.Size = new System.Drawing.Size(1309, 603);
            this.dataChart.TabIndex = 0;
            this.dataChart.Text = "dataChart";
            // 
            // btnShowDataFrom
            // 
            this.btnShowDataFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnShowDataFrom.Location = new System.Drawing.Point(10, 624);
            this.btnShowDataFrom.Name = "btnShowDataFrom";
            this.btnShowDataFrom.Size = new System.Drawing.Size(139, 38);
            this.btnShowDataFrom.TabIndex = 1;
            this.btnShowDataFrom.Text = "Отобразить данные на графике";
            this.btnShowDataFrom.UseVisualStyleBackColor = true;
            this.btnShowDataFrom.Click += new System.EventHandler(this.btnShowDataFrom_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Файл осциллограммы(*.eao)|*.eao";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Файл осциллограммы(*.eao)|*.eao";
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.PortName = "COM4";
            this.serialPort1.ReadBufferSize = 60000;
            // 
            // btnOpenPort
            // 
            this.btnOpenPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnOpenPort.Location = new System.Drawing.Point(1222, 624);
            this.btnOpenPort.Name = "btnOpenPort";
            this.btnOpenPort.Size = new System.Drawing.Size(99, 38);
            this.btnOpenPort.TabIndex = 12;
            this.btnOpenPort.Text = "Открыть порт";
            this.btnOpenPort.UseVisualStyleBackColor = true;
            this.btnOpenPort.Click += new System.EventHandler(this.btnOpenPort_Click);
            // 
            // btnClosePort
            // 
            this.btnClosePort.Enabled = false;
            this.btnClosePort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnClosePort.Location = new System.Drawing.Point(1222, 668);
            this.btnClosePort.Name = "btnClosePort";
            this.btnClosePort.Size = new System.Drawing.Size(99, 38);
            this.btnClosePort.TabIndex = 13;
            this.btnClosePort.Text = "Закрыть порт";
            this.btnClosePort.UseVisualStyleBackColor = true;
            this.btnClosePort.Click += new System.EventHandler(this.btnClosePort_Click);
            // 
            // cmbPorts
            // 
            this.cmbPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmbPorts.FormattingEnabled = true;
            this.cmbPorts.Location = new System.Drawing.Point(1066, 652);
            this.cmbPorts.Name = "cmbPorts";
            this.cmbPorts.Size = new System.Drawing.Size(122, 23);
            this.cmbPorts.TabIndex = 29;
            // 
            // btnCreateSecondChartArea
            // 
            this.btnCreateSecondChartArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCreateSecondChartArea.Location = new System.Drawing.Point(903, 624);
            this.btnCreateSecondChartArea.Name = "btnCreateSecondChartArea";
            this.btnCreateSecondChartArea.Size = new System.Drawing.Size(136, 40);
            this.btnCreateSecondChartArea.TabIndex = 31;
            this.btnCreateSecondChartArea.Text = "Добавить вторую область построения";
            this.btnCreateSecondChartArea.UseVisualStyleBackColor = true;
            this.btnCreateSecondChartArea.Click += new System.EventHandler(this.btnCreateSecondChartArea_Click);
            // 
            // btnDeleteSecondChartArea
            // 
            this.btnDeleteSecondChartArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDeleteSecondChartArea.Location = new System.Drawing.Point(903, 665);
            this.btnDeleteSecondChartArea.Name = "btnDeleteSecondChartArea";
            this.btnDeleteSecondChartArea.Size = new System.Drawing.Size(136, 41);
            this.btnDeleteSecondChartArea.TabIndex = 32;
            this.btnDeleteSecondChartArea.Text = "Удалить вторую область построения";
            this.btnDeleteSecondChartArea.UseVisualStyleBackColor = true;
            this.btnDeleteSecondChartArea.Click += new System.EventHandler(this.btnDeleteSecondChartArea_Click);
            // 
            // btnDeleteChosenGraph
            // 
            this.btnDeleteChosenGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDeleteChosenGraph.Location = new System.Drawing.Point(768, 666);
            this.btnDeleteChosenGraph.Name = "btnDeleteChosenGraph";
            this.btnDeleteChosenGraph.Size = new System.Drawing.Size(135, 40);
            this.btnDeleteChosenGraph.TabIndex = 40;
            this.btnDeleteChosenGraph.Text = "Удалить выбранный график";
            this.btnDeleteChosenGraph.UseVisualStyleBackColor = true;
            this.btnDeleteChosenGraph.Click += new System.EventHandler(this.btnDeleteChosenGraph_Click);
            // 
            // lblRecieve
            // 
            this.lblRecieve.AutoSize = true;
            this.lblRecieve.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblRecieve.Location = new System.Drawing.Point(309, 645);
            this.lblRecieve.Name = "lblRecieve";
            this.lblRecieve.Size = new System.Drawing.Size(77, 15);
            this.lblRecieve.TabIndex = 44;
            this.lblRecieve.Text = "Нет приема";
            // 
            // btnSaveBufferToTextFile
            // 
            this.btnSaveBufferToTextFile.Enabled = false;
            this.btnSaveBufferToTextFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSaveBufferToTextFile.Location = new System.Drawing.Point(10, 665);
            this.btnSaveBufferToTextFile.Name = "btnSaveBufferToTextFile";
            this.btnSaveBufferToTextFile.Size = new System.Drawing.Size(139, 41);
            this.btnSaveBufferToTextFile.TabIndex = 46;
            this.btnSaveBufferToTextFile.Text = "Сохранить буфер в текстовый файл";
            this.btnSaveBufferToTextFile.UseVisualStyleBackColor = true;
            this.btnSaveBufferToTextFile.Click += new System.EventHandler(this.btnSaveBufferToTextFile_Click);
            // 
            // btnClearBuffer
            // 
            this.btnClearBuffer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnClearBuffer.Location = new System.Drawing.Point(159, 670);
            this.btnClearBuffer.Name = "btnClearBuffer";
            this.btnClearBuffer.Size = new System.Drawing.Size(122, 36);
            this.btnClearBuffer.TabIndex = 47;
            this.btnClearBuffer.Text = "Очистить буфер";
            this.btnClearBuffer.UseVisualStyleBackColor = true;
            this.btnClearBuffer.Click += new System.EventHandler(this.btnClearBuffer_Click);
            // 
            // lblCountOfValues
            // 
            this.lblCountOfValues.AutoSize = true;
            this.lblCountOfValues.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblCountOfValues.Location = new System.Drawing.Point(287, 670);
            this.lblCountOfValues.Name = "lblCountOfValues";
            this.lblCountOfValues.Size = new System.Drawing.Size(126, 30);
            this.lblCountOfValues.TabIndex = 48;
            this.lblCountOfValues.Text = "Значений в буфере: \r\n0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 602);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 49;
            // 
            // checkBoxSelectBufferData
            // 
            this.checkBoxSelectBufferData.AutoSize = true;
            this.checkBoxSelectBufferData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxSelectBufferData.Location = new System.Drawing.Point(159, 643);
            this.checkBoxSelectBufferData.Name = "checkBoxSelectBufferData";
            this.checkBoxSelectBufferData.Size = new System.Drawing.Size(86, 19);
            this.checkBoxSelectBufferData.TabIndex = 50;
            this.checkBoxSelectBufferData.Text = "из буфера";
            this.checkBoxSelectBufferData.UseVisualStyleBackColor = true;
            this.checkBoxSelectBufferData.CheckedChanged += new System.EventHandler(this.checkBoxSelectBufferData_CheckedChanged);
            // 
            // checkBoxSelectFileData
            // 
            this.checkBoxSelectFileData.AutoSize = true;
            this.checkBoxSelectFileData.Checked = true;
            this.checkBoxSelectFileData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSelectFileData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.checkBoxSelectFileData.Location = new System.Drawing.Point(159, 624);
            this.checkBoxSelectFileData.Name = "checkBoxSelectFileData";
            this.checkBoxSelectFileData.Size = new System.Drawing.Size(81, 19);
            this.checkBoxSelectFileData.TabIndex = 51;
            this.checkBoxSelectFileData.Text = "из файла";
            this.checkBoxSelectFileData.UseVisualStyleBackColor = true;
            this.checkBoxSelectFileData.CheckedChanged += new System.EventHandler(this.checkBoxSelectFileData_CheckedChanged);
            // 
            // lblSampleTimeText
            // 
            this.lblSampleTimeText.AutoSize = true;
            this.lblSampleTimeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblSampleTimeText.Location = new System.Drawing.Point(427, 639);
            this.lblSampleTimeText.Name = "lblSampleTimeText";
            this.lblSampleTimeText.Size = new System.Drawing.Size(159, 30);
            this.lblSampleTimeText.TabIndex = 56;
            this.lblSampleTimeText.Text = "Интервал дискретизации \r\nзначений в буфере (мс):";
            // 
            // txtbxSampleTime
            // 
            this.txtbxSampleTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtbxSampleTime.Location = new System.Drawing.Point(430, 685);
            this.txtbxSampleTime.Name = "txtbxSampleTime";
            this.txtbxSampleTime.Size = new System.Drawing.Size(108, 21);
            this.txtbxSampleTime.TabIndex = 57;
            this.txtbxSampleTime.Text = "1,25";
            this.txtbxSampleTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbxSampleTime_KeyPress);
            this.txtbxSampleTime.Validating += new System.ComponentModel.CancelEventHandler(this.txtbxSampleTime_Validating);
            // 
            // lstbxGraphs
            // 
            this.lstbxGraphs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lstbxGraphs.FormattingEnabled = true;
            this.lstbxGraphs.ItemHeight = 15;
            this.lstbxGraphs.Location = new System.Drawing.Point(611, 642);
            this.lstbxGraphs.Name = "lstbxGraphs";
            this.lstbxGraphs.Size = new System.Drawing.Size(151, 64);
            this.lstbxGraphs.TabIndex = 58;
            // 
            // lblGraphs
            // 
            this.lblGraphs.AutoSize = true;
            this.lblGraphs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblGraphs.Location = new System.Drawing.Point(608, 624);
            this.lblGraphs.Name = "lblGraphs";
            this.lblGraphs.Size = new System.Drawing.Size(114, 15);
            this.lblGraphs.TabIndex = 59;
            this.lblGraphs.Text = "Список графиков :";
            // 
            // lblPorts
            // 
            this.lblPorts.AutoSize = true;
            this.lblPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblPorts.Location = new System.Drawing.Point(1089, 628);
            this.lblPorts.Name = "lblPorts";
            this.lblPorts.Size = new System.Drawing.Size(99, 15);
            this.lblPorts.TabIndex = 60;
            this.lblPorts.Text = "Список портов :";
            // 
            // pctrbxDataRecivingIndicator
            // 
            this.pctrbxDataRecivingIndicator.BackColor = System.Drawing.Color.Red;
            this.pctrbxDataRecivingIndicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctrbxDataRecivingIndicator.Location = new System.Drawing.Point(291, 648);
            this.pctrbxDataRecivingIndicator.Name = "pctrbxDataRecivingIndicator";
            this.pctrbxDataRecivingIndicator.Size = new System.Drawing.Size(12, 12);
            this.pctrbxDataRecivingIndicator.TabIndex = 45;
            this.pctrbxDataRecivingIndicator.TabStop = false;
            // 
            // btnRefreshPortsList
            // 
            this.btnRefreshPortsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnRefreshPortsList.Image = global::superGraph.Properties.Resources.reload_refresh;
            this.btnRefreshPortsList.Location = new System.Drawing.Point(1066, 624);
            this.btnRefreshPortsList.Name = "btnRefreshPortsList";
            this.btnRefreshPortsList.Size = new System.Drawing.Size(22, 22);
            this.btnRefreshPortsList.TabIndex = 30;
            this.btnRefreshPortsList.UseVisualStyleBackColor = true;
            this.btnRefreshPortsList.Click += new System.EventHandler(this.btnRefreshPortsList_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 729);
            this.Controls.Add(this.lblPorts);
            this.Controls.Add(this.lblGraphs);
            this.Controls.Add(this.lstbxGraphs);
            this.Controls.Add(this.txtbxSampleTime);
            this.Controls.Add(this.lblSampleTimeText);
            this.Controls.Add(this.checkBoxSelectFileData);
            this.Controls.Add(this.checkBoxSelectBufferData);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCountOfValues);
            this.Controls.Add(this.btnClearBuffer);
            this.Controls.Add(this.btnSaveBufferToTextFile);
            this.Controls.Add(this.pctrbxDataRecivingIndicator);
            this.Controls.Add(this.lblRecieve);
            this.Controls.Add(this.btnDeleteChosenGraph);
            this.Controls.Add(this.btnDeleteSecondChartArea);
            this.Controls.Add(this.btnCreateSecondChartArea);
            this.Controls.Add(this.btnRefreshPortsList);
            this.Controls.Add(this.cmbPorts);
            this.Controls.Add(this.btnClosePort);
            this.Controls.Add(this.btnOpenPort);
            this.Controls.Add(this.btnShowDataFrom);
            this.Controls.Add(this.dataChart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(2000, 2000);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super Graph";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrbxDataRecivingIndicator)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart dataChart;
        private System.Windows.Forms.Button btnShowDataFrom;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button btnOpenPort;
        private System.Windows.Forms.Button btnClosePort;
        private System.Windows.Forms.ComboBox cmbPorts;
        private System.Windows.Forms.Button btnRefreshPortsList;
        private System.Windows.Forms.Button btnCreateSecondChartArea;
        private System.Windows.Forms.Button btnDeleteSecondChartArea;
        private System.Windows.Forms.Button btnDeleteChosenGraph;
        private System.Windows.Forms.Label lblRecieve;
        private System.Windows.Forms.PictureBox pctrbxDataRecivingIndicator;
        private System.Windows.Forms.Button btnSaveBufferToTextFile;
        private System.Windows.Forms.Button btnClearBuffer;
        private System.Windows.Forms.Label lblCountOfValues;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxSelectBufferData;
        private System.Windows.Forms.CheckBox checkBoxSelectFileData;
        private System.Windows.Forms.Label lblSampleTimeText;
        private System.Windows.Forms.TextBox txtbxSampleTime;
        private System.Windows.Forms.ListBox lstbxGraphs;
        private System.Windows.Forms.Label lblGraphs;
        private System.Windows.Forms.Label lblPorts;
    }
}

