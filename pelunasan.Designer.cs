namespace KasKu
{
    partial class pelunasan
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            tabPage5 = new TabPage();
            dataGridViewPelunasan = new DataGridView();
            btnSimpan = new Button();
            tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPelunasan).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Ebrima", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(317, 18);
            label1.Name = "label1";
            label1.Size = new Size(166, 31);
            label1.TabIndex = 0;
            label1.Text = "Pelunasan Kas";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Ebrima", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(31, 62);
            label2.Name = "label2";
            label2.Size = new Size(157, 20);
            label2.TabIndex = 1;
            label2.Text = "List Belum Lunas Kas";
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
            tabControl1.Location = new Point(165, 418);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(470, 32);
            tabControl1.TabIndex = 6;
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
            // dataGridViewPelunasan
            // 
            dataGridViewPelunasan.AllowUserToAddRows = false;
            dataGridViewPelunasan.AllowUserToDeleteRows = false;
            dataGridViewPelunasan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPelunasan.Location = new Point(31, 85);
            dataGridViewPelunasan.Name = "dataGridViewPelunasan";
            dataGridViewPelunasan.RowHeadersWidth = 51;
            dataGridViewPelunasan.Size = new Size(734, 282);
            dataGridViewPelunasan.TabIndex = 7;
            // 
            // btnSimpan
            // 
            btnSimpan.BackColor = Color.ForestGreen;
            btnSimpan.Font = new Font("Ebrima", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSimpan.ForeColor = SystemColors.ButtonHighlight;
            btnSimpan.Location = new Point(350, 375);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(94, 39);
            btnSimpan.TabIndex = 8;
            btnSimpan.Text = "Simpan";
            btnSimpan.UseVisualStyleBackColor = false;
            btnSimpan.Click += btnSimpan_Click;
            // 
            // pelunasan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSimpan);
            Controls.Add(dataGridViewPelunasan);
            Controls.Add(tabControl1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "pelunasan";
            Text = "KasKu - Pelunasan";
            Load += pelunasan_Load;
            tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewPelunasan).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private DataGridView dataGridViewPelunasan;
        private Button btnSimpan;
    }
}