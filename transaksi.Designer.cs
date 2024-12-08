namespace KasKu
{
    partial class transaksi
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            tabPage5 = new TabPage();
            label1 = new Label();
            dateTimePickerBulan = new DateTimePicker();
            dataGridViewPengeluaran = new DataGridView();
            addTrans = new Button();
            tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPengeluaran).BeginInit();
            SuspendLayout();
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
            tabControl1.Location = new Point(165, 417);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(470, 32);
            tabControl1.TabIndex = 7;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Ebrima", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(277, 23);
            label1.Name = "label1";
            label1.Size = new Size(254, 31);
            label1.TabIndex = 8;
            label1.Text = "Transaksi Pengeluaran";
            // 
            // dateTimePickerBulan
            // 
            dateTimePickerBulan.CustomFormat = "MM/yyyy";
            dateTimePickerBulan.Font = new Font("Ebrima", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateTimePickerBulan.Format = DateTimePickerFormat.Custom;
            dateTimePickerBulan.Location = new Point(349, 63);
            dateTimePickerBulan.Name = "dateTimePickerBulan";
            dateTimePickerBulan.Size = new Size(108, 27);
            dateTimePickerBulan.TabIndex = 9;
            // 
            // dataGridViewPengeluaran
            // 
            dataGridViewPengeluaran.AllowUserToAddRows = false;
            dataGridViewPengeluaran.AllowUserToDeleteRows = false;
            dataGridViewPengeluaran.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPengeluaran.Location = new Point(12, 99);
            dataGridViewPengeluaran.Name = "dataGridViewPengeluaran";
            dataGridViewPengeluaran.ReadOnly = true;
            dataGridViewPengeluaran.RowHeadersWidth = 51;
            dataGridViewPengeluaran.Size = new Size(776, 267);
            dataGridViewPengeluaran.TabIndex = 10;
            // 
            // addTrans
            // 
            addTrans.BackColor = Color.SteelBlue;
            addTrans.Font = new Font("Ebrima", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addTrans.ForeColor = SystemColors.ButtonHighlight;
            addTrans.Location = new Point(299, 373);
            addTrans.Name = "addTrans";
            addTrans.Size = new Size(210, 38);
            addTrans.TabIndex = 11;
            addTrans.Text = "Tambah Pengeluaran";
            addTrans.UseVisualStyleBackColor = false;
            addTrans.Click += addTrans_Click;
            // 
            // transaksi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(addTrans);
            Controls.Add(dataGridViewPengeluaran);
            Controls.Add(dateTimePickerBulan);
            Controls.Add(label1);
            Controls.Add(tabControl1);
            Name = "transaksi";
            Text = "KasKu - Transaksi";
            Load += transaksi_Load;
            tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewPengeluaran).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private Label label1;
        private DateTimePicker dateTimePickerBulan;
        private DataGridView dataGridViewPengeluaran;
        private Button addTrans;
    }
}