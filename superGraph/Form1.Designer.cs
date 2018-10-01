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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea14 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend14 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.dataChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnShowDataFrom = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.btnOpenPort = new System.Windows.Forms.Button();
            this.btnClosePort = new System.Windows.Forms.Button();
            this.cmbPort = new System.Windows.Forms.ComboBox();
            this.btnRefreshPortsList = new System.Windows.Forms.Button();
            this.btnCreateSecondChartArea = new System.Windows.Forms.Button();
            this.btnDeleteSecondChartArea = new System.Windows.Forms.Button();
            this.cmbChartAreaChoice = new System.Windows.Forms.ComboBox();
            this.labelChartAreaChoise = new System.Windows.Forms.Label();
            this.txtBoxGraphName = new System.Windows.Forms.TextBox();
            this.chkbxIsGraphNormalized = new System.Windows.Forms.CheckBox();
            this.btnDeleteChosenGraph = new System.Windows.Forms.Button();
            this.cmbDeleteGraphChoise = new System.Windows.Forms.ComboBox();
            this.lblRecieve = new System.Windows.Forms.Label();
            this.pctrbxDataRecivingIndicator = new System.Windows.Forms.PictureBox();
            this.btnSaveBufferToTextFile = new System.Windows.Forms.Button();
            this.btnClearBuffer = new System.Windows.Forms.Button();
            this.lblCountOfValues = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxSelectBufferData = new System.Windows.Forms.CheckBox();
            this.checkBoxSelectFileData = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrbxDataRecivingIndicator)).BeginInit();
            this.SuspendLayout();
            // 
            // dataChart
            // 
            chartArea14.AxisX.IsMarginVisible = false;
            chartArea14.AxisX.MajorTickMark.Interval = 0.5D;
            chartArea14.AxisX.MaximumAutoSize = 25F;
            chartArea14.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea14.BackSecondaryColor = System.Drawing.Color.White;
            chartArea14.CursorX.Interval = 0.00125D;
            chartArea14.InnerPlotPosition.Auto = false;
            chartArea14.InnerPlotPosition.Height = 90F;
            chartArea14.InnerPlotPosition.Width = 90F;
            chartArea14.InnerPlotPosition.X = 10F;
            chartArea14.IsSameFontSizeForAllAxes = true;
            chartArea14.Name = "ChartArea1";
            this.dataChart.ChartAreas.Add(chartArea14);
            this.dataChart.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            legend14.Name = "Legend1";
            this.dataChart.Legends.Add(legend14);
            this.dataChart.Location = new System.Drawing.Point(12, 12);
            this.dataChart.Name = "dataChart";
            this.dataChart.Size = new System.Drawing.Size(1374, 687);
            this.dataChart.TabIndex = 0;
            this.dataChart.Text = "dataChart";
            // 
            // btnShowDataFrom
            // 
            this.btnShowDataFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnShowDataFrom.Location = new System.Drawing.Point(29, 730);
            this.btnShowDataFrom.Name = "btnShowDataFrom";
            this.btnShowDataFrom.Size = new System.Drawing.Size(176, 80);
            this.btnShowDataFrom.TabIndex = 1;
            this.btnShowDataFrom.Text = "Отобразить данные на графике";
            this.btnShowDataFrom.UseVisualStyleBackColor = true;
            this.btnShowDataFrom.Click += new System.EventHandler(this.btnShowDataFrom_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Text file(*.txt)|*.txt";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Text file(*.txt)|*.txt";
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.PortName = "COM4";
            this.serialPort1.ReadBufferSize = 60000;
            // 
            // btnOpenPort
            // 
            this.btnOpenPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOpenPort.Location = new System.Drawing.Point(1033, 757);
            this.btnOpenPort.Name = "btnOpenPort";
            this.btnOpenPort.Size = new System.Drawing.Size(158, 54);
            this.btnOpenPort.TabIndex = 12;
            this.btnOpenPort.Text = "Открыть порт";
            this.btnOpenPort.UseVisualStyleBackColor = true;
            this.btnOpenPort.Click += new System.EventHandler(this.btnOpenPort_Click);
            // 
            // btnClosePort
            // 
            this.btnClosePort.Enabled = false;
            this.btnClosePort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClosePort.Location = new System.Drawing.Point(1033, 829);
            this.btnClosePort.Name = "btnClosePort";
            this.btnClosePort.Size = new System.Drawing.Size(158, 56);
            this.btnClosePort.TabIndex = 13;
            this.btnClosePort.Text = "Закрыть порт";
            this.btnClosePort.UseVisualStyleBackColor = true;
            this.btnClosePort.Click += new System.EventHandler(this.btnClosePort_Click);
            // 
            // cmbPort
            // 
            this.cmbPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbPort.FormattingEnabled = true;
            this.cmbPort.Location = new System.Drawing.Point(847, 769);
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(158, 24);
            this.cmbPort.TabIndex = 29;
            // 
            // btnRefreshPortsList
            // 
            this.btnRefreshPortsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRefreshPortsList.Location = new System.Drawing.Point(847, 810);
            this.btnRefreshPortsList.Name = "btnRefreshPortsList";
            this.btnRefreshPortsList.Size = new System.Drawing.Size(158, 75);
            this.btnRefreshPortsList.TabIndex = 30;
            this.btnRefreshPortsList.Text = "Обновить список доступных портов";
            this.btnRefreshPortsList.UseVisualStyleBackColor = true;
            this.btnRefreshPortsList.Click += new System.EventHandler(this.btnRefreshPortsList_Click);
            // 
            // btnCreateSecondChartArea
            // 
            this.btnCreateSecondChartArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCreateSecondChartArea.Location = new System.Drawing.Point(1401, 26);
            this.btnCreateSecondChartArea.Name = "btnCreateSecondChartArea";
            this.btnCreateSecondChartArea.Size = new System.Drawing.Size(158, 74);
            this.btnCreateSecondChartArea.TabIndex = 31;
            this.btnCreateSecondChartArea.Text = "Добавить вторую область построения";
            this.btnCreateSecondChartArea.UseVisualStyleBackColor = true;
            this.btnCreateSecondChartArea.Click += new System.EventHandler(this.btnCreateSecondChartArea_Click);
            // 
            // btnDeleteSecondChartArea
            // 
            this.btnDeleteSecondChartArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDeleteSecondChartArea.Location = new System.Drawing.Point(1401, 116);
            this.btnDeleteSecondChartArea.Name = "btnDeleteSecondChartArea";
            this.btnDeleteSecondChartArea.Size = new System.Drawing.Size(158, 74);
            this.btnDeleteSecondChartArea.TabIndex = 32;
            this.btnDeleteSecondChartArea.Text = "Удалить вторую область построения";
            this.btnDeleteSecondChartArea.UseVisualStyleBackColor = true;
            this.btnDeleteSecondChartArea.Click += new System.EventHandler(this.btnDeleteSecondChartArea_Click);
            // 
            // cmbChartAreaChoice
            // 
            this.cmbChartAreaChoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbChartAreaChoice.FormattingEnabled = true;
            this.cmbChartAreaChoice.Location = new System.Drawing.Point(361, 802);
            this.cmbChartAreaChoice.Name = "cmbChartAreaChoice";
            this.cmbChartAreaChoice.Size = new System.Drawing.Size(121, 24);
            this.cmbChartAreaChoice.TabIndex = 33;
            this.cmbChartAreaChoice.Text = "1";
            // 
            // labelChartAreaChoise
            // 
            this.labelChartAreaChoise.AutoSize = true;
            this.labelChartAreaChoise.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelChartAreaChoise.Location = new System.Drawing.Point(361, 738);
            this.labelChartAreaChoise.Name = "labelChartAreaChoise";
            this.labelChartAreaChoise.Size = new System.Drawing.Size(328, 40);
            this.labelChartAreaChoise.TabIndex = 36;
            this.labelChartAreaChoise.Text = "Выберите область построения \r\nи введите уникальное название графика:";
            // 
            // txtBoxGraphName
            // 
            this.txtBoxGraphName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtBoxGraphName.Location = new System.Drawing.Point(498, 802);
            this.txtBoxGraphName.Name = "txtBoxGraphName";
            this.txtBoxGraphName.Size = new System.Drawing.Size(166, 26);
            this.txtBoxGraphName.TabIndex = 38;
            // 
            // chkbxIsGraphNormalized
            // 
            this.chkbxIsGraphNormalized.AutoSize = true;
            this.chkbxIsGraphNormalized.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chkbxIsGraphNormalized.Location = new System.Drawing.Point(365, 852);
            this.chkbxIsGraphNormalized.Name = "chkbxIsGraphNormalized";
            this.chkbxIsGraphNormalized.Size = new System.Drawing.Size(286, 44);
            this.chkbxIsGraphNormalized.TabIndex = 39;
            this.chkbxIsGraphNormalized.Text = "Нормировать выводимый график\r\nотносительно 3.3 В ";
            this.chkbxIsGraphNormalized.UseVisualStyleBackColor = true;
            this.chkbxIsGraphNormalized.CheckedChanged += new System.EventHandler(this.chkbxIsGraphNormalized_CheckedChanged);
            // 
            // btnDeleteChosenGraph
            // 
            this.btnDeleteChosenGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDeleteChosenGraph.Location = new System.Drawing.Point(1401, 205);
            this.btnDeleteChosenGraph.Name = "btnDeleteChosenGraph";
            this.btnDeleteChosenGraph.Size = new System.Drawing.Size(158, 74);
            this.btnDeleteChosenGraph.TabIndex = 40;
            this.btnDeleteChosenGraph.Text = "Удалить выбранный график";
            this.btnDeleteChosenGraph.UseVisualStyleBackColor = true;
            this.btnDeleteChosenGraph.Click += new System.EventHandler(this.btnDeleteChosenGraph_Click);
            // 
            // cmbDeleteGraphChoise
            // 
            this.cmbDeleteGraphChoise.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbDeleteGraphChoise.FormattingEnabled = true;
            this.cmbDeleteGraphChoise.Location = new System.Drawing.Point(1401, 296);
            this.cmbDeleteGraphChoise.Name = "cmbDeleteGraphChoise";
            this.cmbDeleteGraphChoise.Size = new System.Drawing.Size(158, 24);
            this.cmbDeleteGraphChoise.TabIndex = 41;
            // 
            // lblRecieve
            // 
            this.lblRecieve.AutoSize = true;
            this.lblRecieve.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRecieve.Location = new System.Drawing.Point(1251, 761);
            this.lblRecieve.Name = "lblRecieve";
            this.lblRecieve.Size = new System.Drawing.Size(89, 18);
            this.lblRecieve.TabIndex = 44;
            this.lblRecieve.Text = "Нет приема";
            // 
            // pctrbxDataRecivingIndicator
            // 
            this.pctrbxDataRecivingIndicator.BackColor = System.Drawing.Color.Red;
            this.pctrbxDataRecivingIndicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctrbxDataRecivingIndicator.Location = new System.Drawing.Point(1227, 761);
            this.pctrbxDataRecivingIndicator.Name = "pctrbxDataRecivingIndicator";
            this.pctrbxDataRecivingIndicator.Size = new System.Drawing.Size(18, 18);
            this.pctrbxDataRecivingIndicator.TabIndex = 45;
            this.pctrbxDataRecivingIndicator.TabStop = false;
            // 
            // btnSaveBufferToTextFile
            // 
            this.btnSaveBufferToTextFile.Enabled = false;
            this.btnSaveBufferToTextFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSaveBufferToTextFile.Location = new System.Drawing.Point(30, 829);
            this.btnSaveBufferToTextFile.Name = "btnSaveBufferToTextFile";
            this.btnSaveBufferToTextFile.Size = new System.Drawing.Size(175, 78);
            this.btnSaveBufferToTextFile.TabIndex = 46;
            this.btnSaveBufferToTextFile.Text = "Сохранить буфер в текстовый файл";
            this.btnSaveBufferToTextFile.UseVisualStyleBackColor = true;
            this.btnSaveBufferToTextFile.Click += new System.EventHandler(this.btnSaveBufferToTextFile_Click);
            // 
            // btnClearBuffer
            // 
            this.btnClearBuffer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClearBuffer.Location = new System.Drawing.Point(1222, 840);
            this.btnClearBuffer.Name = "btnClearBuffer";
            this.btnClearBuffer.Size = new System.Drawing.Size(158, 41);
            this.btnClearBuffer.TabIndex = 47;
            this.btnClearBuffer.Text = "Очистить буфер";
            this.btnClearBuffer.UseVisualStyleBackColor = true;
            this.btnClearBuffer.Click += new System.EventHandler(this.btnClearBuffer_Click);
            // 
            // lblCountOfValues
            // 
            this.lblCountOfValues.AutoSize = true;
            this.lblCountOfValues.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCountOfValues.Location = new System.Drawing.Point(1222, 802);
            this.lblCountOfValues.Name = "lblCountOfValues";
            this.lblCountOfValues.Size = new System.Drawing.Size(159, 18);
            this.lblCountOfValues.TabIndex = 48;
            this.lblCountOfValues.Text = "Значений в буфере: 0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 718);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 49;
            // 
            // checkBoxSelectBufferData
            // 
            this.checkBoxSelectBufferData.AutoSize = true;
            this.checkBoxSelectBufferData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxSelectBufferData.Location = new System.Drawing.Point(225, 738);
            this.checkBoxSelectBufferData.Name = "checkBoxSelectBufferData";
            this.checkBoxSelectBufferData.Size = new System.Drawing.Size(107, 24);
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
            this.checkBoxSelectFileData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxSelectFileData.Location = new System.Drawing.Point(225, 777);
            this.checkBoxSelectFileData.Name = "checkBoxSelectFileData";
            this.checkBoxSelectFileData.Size = new System.Drawing.Size(101, 24);
            this.checkBoxSelectFileData.TabIndex = 51;
            this.checkBoxSelectFileData.Text = "из файла";
            this.checkBoxSelectFileData.UseVisualStyleBackColor = true;
            this.checkBoxSelectFileData.CheckedChanged += new System.EventHandler(this.checkBoxSelectFileData_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(760, 730);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(9, 195);
            this.label2.TabIndex = 54;
            this.label2.Text = "|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1571, 948);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBoxSelectFileData);
            this.Controls.Add(this.checkBoxSelectBufferData);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCountOfValues);
            this.Controls.Add(this.btnClearBuffer);
            this.Controls.Add(this.btnSaveBufferToTextFile);
            this.Controls.Add(this.pctrbxDataRecivingIndicator);
            this.Controls.Add(this.lblRecieve);
            this.Controls.Add(this.cmbDeleteGraphChoise);
            this.Controls.Add(this.btnDeleteChosenGraph);
            this.Controls.Add(this.chkbxIsGraphNormalized);
            this.Controls.Add(this.txtBoxGraphName);
            this.Controls.Add(this.labelChartAreaChoise);
            this.Controls.Add(this.cmbChartAreaChoice);
            this.Controls.Add(this.btnDeleteSecondChartArea);
            this.Controls.Add(this.btnCreateSecondChartArea);
            this.Controls.Add(this.btnRefreshPortsList);
            this.Controls.Add(this.cmbPort);
            this.Controls.Add(this.btnClosePort);
            this.Controls.Add(this.btnOpenPort);
            this.Controls.Add(this.btnShowDataFrom);
            this.Controls.Add(this.dataChart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(2000, 2000);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super Graph";
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
        private System.Windows.Forms.ComboBox cmbPort;
        private System.Windows.Forms.Button btnRefreshPortsList;
        private System.Windows.Forms.Button btnCreateSecondChartArea;
        private System.Windows.Forms.Button btnDeleteSecondChartArea;
        private System.Windows.Forms.ComboBox cmbChartAreaChoice;
        private System.Windows.Forms.Label labelChartAreaChoise;
        private System.Windows.Forms.TextBox txtBoxGraphName;
        private System.Windows.Forms.CheckBox chkbxIsGraphNormalized;
        private System.Windows.Forms.Button btnDeleteChosenGraph;
        private System.Windows.Forms.ComboBox cmbDeleteGraphChoise;
        private System.Windows.Forms.Label lblRecieve;
        private System.Windows.Forms.PictureBox pctrbxDataRecivingIndicator;
        private System.Windows.Forms.Button btnSaveBufferToTextFile;
        private System.Windows.Forms.Button btnClearBuffer;
        private System.Windows.Forms.Label lblCountOfValues;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxSelectBufferData;
        private System.Windows.Forms.CheckBox checkBoxSelectFileData;
        private System.Windows.Forms.Label label2;
    }
}

