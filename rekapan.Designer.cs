namespace KasKu
{
    partial class rekapan
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
            label1 = new Label();
            label2 = new Label();
            labelTotalSaldo = new Label();
            labelBelumBayar = new Label();
            labelTotalPengeluaran = new Label();
            BtnPrintPDF = new Button();
            labelTotalPemasukan = new Label();
            dateTimePickerStart = new DateTimePicker();
            dateTimePickerEnd = new DateTimePicker();
            label7 = new Label();
            panel1 = new Panel();
            btnLihatPengeluaran = new Button();
            btnLihatSelengkapnya = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            tabPage5 = new TabPage();
            panel1.SuspendLayout();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Ebrima", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(329, 18);
            label1.Name = "label1";
            label1.Size = new Size(149, 31);
            label1.TabIndex = 0;
            label1.Text = "Rekapan Kas";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.AppWorkspace;
            label2.Font = new Font("Ebrima", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(35, 69);
            label2.Name = "label2";
            label2.Size = new Size(155, 25);
            label2.TabIndex = 1;
            label2.Text = "Rentang Waktu: ";
            // 
            // labelTotalSaldo
            // 
            labelTotalSaldo.AutoSize = true;
            labelTotalSaldo.BackColor = SystemColors.AppWorkspace;
            labelTotalSaldo.Font = new Font("Ebrima", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTotalSaldo.Location = new Point(35, 104);
            labelTotalSaldo.Name = "labelTotalSaldo";
            labelTotalSaldo.Size = new Size(193, 25);
            labelTotalSaldo.TabIndex = 2;
            labelTotalSaldo.Text = "Total Saldo: 0 Rupiah";
            // 
            // labelBelumBayar
            // 
            labelBelumBayar.AutoSize = true;
            labelBelumBayar.BackColor = SystemColors.AppWorkspace;
            labelBelumBayar.Font = new Font("Ebrima", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelBelumBayar.Location = new Point(35, 142);
            labelBelumBayar.Name = "labelBelumBayar";
            labelBelumBayar.Size = new Size(300, 25);
            labelBelumBayar.TabIndex = 3;
            labelBelumBayar.Text = "Total Belum Bayar Kas: Tidak Ada";
            // 
            // labelTotalPengeluaran
            // 
            labelTotalPengeluaran.AutoSize = true;
            labelTotalPengeluaran.BackColor = SystemColors.AppWorkspace;
            labelTotalPengeluaran.Font = new Font("Ebrima", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTotalPengeluaran.Location = new Point(35, 214);
            labelTotalPengeluaran.Name = "labelTotalPengeluaran";
            labelTotalPengeluaran.Size = new Size(264, 25);
            labelTotalPengeluaran.TabIndex = 4;
            labelTotalPengeluaran.Text = "Total Pengeluaran: Tidak Ada";
            // 
            // BtnPrintPDF
            // 
            BtnPrintPDF.BackColor = Color.LimeGreen;
            BtnPrintPDF.Font = new Font("Ebrima", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnPrintPDF.ForeColor = SystemColors.ButtonHighlight;
            BtnPrintPDF.Location = new Point(674, 69);
            BtnPrintPDF.Name = "BtnPrintPDF";
            BtnPrintPDF.Size = new Size(94, 34);
            BtnPrintPDF.TabIndex = 5;
            BtnPrintPDF.Text = "Print";
            BtnPrintPDF.UseVisualStyleBackColor = false;
            BtnPrintPDF.Click += BtnPrint_Click;
            // 
            // labelTotalPemasukan
            // 
            labelTotalPemasukan.AutoSize = true;
            labelTotalPemasukan.BackColor = SystemColors.AppWorkspace;
            labelTotalPemasukan.Cursor = Cursors.No;
            labelTotalPemasukan.Font = new Font("Ebrima", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTotalPemasukan.Location = new Point(35, 179);
            labelTotalPemasukan.Name = "labelTotalPemasukan";
            labelTotalPemasukan.Size = new Size(243, 25);
            labelTotalPemasukan.TabIndex = 6;
            labelTotalPemasukan.Text = "Total Pemasukan: 0 Rupiah";
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.CalendarFont = new Font("Ebrima", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateTimePickerStart.CalendarMonthBackground = SystemColors.Control;
            dateTimePickerStart.Font = new Font("Ebrima", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateTimePickerStart.Format = DateTimePickerFormat.Short;
            dateTimePickerStart.Location = new Point(189, 69);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.Size = new Size(110, 27);
            dateTimePickerStart.TabIndex = 7;
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.CalendarFont = new Font("Ebrima", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateTimePickerEnd.CalendarMonthBackground = SystemColors.Control;
            dateTimePickerEnd.Font = new Font("Ebrima", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateTimePickerEnd.Format = DateTimePickerFormat.Short;
            dateTimePickerEnd.Location = new Point(321, 69);
            dateTimePickerEnd.Name = "dateTimePickerEnd";
            dateTimePickerEnd.Size = new Size(112, 27);
            dateTimePickerEnd.TabIndex = 8;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = SystemColors.AppWorkspace;
            label7.Font = new Font("Ebrima", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(301, 69);
            label7.Name = "label7";
            label7.Size = new Size(19, 25);
            label7.TabIndex = 9;
            label7.Text = "-";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.AppWorkspace;
            panel1.Controls.Add(btnLihatPengeluaran);
            panel1.Controls.Add(btnLihatSelengkapnya);
            panel1.Location = new Point(12, 60);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 204);
            panel1.TabIndex = 10;
            // 
            // btnLihatPengeluaran
            // 
            btnLihatPengeluaran.BackColor = Color.Yellow;
            btnLihatPengeluaran.Font = new Font("Ebrima", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLihatPengeluaran.Location = new Point(350, 153);
            btnLihatPengeluaran.Name = "btnLihatPengeluaran";
            btnLihatPengeluaran.Size = new Size(152, 29);
            btnLihatPengeluaran.TabIndex = 2;
            btnLihatPengeluaran.Text = "Lihat Selengkapnya";
            btnLihatPengeluaran.UseVisualStyleBackColor = false;
            btnLihatPengeluaran.Click += btnLihatPengeluaran_Click;
            // 
            // btnLihatSelengkapnya
            // 
            btnLihatSelengkapnya.BackColor = Color.Yellow;
            btnLihatSelengkapnya.Font = new Font("Ebrima", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLihatSelengkapnya.ForeColor = SystemColors.ActiveCaptionText;
            btnLihatSelengkapnya.Location = new Point(273, 80);
            btnLihatSelengkapnya.Name = "btnLihatSelengkapnya";
            btnLihatSelengkapnya.Size = new Size(161, 29);
            btnLihatSelengkapnya.TabIndex = 1;
            btnLihatSelengkapnya.Text = "Lihat Selengkapnya";
            btnLihatSelengkapnya.UseVisualStyleBackColor = false;
            btnLihatSelengkapnya.Click += btnLihatSelengkapnya_Click;
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
            tabControl1.Location = new Point(165, 278);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(470, 32);
            tabControl1.TabIndex = 11;
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
            tabPage2.ImeMode = ImeMode.NoControl;
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
            // rekapan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(800, 309);
            Controls.Add(tabControl1);
            Controls.Add(label7);
            Controls.Add(dateTimePickerEnd);
            Controls.Add(dateTimePickerStart);
            Controls.Add(labelTotalPemasukan);
            Controls.Add(BtnPrintPDF);
            Controls.Add(labelTotalPengeluaran);
            Controls.Add(labelBelumBayar);
            Controls.Add(labelTotalSaldo);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "rekapan";
            Text = "KasKu - Rekapan";
            Load += rekapan_Load;
            panel1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label labelTotalSaldo;
        private Label labelBelumBayar;
        private Label labelTotalPengeluaran;
        private Button BtnPrintPDF;
        private Label labelTotalPemasukan;
        private DateTimePicker dateTimePickerStart;
        private DateTimePicker dateTimePickerEnd;
        private Label label7;
        private Panel panel1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private Button btnLihatSelengkapnya;
        private Button btnLihatPengeluaran;
    }
}