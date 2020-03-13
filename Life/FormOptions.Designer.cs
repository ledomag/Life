namespace Life
{
    partial class FormOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOptions));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudC = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnDefault = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.mtbS = new System.Windows.Forms.MaskedTextBox();
            this.mtbB = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbtnCellColor1 = new Life.ColorButton();
            this.cbtnCellColor2 = new Life.ColorButton();
            this.cbtSharpColor = new Life.ColorButton();
            this.cbtnMapBackground = new Life.ColorButton();
            ((System.ComponentModel.ISupportInitialize)(this.nudC)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "&S - число \"живых\" соседей, при котором клетка остается \"в живых\".";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(352, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "&B - число \"живых\" соседей при котором \"рождается\" новая клетка.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "&Количество жизней клетки.";
            // 
            // nudC
            // 
            this.nudC.Location = new System.Drawing.Point(15, 106);
            this.nudC.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.nudC.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudC.Name = "nudC";
            this.nudC.Size = new System.Drawing.Size(100, 20);
            this.nudC.TabIndex = 5;
            this.nudC.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Цвет &фона карты";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(163, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Цвет &сетки";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Цвет 1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(56, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Цвет 2";
            // 
            // btnDefault
            // 
            this.btnDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDefault.Location = new System.Drawing.Point(12, 233);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(95, 23);
            this.btnDefault.TabIndex = 14;
            this.btnDefault.Text = "&Поумолчанию";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(203, 233);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "&Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(284, 233);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "&Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // mtbS
            // 
            this.mtbS.Location = new System.Drawing.Point(15, 25);
            this.mtbS.Mask = "0/0/0/0/0/0/0/0";
            this.mtbS.Name = "mtbS";
            this.mtbS.Size = new System.Drawing.Size(100, 20);
            this.mtbS.TabIndex = 1;
            this.mtbS.Text = "23";
            // 
            // mtbB
            // 
            this.mtbB.Location = new System.Drawing.Point(15, 65);
            this.mtbB.Mask = "0/0/0/0/0/0/0/0";
            this.mtbB.Name = "mtbB";
            this.mtbB.Size = new System.Drawing.Size(100, 20);
            this.mtbB.TabIndex = 3;
            this.mtbB.Text = "3";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbtnCellColor1);
            this.groupBox1.Controls.Add(this.cbtnCellColor2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(15, 161);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 61);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Цвет ячейки";
            // 
            // label8
            // 
            this.label8.AutoEllipsis = true;
            this.label8.Location = new System.Drawing.Point(110, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(228, 39);
            this.label8.TabIndex = 14;
            this.label8.Text = "Клетка меняет цвет от цвета 1 к цвету 2 при каждом ходе при условии если количест" +
                "во жизней клетки больше 1.";
            // 
            // cbtnCellColor1
            // 
            this.cbtnCellColor1.FillBorderColor = System.Drawing.Color.Black;
            this.cbtnCellColor1.FillColor = System.Drawing.Color.Red;
            this.cbtnCellColor1.Location = new System.Drawing.Point(9, 32);
            this.cbtnCellColor1.Name = "cbtnCellColor1";
            this.cbtnCellColor1.Size = new System.Drawing.Size(44, 23);
            this.cbtnCellColor1.TabIndex = 11;
            this.cbtnCellColor1.Text = "нет";
            this.cbtnCellColor1.UseVisualStyleBackColor = true;
            // 
            // cbtnCellColor2
            // 
            this.cbtnCellColor2.FillBorderColor = System.Drawing.Color.Black;
            this.cbtnCellColor2.FillColor = System.Drawing.Color.White;
            this.cbtnCellColor2.Location = new System.Drawing.Point(59, 32);
            this.cbtnCellColor2.Name = "cbtnCellColor2";
            this.cbtnCellColor2.Size = new System.Drawing.Size(44, 23);
            this.cbtnCellColor2.TabIndex = 13;
            this.cbtnCellColor2.Text = "нет";
            this.cbtnCellColor2.UseVisualStyleBackColor = true;
            // 
            // cbtSharpColor
            // 
            this.cbtSharpColor.FillBorderColor = System.Drawing.Color.Black;
            this.cbtSharpColor.FillColor = System.Drawing.Color.Black;
            this.cbtSharpColor.Location = new System.Drawing.Point(233, 132);
            this.cbtSharpColor.Name = "cbtSharpColor";
            this.cbtSharpColor.Size = new System.Drawing.Size(44, 23);
            this.cbtSharpColor.TabIndex = 9;
            this.cbtSharpColor.Text = "нет";
            this.cbtSharpColor.UseVisualStyleBackColor = true;
            // 
            // cbtnMapBackground
            // 
            this.cbtnMapBackground.FillBorderColor = System.Drawing.Color.Black;
            this.cbtnMapBackground.FillColor = System.Drawing.Color.White;
            this.cbtnMapBackground.Location = new System.Drawing.Point(113, 132);
            this.cbtnMapBackground.Name = "cbtnMapBackground";
            this.cbtnMapBackground.Size = new System.Drawing.Size(44, 23);
            this.cbtnMapBackground.TabIndex = 7;
            this.cbtnMapBackground.Text = "нет";
            this.cbtnMapBackground.UseVisualStyleBackColor = true;
            // 
            // FormOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 268);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.mtbB);
            this.Controls.Add(this.mtbS);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDefault);
            this.Controls.Add(this.cbtSharpColor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbtnMapBackground);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOptions";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Параметры";
            ((System.ComponentModel.ISupportInitialize)(this.nudC)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudC;
        private System.Windows.Forms.Label label4;
        private ColorButton cbtnMapBackground;
        private System.Windows.Forms.Label label5;
        private ColorButton cbtSharpColor;
        private System.Windows.Forms.Label label6;
        private ColorButton cbtnCellColor1;
        private System.Windows.Forms.Label label7;
        private ColorButton cbtnCellColor2;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.MaskedTextBox mtbS;
        private System.Windows.Forms.MaskedTextBox mtbB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;

    }
}