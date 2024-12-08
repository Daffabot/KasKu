namespace KasKu
{
    partial class dashboard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            label1 = new Label();
            label2 = new Label();
            totalS = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            tabPage5 = new TabPage();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            rbLastMonth = new RadioButton();
            rbLastYear = new RadioButton();
            tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Swis721 Blk BT", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(345, 17);
            label1.Name = "label1";
            label1.Size = new Size(114, 34);
            label1.TabIndex = 1;
            label1.Text = "KasKu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Ebrima", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 84);
            label2.Name = "label2";
            label2.Size = new Size(113, 25);
            label2.TabIndex = 2;
            label2.Text = "Total Saldo:";
            // 
            // totalS
            // 
            totalS.AutoSize = true;
            totalS.Font = new Font("Ebrima", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totalS.Location = new Point(121, 85);
            totalS.Name = "totalS";
            totalS.Size = new Size(50, 25);
            totalS.TabIndex = 3;
            totalS.Text = "Rp 0";
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Cursor = Cursors.Hand;
            tabControl1.Font = new Font("Ebrima", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabControl1.Location = new Point(157, 420);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(470, 32);
            tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(462, 0);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Dashboard";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(462, 0);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Input";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 34);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(462, 0);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Rekapan";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(4, 34);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(462, 0);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Pelunasan";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            tabPage5.Location = new Point(4, 34);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(462, 0);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Transaksi";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chart1.Legends.Add(legend2);
            chart1.Location = new Point(12, 114);
            chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "Pemasukan";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "Pengeluaran";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            chart1.Series.Add(series3);
            chart1.Series.Add(series4);
            chart1.Size = new Size(776, 300);
            chart1.TabIndex = 5;
            chart1.Text = "chart1";
            // 
            // rbLastMonth
            // 
            rbLastMonth.AutoSize = true;
            rbLastMonth.Location = new Point(671, 62);
            rbLastMonth.Name = "rbLastMonth";
            rbLastMonth.Size = new Size(87, 24);
            rbLastMonth.TabIndex = 6;
            rbLastMonth.Text = "Perbulan";
            rbLastMonth.UseVisualStyleBackColor = true;
            // 
            // rbLastYear
            // 
            rbLastYear.AutoSize = true;
            rbLastYear.Location = new Point(671, 86);
            rbLastYear.Name = "rbLastYear";
            rbLastYear.Size = new Size(87, 24);
            rbLastYear.TabIndex = 7;
            rbLastYear.Text = "Pertahun";
            rbLastYear.UseVisualStyleBackColor = true;
            // 
            // dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(rbLastYear);
            Controls.Add(rbLastMonth);
            Controls.Add(chart1);
            Controls.Add(tabControl1);
            Controls.Add(totalS);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "dashboard";
            Text = "KasKu - Dashboard";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private Label totalS;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private RadioButton rbLastMonth;
        private RadioButton rbLastYear;
    }
}
