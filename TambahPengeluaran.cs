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
    public partial class TambahPengeluaran : Form
    {
        private NpgsqlConnection conn = DatabaseHelper.GetConnection();
        public TambahPengeluaran()
        {
            InitializeComponent();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            // Validasi input nama barang
            if (string.IsNullOrWhiteSpace(txtNamaBarang.Text))
            {
                MessageBox.Show("Nama barang wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ambil nilai dari input
            string namaBarang = txtNamaBarang.Text.Trim();
            int jumlahBarang = (int)numJumlahBarang.Value; // Ambil nilai dari NumericUpDown
            decimal hargaSatuan = numHargaSatuan.Value;   // Ambil nilai dari NumericUpDown
            DateTime tanggalPengeluaran = dateTimePickerTanggal.Value;

            // Validasi nilai jumlah barang dan harga satuan
            if (jumlahBarang <= 0 || hargaSatuan <= 0)
            {
                MessageBox.Show("Jumlah barang dan harga satuan harus lebih dari 0!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query = @"
                INSERT INTO pengeluaran (nama_barang, jumlah_barang, harga_satuan, tanggal_pengeluaran)
                VALUES (@nama_barang, @jumlah_barang, @harga_satuan, @tanggal_pengeluaran)";

            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("nama_barang", namaBarang);
                cmd.Parameters.AddWithValue("jumlah_barang", jumlahBarang);
                cmd.Parameters.AddWithValue("harga_satuan", hargaSatuan);
                cmd.Parameters.AddWithValue("tanggal_pengeluaran", tanggalPengeluaran);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil disimpan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset input
                    txtNamaBarang.Clear();
                    numJumlahBarang.Value = 1; // Reset ke default
                    numHargaSatuan.Value = 0; // Reset ke default
                    dateTimePickerTanggal.Value = DateTime.Now;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            transaksi form5 = new transaksi();
            form5.Show();
            this.Hide();
        }
    }
}
