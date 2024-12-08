namespace KasKu
{
    partial class TambahPengeluaran
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
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            dateTimePickerTanggal = new DateTimePicker();
            numHargaSatuan = new NumericUpDown();
            numJumlahBarang = new NumericUpDown();
            txtNamaBarang = new TextBox();
            btnSimpan = new Button();
            panel1 = new Panel();
            btnKembali = new Button();
            ((System.ComponentModel.ISupportInitialize)numHargaSatuan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numJumlahBarang).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Ebrima", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(22, 11);
            label1.Name = "label1";
            label1.Size = new Size(296, 31);
            label1.TabIndex = 0;
            label1.Text = "Tambah Data Pengeluaran";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.AppWorkspace;
            label2.Font = new Font("Ebrima", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(33, 68);
            label2.Name = "label2";
            label2.Size = new Size(96, 20);
            label2.TabIndex = 1;
            label2.Text = "Penggunaan";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.AppWorkspace;
            label3.Font = new Font("Ebrima", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(36, 132);
            label3.Name = "label3";
            label3.Size = new Size(76, 20);
            label3.TabIndex = 2;
            label3.Text = "Kuantitas";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.AppWorkspace;
            label4.Font = new Font("Ebrima", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(36, 197);
            label4.Name = "label4";
            label4.Size = new Size(103, 20);
            label4.TabIndex = 3;
            label4.Text = "Harga Satuan";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.AppWorkspace;
            label5.Font = new Font("Ebrima", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(36, 266);
            label5.Name = "label5";
            label5.Size = new Size(65, 20);
            label5.TabIndex = 4;
            label5.Text = "Tanggal";
            // 
            // dateTimePickerTanggal
            // 
            dateTimePickerTanggal.Font = new Font("Ebrima", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateTimePickerTanggal.Location = new Point(36, 289);
            dateTimePickerTanggal.Name = "dateTimePickerTanggal";
            dateTimePickerTanggal.Size = new Size(250, 27);
            dateTimePickerTanggal.TabIndex = 5;
            // 
            // numHargaSatuan
            // 
            numHargaSatuan.Location = new Point(36, 220);
            numHargaSatuan.Maximum = new decimal(new int[] { 1410065407, 2, 0, 0 });
            numHargaSatuan.Name = "numHargaSatuan";
            numHargaSatuan.Size = new Size(221, 27);
            numHargaSatuan.TabIndex = 6;
            // 
            // numJumlahBarang
            // 
            numJumlahBarang.Location = new Point(36, 155);
            numJumlahBarang.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numJumlahBarang.Name = "numJumlahBarang";
            numJumlahBarang.Size = new Size(150, 27);
            numJumlahBarang.TabIndex = 7;
            // 
            // txtNamaBarang
            // 
            txtNamaBarang.Location = new Point(37, 91);
            txtNamaBarang.Name = "txtNamaBarang";
            txtNamaBarang.Size = new Size(268, 27);
            txtNamaBarang.TabIndex = 8;
            // 
            // btnSimpan
            // 
            btnSimpan.BackColor = Color.ForestGreen;
            btnSimpan.Font = new Font("Ebrima", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSimpan.ForeColor = SystemColors.ButtonHighlight;
            btnSimpan.Location = new Point(170, 290);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(136, 48);
            btnSimpan.TabIndex = 9;
            btnSimpan.Text = "Tambah";
            btnSimpan.UseVisualStyleBackColor = false;
            btnSimpan.Click += btnSimpan_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.AppWorkspace;
            panel1.Controls.Add(btnKembali);
            panel1.Controls.Add(btnSimpan);
            panel1.Location = new Point(12, 57);
            panel1.Name = "panel1";
            panel1.Size = new Size(327, 365);
            panel1.TabIndex = 10;
            // 
            // btnKembali
            // 
            btnKembali.BackColor = Color.Red;
            btnKembali.Font = new Font("Ebrima", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnKembali.ForeColor = SystemColors.ButtonHighlight;
            btnKembali.Location = new Point(21, 290);
            btnKembali.Name = "btnKembali";
            btnKembali.Size = new Size(128, 48);
            btnKembali.TabIndex = 10;
            btnKembali.Text = "Kembali";
            btnKembali.UseVisualStyleBackColor = false;
            btnKembali.Click += btnKembali_Click;
            // 
            // TambahPengeluaran
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(360, 450);
            Controls.Add(txtNamaBarang);
            Controls.Add(numJumlahBarang);
            Controls.Add(numHargaSatuan);
            Controls.Add(dateTimePickerTanggal);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "TambahPengeluaran";
            Text = "TambahPengeluaran";
            ((System.ComponentModel.ISupportInitialize)numHargaSatuan).EndInit();
            ((System.ComponentModel.ISupportInitialize)numJumlahBarang).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private DateTimePicker dateTimePickerTanggal;
        private NumericUpDown numHargaSatuan;
        private NumericUpDown numJumlahBarang;
        private TextBox txtNamaBarang;
        private Button btnSimpan;
        private Panel panel1;
        private Button btnKembali;
    }
}