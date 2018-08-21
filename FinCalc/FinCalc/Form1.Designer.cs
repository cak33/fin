namespace FinCalc
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
            this.loadBtn = new System.Windows.Forms.Button();
            this.startDate_TxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.endDate_TxtBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.railPercentage_TxtBox = new System.Windows.Forms.TextBox();
            this.movingAvg_TxtBox = new System.Windows.Forms.TextBox();
            this.marginSaftey_TxtBox = new System.Windows.Forms.TextBox();
            this.calc_Btn = new System.Windows.Forms.Button();
            this.outputFile_Btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loadBtn
            // 
            this.loadBtn.Location = new System.Drawing.Point(12, 12);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(75, 23);
            this.loadBtn.TabIndex = 0;
            this.loadBtn.Text = "Load Data";
            this.loadBtn.UseVisualStyleBackColor = true;
            this.loadBtn.Click += new System.EventHandler(this.loadBtn_Click);
            // 
            // startDate_TxtBox
            // 
            this.startDate_TxtBox.Location = new System.Drawing.Point(12, 58);
            this.startDate_TxtBox.Name = "startDate_TxtBox";
            this.startDate_TxtBox.Size = new System.Drawing.Size(100, 20);
            this.startDate_TxtBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Start Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "End Date";
            // 
            // endDate_TxtBox
            // 
            this.endDate_TxtBox.Location = new System.Drawing.Point(12, 101);
            this.endDate_TxtBox.Name = "endDate_TxtBox";
            this.endDate_TxtBox.Size = new System.Drawing.Size(100, 20);
            this.endDate_TxtBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Rail Percentage";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Moving Avg.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Margin of Safety Percentage";
            // 
            // railPercentage_TxtBox
            // 
            this.railPercentage_TxtBox.Location = new System.Drawing.Point(12, 145);
            this.railPercentage_TxtBox.Name = "railPercentage_TxtBox";
            this.railPercentage_TxtBox.Size = new System.Drawing.Size(100, 20);
            this.railPercentage_TxtBox.TabIndex = 10;
            // 
            // movingAvg_TxtBox
            // 
            this.movingAvg_TxtBox.Location = new System.Drawing.Point(12, 184);
            this.movingAvg_TxtBox.Name = "movingAvg_TxtBox";
            this.movingAvg_TxtBox.Size = new System.Drawing.Size(100, 20);
            this.movingAvg_TxtBox.TabIndex = 11;
            // 
            // marginSaftey_TxtBox
            // 
            this.marginSaftey_TxtBox.Location = new System.Drawing.Point(12, 223);
            this.marginSaftey_TxtBox.Name = "marginSaftey_TxtBox";
            this.marginSaftey_TxtBox.Size = new System.Drawing.Size(100, 20);
            this.marginSaftey_TxtBox.TabIndex = 12;
            // 
            // calc_Btn
            // 
            this.calc_Btn.Location = new System.Drawing.Point(12, 249);
            this.calc_Btn.Name = "calc_Btn";
            this.calc_Btn.Size = new System.Drawing.Size(75, 23);
            this.calc_Btn.TabIndex = 13;
            this.calc_Btn.Text = "Calculate";
            this.calc_Btn.UseVisualStyleBackColor = true;
            this.calc_Btn.Click += new System.EventHandler(this.calc_Btn_Click);
            // 
            // outputFile_Btn
            // 
            this.outputFile_Btn.Location = new System.Drawing.Point(93, 12);
            this.outputFile_Btn.Name = "outputFile_Btn";
            this.outputFile_Btn.Size = new System.Drawing.Size(75, 23);
            this.outputFile_Btn.TabIndex = 14;
            this.outputFile_Btn.Text = "Output File";
            this.outputFile_Btn.UseVisualStyleBackColor = true;
            this.outputFile_Btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 351);
            this.Controls.Add(this.outputFile_Btn);
            this.Controls.Add(this.calc_Btn);
            this.Controls.Add(this.marginSaftey_TxtBox);
            this.Controls.Add(this.movingAvg_TxtBox);
            this.Controls.Add(this.railPercentage_TxtBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.endDate_TxtBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startDate_TxtBox);
            this.Controls.Add(this.loadBtn);
            this.Name = "Form1";
            this.Text = "FinCalc";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadBtn;
        private System.Windows.Forms.TextBox startDate_TxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox endDate_TxtBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox railPercentage_TxtBox;
        private System.Windows.Forms.TextBox movingAvg_TxtBox;
        private System.Windows.Forms.TextBox marginSaftey_TxtBox;
        private System.Windows.Forms.Button calc_Btn;
        private System.Windows.Forms.Button outputFile_Btn;
    }
}

