namespace superGraph
{
    partial class Form2
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
            this.txtbxGraphName = new System.Windows.Forms.TextBox();
            this.lblGraphName = new System.Windows.Forms.Label();
            this.lblChooseChartArea = new System.Windows.Forms.Label();
            this.cmbbxChartArea = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtbxGraphName
            // 
            this.txtbxGraphName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtbxGraphName.Location = new System.Drawing.Point(247, 21);
            this.txtbxGraphName.Name = "txtbxGraphName";
            this.txtbxGraphName.Size = new System.Drawing.Size(144, 21);
            this.txtbxGraphName.TabIndex = 0;
            this.txtbxGraphName.Text = "Без названия";
            // 
            // lblGraphName
            // 
            this.lblGraphName.AutoSize = true;
            this.lblGraphName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblGraphName.Location = new System.Drawing.Point(22, 27);
            this.lblGraphName.Name = "lblGraphName";
            this.lblGraphName.Size = new System.Drawing.Size(174, 15);
            this.lblGraphName.TabIndex = 1;
            this.lblGraphName.Text = "Введите название графика: ";
            // 
            // lblChooseChartArea
            // 
            this.lblChooseChartArea.AutoSize = true;
            this.lblChooseChartArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblChooseChartArea.Location = new System.Drawing.Point(22, 69);
            this.lblChooseChartArea.Name = "lblChooseChartArea";
            this.lblChooseChartArea.Size = new System.Drawing.Size(192, 15);
            this.lblChooseChartArea.TabIndex = 2;
            this.lblChooseChartArea.Text = "Выберите область построения:";
            // 
            // cmbbxChartArea
            // 
            this.cmbbxChartArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbbxChartArea.FormattingEnabled = true;
            this.cmbbxChartArea.Location = new System.Drawing.Point(247, 66);
            this.cmbbxChartArea.Name = "cmbbxChartArea";
            this.cmbbxChartArea.Size = new System.Drawing.Size(74, 23);
            this.cmbbxChartArea.TabIndex = 3;
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOk.Location = new System.Drawing.Point(162, 117);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(80, 30);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ок";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 169);
            this.ControlBox = false;
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cmbbxChartArea);
            this.Controls.Add(this.lblChooseChartArea);
            this.Controls.Add(this.lblGraphName);
            this.Controls.Add(this.txtbxGraphName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbxGraphName;
        private System.Windows.Forms.Label lblGraphName;
        private System.Windows.Forms.Label lblChooseChartArea;
        private System.Windows.Forms.ComboBox cmbbxChartArea;
        private System.Windows.Forms.Button btnOk;
    }
}