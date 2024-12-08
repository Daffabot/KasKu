namespace KasKu
{
    partial class login
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
            email = new TextBox();
            pass = new TextBox();
            label2 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            submitBtn = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Lucida Sans", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(87, 47);
            label1.Name = "label1";
            label1.Size = new Size(224, 32);
            label1.TabIndex = 0;
            label1.Text = "KasKu - Log In";
            // 
            // email
            // 
            email.Location = new Point(207, 163);
            email.Name = "email";
            email.Size = new Size(351, 27);
            email.TabIndex = 1;
            // 
            // pass
            // 
            pass.Location = new Point(207, 235);
            pass.Name = "pass";
            pass.Size = new Size(351, 27);
            pass.TabIndex = 2;
            pass.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.LightGray;
            label2.Font = new Font("Ebrima", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(207, 140);
            label2.Name = "label2";
            label2.Size = new Size(47, 20);
            label2.TabIndex = 3;
            label2.Text = "Email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.LightGray;
            label3.Font = new Font("Ebrima", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(207, 210);
            label3.Name = "label3";
            label3.Size = new Size(76, 20);
            label3.TabIndex = 4;
            label3.Text = "Password";
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightGray;
            panel1.Controls.Add(submitBtn);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(186, 29);
            panel1.Name = "panel1";
            panel1.Size = new Size(408, 371);
            panel1.TabIndex = 5;
            // 
            // submitBtn
            // 
            submitBtn.BackColor = Color.LimeGreen;
            submitBtn.Font = new Font("Ebrima", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            submitBtn.ForeColor = Color.White;
            submitBtn.Location = new Point(104, 267);
            submitBtn.Margin = new Padding(5);
            submitBtn.Name = "submitBtn";
            submitBtn.Size = new Size(182, 54);
            submitBtn.TabIndex = 1;
            submitBtn.Text = "Submit";
            submitBtn.UseVisualStyleBackColor = false;
            submitBtn.Click += submitBtn_Click;
            // 
            // login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(800, 428);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pass);
            Controls.Add(email);
            Controls.Add(panel1);
            Name = "login";
            Text = "KasKu - Login";
            Load += login_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox email;
        private TextBox pass;
        private Label label2;
        private Label label3;
        private Panel panel1;
        private Button submitBtn;
    }
}