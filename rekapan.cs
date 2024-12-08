using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Layout;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.IO.Font;
using iText.Signatures;

//// Registrasi BouncyCastle sebagai provider
//BouncyCastleProvider provider = new BouncyCastleProvider();
//Security.AddProvider(provider);


namespace KasKu
{
    public partial class rekapan : Form
    {
        private NpgsqlConnection conn = DatabaseHelper.GetConnection();
        private decimal totalPemasukan;
        private decimal totalPengeluaran;
        public rekapan()
        {
            InitializeComponent();
            if (conn == null)
            {
                this.Close();
            }
            tabControl1.SelectedIndex = 2;
            tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
            dateTimePickerStart.ValueChanged += (s, ev) => hitung(s, ev);
            dateTimePickerEnd.ValueChanged += (s, ev) => hitung(s, ev);
            this.Load += (s, ev) => hitung(s, ev);
        }
        private bool isHandlerAttached = false;

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Dapatkan tab yang dipilih
            int selectedTabIndex = tabControl1.SelectedIndex;

            // Periksa indeks tab yang dipilih dan buka form baru
            switch (selectedTabIndex)
            {
                case 0: // Tab pertama
                    dashboard form1 = new dashboard();
                    form1.Show();
                    this.Hide(); // Sembunyikan MainForm jika perlu
                    break;

                case 1: // Tab kedua
                    input form2 = new input();
                    form2.Show();
                    this.Hide(); // Sembunyikan MainForm jika perlu
                    break;

                case 2: // Tab kedua
                    rekapan form3 = new rekapan();
                    form3.Show();
                    this.Hide(); // Sembunyikan MainForm jika perlu
                    break;

                case 3: // Tab kedua
                    pelunasan form4 = new pelunasan();
                    form4.Show();
                    this.Hide(); // Sembunyikan MainForm jika perlu
                    break;

                case 4: // Tab kedua
                    transaksi form5 = new transaksi();
                    form5.Show();
                    this.Hide(); // Sembunyikan MainForm jika perlu
                    break;

                default:
                    break;
            }
        }

        private void rekapan_Load(object sender, EventArgs e)
        {
        }

        private void hitung(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePickerStart.Value.Date;
            DateTime endDate = dateTimePickerEnd.Value.Date;

            try
            {
                if (conn == null)
                {
                    throw new Exception("Koneksi gagal. Pastikan server aktif.");
                }

                // Hitung Total Pemasukan
                string pemasukanQuery = "SELECT COALESCE(SUM(bayar), 0) AS total_pemasukan FROM kas_masuk WHERE tanggal_bayar BETWEEN @startDate AND @endDate";
                NpgsqlCommand cmd = new NpgsqlCommand(pemasukanQuery, conn);
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);
                totalPemasukan = Convert.ToDecimal(cmd.ExecuteScalar());

                // Hitung Total Pengeluaran
                string pengeluaranQuery = "SELECT COALESCE(SUM(jumlah_barang * harga_satuan), 0) AS total_pengeluaran FROM pengeluaran WHERE tanggal_pengeluaran BETWEEN @startDate AND @endDate";
                cmd = new NpgsqlCommand(pengeluaranQuery, conn);
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);
                totalPengeluaran = Convert.ToDecimal(cmd.ExecuteScalar());

                // Update Label
                decimal totalSaldo = totalPemasukan - totalPengeluaran;
                labelTotalSaldo.Text = $"Total Saldo: {totalSaldo:N0} Rupiah";
                labelTotalPemasukan.Text = $"Total Pemasukan: {totalPemasukan:N0} Rupiah";
                labelTotalPengeluaran.Text = $"Total Pengeluaran: {totalPengeluaran:N0} Rupiah";

                // Atur tombol "Lihat Belum Bayar"
                var siswaBelumBayar = DapatkanSiswaBelumBayar(startDate, endDate);
                if (siswaBelumBayar.Count > 0)
                {
                    labelBelumBayar.Text = $"Total Belum Bayar Kas: {siswaBelumBayar.Count}";
                    btnLihatSelengkapnya.Visible = true;

                    // Pastikan hanya satu event handler
                    btnLihatSelengkapnya.Click -= btnLihatSelengkapnya_Click;
                    btnLihatSelengkapnya.Click += btnLihatSelengkapnya_Click;
                }
                else
                {
                    labelBelumBayar.Text = "Total Belum Bayar Kas: Tidak Ada";
                    btnLihatSelengkapnya.Visible = false;
                }

                // Pengeluaran Detail Button
                if (totalPengeluaran > 0)
                {
                    // Bersihkan event handler lama
                    btnLihatPengeluaran.Click -= (s, ev) => ShowPengeluaranDetails(startDate, endDate);
                    btnLihatPengeluaran.Visible = true;
                }
                else
                {
                    btnLihatPengeluaran.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<(string NamaSiswa, decimal TotalBelumBayar)> DapatkanSiswaBelumBayar(DateTime startDate, DateTime endDate)
        {
            var result = new List<(string NamaSiswa, decimal TotalBelumBayar)>();
                string query = @"
                SELECT s.nama_siswa, 
                       SUM(CASE 
                           WHEN km.bayar = 0 THEN 5000 
                           WHEN km.bayar < 5000 THEN 5000 - km.bayar 
                           ELSE 0 
                       END) AS total_belum_bayar
                FROM kas_masuk km
                JOIN siswa s ON km.id_siswa = s.id_siswa
                WHERE km.tanggal_bayar BETWEEN @startDate AND @endDate
                GROUP BY s.nama_siswa";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("startDate", startDate);
                    cmd.Parameters.AddWithValue("endDate", endDate);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string namaSiswa = reader.GetString(0);
                            decimal totalBelumBayar = reader.IsDBNull(1) ? 0 : reader.GetDecimal(1);

                            if (totalBelumBayar > 0)
                            {
                                result.Add((namaSiswa, totalBelumBayar));
                            }
                        }
                    }
                }

            return result;
        }

        private List<(string NamaBarang, int JumlahBarang, decimal HargaSatuan, decimal TotalHarga, DateTime TanggalPengeluaran)> DapatkanDetailPengeluaran(DateTime startDate, DateTime endDate)
        {
            var result = new List<(string NamaBarang, int JumlahBarang, decimal HargaSatuan, decimal TotalHarga, DateTime TanggalPengeluaran)>();

                string query = @"
                SELECT nama_barang, jumlah_barang, harga_satuan, (jumlah_barang * harga_satuan) AS total_harga, tanggal_pengeluaran
                FROM pengeluaran
                WHERE tanggal_pengeluaran BETWEEN @startDate AND @endDate";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("startDate", startDate);
                    cmd.Parameters.AddWithValue("endDate", endDate);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string namaBarang = reader.GetString(0);
                            int jumlahBarang = reader.GetInt32(1);
                            decimal hargaSatuan = reader.GetDecimal(2);
                            decimal totalHarga = reader.GetDecimal(3);
                            DateTime tanggalPengeluaran = reader.GetDateTime(4);

                            result.Add((namaBarang, jumlahBarang, hargaSatuan, totalHarga, tanggalPengeluaran));
                        }
                    }
                }

            return result;
        }


        private void btnLihatSelengkapnya_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePickerStart.Value.Date;
            DateTime endDate = dateTimePickerEnd.Value.Date;

            var siswaBelumBayar = DapatkanSiswaBelumBayar(startDate, endDate);

            if (siswaBelumBayar.Count > 0)
            {
                string message = "Detail siswa yang belum bayar:\n";
                foreach (var siswa in siswaBelumBayar)
                {
                    message += $"- {siswa.NamaSiswa}: Rp{siswa.TotalBelumBayar:N0}\n";
                }

                MessageBox.Show(message, "Detail Belum Bayar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Tidak ada siswa yang belum membayar dalam rentang waktu ini.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ShowPengeluaranDetails(DateTime startDate, DateTime endDate)
        {
            string query = "SELECT * FROM pengeluaran WHERE tanggal_pengeluaran BETWEEN @startDate AND @endDate";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@startDate", startDate);
            cmd.Parameters.AddWithValue("@endDate", endDate);

            NpgsqlDataReader reader = cmd.ExecuteReader();
            List<string> pengeluaranList = new List<string>();
            while (reader.Read())
            {
                string namaBarang = reader["nama_barang"].ToString();
                int jumlahBarang = Convert.ToInt32(reader["jumlah_barang"]);
                decimal hargaSatuan = Convert.ToDecimal(reader["harga_satuan"]);
                DateTime tanggalPengeluaran = Convert.ToDateTime(reader["tanggal_pengeluaran"]);

                pengeluaranList.Add($"- {namaBarang}, {jumlahBarang} x Rp{hargaSatuan:N0}, Tanggal: {tanggalPengeluaran:yyyy-MM-dd}");
            }
            reader.Close();

            if (pengeluaranList.Count > 0)
            {
                string message = "Detail Pengeluaran:\n" + string.Join("\n", pengeluaranList);
                MessageBox.Show(message, "Pengeluaran", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLihatPengeluaran_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePickerStart.Value.Date;
            DateTime endDate = dateTimePickerEnd.Value.Date;
            ShowPengeluaranDetails(startDate, endDate);
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePickerStart.Value.Date;
            DateTime endDate = dateTimePickerEnd.Value.Date;

            // Hitung data
            decimal saldo = totalPemasukan - totalPengeluaran;
            var siswaBelumBayar = DapatkanSiswaBelumBayar(startDate, endDate);
            var pengeluaranDetails = DapatkanDetailPengeluaran(startDate, endDate);

            // Buat PDF
            string filePath = $"Laporan_Kas_{DateTime.Now:yyyyMMddHHmmss}.pdf";
            BuatLaporanPDF(filePath, startDate, endDate, saldo, totalPemasukan, totalPengeluaran, siswaBelumBayar, pengeluaranDetails);

            MessageBox.Show($"Laporan berhasil dibuat dan disimpan di {filePath}", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void BuatLaporanPDF(
            string filePath,
            DateTime startDate,
            DateTime endDate,
            decimal saldo,
            decimal totalPemasukan,
            decimal totalPengeluaran,
            List<(string NamaSiswa, decimal TotalBelumBayar)> siswaBelumBayar,
            List<(string NamaBarang, int JumlahBarang, decimal HargaSatuan, decimal TotalHarga, DateTime TanggalPengeluaran)> pengeluaranDetails)
            {
                using (PdfWriter writer = new PdfWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath)))
                {
                    using (PdfDocument pdf = new PdfDocument(writer))
                    {
                        Document document = new Document(pdf);

                        // Load font bold
                        PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                        PdfFont regularFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                        // Header
                        document.Add(new Paragraph("Laporan Kas")
                            .SetFont(boldFont)
                            .SetFontSize(16)
                            .SetTextAlignment(TextAlignment.CENTER));

                        document.Add(new Paragraph($"Periode: {startDate:dd MMM yyyy} - {endDate:dd MMM yyyy}\n\n")
                            .SetFont(regularFont)
                            .SetTextAlignment(TextAlignment.CENTER));

                        // Total Saldo
                        document.Add(new Paragraph($"Saldo Tersisa: {saldo:N0} Rupiah\n\n")
                            .SetFont(boldFont)
                            .SetFontSize(12));

                        // Total Pemasukan dan Pengeluaran
                        document.Add(new Paragraph($"Total Pemasukan: {totalPemasukan:N0} Rupiah")
                            .SetFont(regularFont));
                        document.Add(new Paragraph($"Total Pengeluaran: {totalPengeluaran:N0} Rupiah\n\n")
                            .SetFont(regularFont));

                        // Detail Siswa Belum Bayar
                        if (siswaBelumBayar.Count > 0)
                        {
                            document.Add(new Paragraph("Detail Siswa Belum Bayar:")
                                .SetFont(boldFont));

                            foreach (var siswa in siswaBelumBayar)
                            {
                                document.Add(new Paragraph($"- {siswa.NamaSiswa}: Rp{siswa.TotalBelumBayar:N0}")
                                    .SetFont(regularFont));
                            }
                            document.Add(new Paragraph("\n"));
                        }
                        else
                        {
                            document.Add(new Paragraph("Tidak ada siswa yang belum membayar.\n\n")
                                .SetFont(regularFont));
                        }

                        // Detail Pengeluaran
                        if (pengeluaranDetails.Count > 0)
                        {
                            document.Add(new Paragraph("Detail Pengeluaran:")
                                .SetFont(boldFont));

                            foreach (var pengeluaran in pengeluaranDetails)
                            {
                                document.Add(new Paragraph(
                                    $"- {pengeluaran.NamaBarang}, {pengeluaran.JumlahBarang} unit, Harga Satuan: Rp{pengeluaran.HargaSatuan:N0}, Total: Rp{pengeluaran.TotalHarga:N0}, Tanggal: {pengeluaran.TanggalPengeluaran:dd MMM yyyy}")
                                    .SetFont(regularFont));
                            }
                            document.Add(new Paragraph("\n"));
                        }
                        else
                        {
                            document.Add(new Paragraph("Tidak ada pengeluaran dalam periode ini.\n\n")
                                .SetFont(regularFont));
                        }

                        document.Close();
                    }
                }
            }
    }
}
