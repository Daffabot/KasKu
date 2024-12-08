using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KasKu
{
    public partial class login : Form
    {
        NpgsqlConnection conn = DatabaseHelper.GetConnection();
        public login()
        {
            InitializeComponent();
            if (conn == null)
            {
                this.Close();
            }
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string mailer = email.Text.Trim();
                string password = pass.Text.Trim();

                // Validasi input kosong
                if (string.IsNullOrEmpty(mailer) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Email dan Password tidak boleh kosong.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Query untuk mencocokkan email dan password
                string query = "SELECT COUNT(*) FROM users WHERE email = @Email AND password = @Password";

                // Eksekusi query menggunakan parameter untuk menghindari SQL Injection
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    // Tambahkan parameter
                    cmd.Parameters.AddWithValue("@Email", mailer);
                    cmd.Parameters.AddWithValue("@Password", password);

                    // Eksekusi query dan cek hasilnya
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("Login berhasil!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Anda bisa menambahkan logika untuk membuka form utama di sini
                        this.Hide();
                        dashboard mainForm = new dashboard();
                        mainForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Email atau Password salah.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
