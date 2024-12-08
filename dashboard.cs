using Npgsql;
using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;

// Untuk inisiasi bahwa form ini dari project yang bernama AbsenKelas
namespace KasKu
{
    // Untuk inisiasi bahwa class ini berbentuk Form dan bernama Form1 dan bisa dipanggil di luar scope ini
    public partial class dashboard : Form
    {
        // Membuat variabel conn di Nuget Package Manager SQL Connection dengan isi dari class DatabaseHelper yang memanggil method GetConnection
        NpgsqlConnection conn = DatabaseHelper.GetConnection();
        // Ini adalah method yang bernama Form1 yang akan dijalankan pertama kali ketika Form1 muncul dan method ini bisa dipanggil di luar class
        public dashboard()
        {
            // Untuk inisiasi semua komponen yang ada di form
            InitializeComponent();
            if (conn == null)
            {
                this.Close();
            }
            rbLastMonth.Checked = true;
            rbLastMonth.CheckedChanged += RadioButton_CheckedChanged;
            rbLastYear.CheckedChanged += RadioButton_CheckedChanged;

            // Untuk inisiasi Chart
            LoadChartData();
            tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
        }

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

        private void LoadChartData()
        {
            try
            {
                int saldoAwal = 300000;
                // Pilih periode berdasarkan RadioButton
                var isLastMonth = rbLastMonth.Checked;
                var isLastYear = rbLastYear.Checked;

                // Variabel untuk menyimpan data
                List<(DateTime, decimal)> pemasukanData = new List<(DateTime, decimal)>();
                List<(DateTime, decimal)> pengeluaranData = new List<(DateTime, decimal)>();

                if (rbLastMonth.Checked)
                {
                    DateTime startDate = DateTime.Now.AddMonths(-1).Date;
                    //MessageBox.Show($"Ini datanya: {startDate}");
                    string pemasukanQuery = @"
                    SELECT tanggal_bayar, SUM(bayar) AS total_pemasukan
                    FROM kas_masuk
                    WHERE tanggal_bayar >= @startDate
                    GROUP BY tanggal_bayar
                    ORDER BY tanggal_bayar;";
                    pemasukanData = GetChartData(conn, pemasukanQuery, startDate);

                    string pengeluaranQuery = @"
                    SELECT tanggal_pengeluaran, SUM(jumlah_barang * harga_satuan) AS total_pengeluaran
                    FROM pengeluaran
                    WHERE tanggal_pengeluaran >= @startDate
                    GROUP BY tanggal_pengeluaran
                    ORDER BY tanggal_pengeluaran;";
                    pengeluaranData = GetChartData(conn, pengeluaranQuery, startDate);

                    PopulateChartDaily(pemasukanData, pengeluaranData);
                }
                else if (rbLastYear.Checked)
                {
                    DateTime startDate = DateTime.Now.AddYears(-1).Date;
                    string pemasukanQuery = @"
                    SELECT DATE_TRUNC('month', tanggal_bayar) AS bulan, SUM(bayar) AS total_pemasukan
                    FROM kas_masuk
                    WHERE tanggal_bayar >= @startDate
                    GROUP BY bulan
                    ORDER BY bulan;";
                    pemasukanData = GetChartData(conn, pemasukanQuery, startDate);

                    string pengeluaranQuery = @"
                    SELECT DATE_TRUNC('month', tanggal_pengeluaran) AS bulan, SUM(jumlah_barang * harga_satuan) AS total_pengeluaran
                    FROM pengeluaran
                    WHERE tanggal_pengeluaran >= @startDate
                    GROUP BY bulan
                    ORDER BY bulan;";
                    pengeluaranData = GetChartData(conn, pengeluaranQuery, startDate);

                    PopulateChartMonthly(pemasukanData, pengeluaranData);
                }

                Debug.WriteLine($"Pemasukan Count: {pemasukanData.Count}, Pengeluaran Count: {pengeluaranData.Count}");


                if (pemasukanData.Count == 0 && pengeluaranData.Count == 0)
                {
                    chart1.Series.Clear();
                    chart1.Titles.Clear();
                    chart1.Titles.Add("Tidak ada data untuk periode yang dipilih");
                    return;
                }

                // Query untuk menghitung total pemasukan
                string masukanQuery = "SELECT COALESCE(SUM(bayar), 0) AS total_pemasukan FROM kas_masuk;";
                decimal totalPemasukan = 0;

                using (var cmd = new NpgsqlCommand(masukanQuery, conn))
                {
                    totalPemasukan = Convert.ToDecimal(cmd.ExecuteScalar());
                }

                // Query untuk menghitung total pengeluaran
                string pengeluaran = @"
                SELECT COALESCE(SUM(jumlah_barang * harga_satuan), 0) AS total_pengeluaran
                FROM pengeluaran;";
                decimal totalPengeluaran = 0;

                using (var cmd = new NpgsqlCommand(pengeluaran, conn))
                {
                    totalPengeluaran = Convert.ToDecimal(cmd.ExecuteScalar());
                }

                // Hitung saldo
                decimal totalSaldo = totalPemasukan - totalPengeluaran + saldoAwal;

                // Tampilkan saldo di label3
                totalS.Text = $"Rp {totalSaldo:N0}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateChartDaily(List<(DateTime, decimal)> pemasukanData, List<(DateTime, decimal)> pengeluaranData)
        {
            // Bersihkan Chart
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            // Tambahkan ChartArea
            ChartArea chartArea = new ChartArea("MainArea")
            {
                AxisX = { Title = "Tanggal", Interval = 1 },
                AxisY = { Title = "Nominal (Rp)" }
            };
            chart1.ChartAreas.Add(chartArea);

            // Rentang waktu
            DateTime startDate = DateTime.Now.AddMonths(-1).Date;
            DateTime endDate = DateTime.Now;

            // Generate semua tanggal dalam rentang waktu
            var allDates = GenerateDateRange(startDate, endDate);

            // Dictionary untuk menyimpan pemasukan/pengeluaran
            Dictionary<DateTime, decimal> pemasukanDict = pemasukanData.ToDictionary(x => x.Item1, x => x.Item2);
            Dictionary<DateTime, decimal> pengeluaranDict = pengeluaranData.ToDictionary(x => x.Item1, x => x.Item2);

            // Series untuk Pemasukan dan Pengeluaran
            Series pemasukanSeries = CreateSeries("Pemasukan", System.Drawing.Color.Blue);
            Series pengeluaranSeries = CreateSeries("Pengeluaran", System.Drawing.Color.Red);

            // Masukkan data ke Series dan AxisX
            foreach (var date in allDates)
            {
                decimal pemasukan = pemasukanDict.ContainsKey(date) ? pemasukanDict[date] : 0;
                decimal pengeluaran = pengeluaranDict.ContainsKey(date) ? pengeluaranDict[date] : 0;

                pemasukanSeries.Points.AddXY(date, pemasukan);
                pengeluaranSeries.Points.AddXY(date, pengeluaran);

                chartArea.AxisX.CustomLabels.Add(new CustomLabel(
                    date.ToOADate(), date.AddDays(1).ToOADate(), date.ToString("dd MMM yyyy"), 0, LabelMarkStyle.None));
            }

            // Tambahkan Series ke Chart
            chart1.Series.Add(pemasukanSeries);
            chart1.Series.Add(pengeluaranSeries);

            chart1.Titles.Clear();
            chart1.Titles.Add("Grafik Pemasukan dan Pengeluaran (Harian)");
        }

        private void PopulateChartMonthly(List<(DateTime, decimal)> pemasukanData, List<(DateTime, decimal)> pengeluaranData)
        {
            // Bersihkan Chart
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            // Tambahkan ChartArea
            ChartArea chartArea = new ChartArea("MainArea")
            {
                AxisX = { Title = "Bulan", Interval = 1 },
                AxisY = { Title = "Nominal (Rp)" }
            };
            chart1.ChartAreas.Add(chartArea);

            // Rentang waktu
            DateTime startDate = DateTime.Now.AddYears(-1).Date;
            DateTime endDate = DateTime.Now;

            // Generate semua bulan dalam rentang waktu
            var allMonths = GenerateMonthRange(startDate, endDate);

            // Dictionary untuk menyimpan pemasukan/pengeluaran
            Dictionary<DateTime, decimal> pemasukanDict = pemasukanData.ToDictionary(x => x.Item1, x => x.Item2);
            Dictionary<DateTime, decimal> pengeluaranDict = pengeluaranData.ToDictionary(x => x.Item1, x => x.Item2);

            // Series untuk Pemasukan dan Pengeluaran
            Series pemasukanSeries = CreateSeries("Pemasukan", System.Drawing.Color.Blue);
            Series pengeluaranSeries = CreateSeries("Pengeluaran", System.Drawing.Color.Red);

            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.Minimum = 0;
            chartArea.AxisX.Maximum = allMonths.Count;
            chartArea.AxisX.LabelStyle.Angle = -45;
            chartArea.AxisX.LabelStyle.Font = new Font("Arial", 8, FontStyle.Regular);
            chartArea.AxisX.IsMarginVisible = false;
            chartArea.AxisX.Title = "Bulan";

            int index = 0;
            foreach (var month in allMonths)
            {
                var pemasukanTuple = pemasukanData.FirstOrDefault(d => d.Item1.Year == month.Year && d.Item1.Month == month.Month);
                decimal pemasukan = pemasukanTuple != default ? pemasukanTuple.Item2 : 0;

                var pengeluaranTuple = pengeluaranData.FirstOrDefault(d => d.Item1.Year == month.Year && d.Item1.Month == month.Month);
                decimal pengeluaran = pengeluaranTuple != default ? pengeluaranTuple.Item2 : 0;

                //Debug.WriteLine($"Bulan: {month.ToString("MMM yyyy")}, Pemasukan: {pemasukan}, Pengeluaran: {pengeluaran}");

                pemasukanSeries.Points.AddXY(index, pemasukan);
                pengeluaranSeries.Points.AddXY(index, pengeluaran);

                chartArea.AxisX.CustomLabels.Add(new CustomLabel(
                    index - 0.5,
                    index + 0.5,
                    month.ToString("MMM yyyy"),
                    0,
                    LabelMarkStyle.None
                ));
                index++;
            }

            // Tambahkan Series ke Chart
            chart1.Series.Add(pemasukanSeries);
            chart1.Series.Add(pengeluaranSeries);

            chart1.Titles.Clear();
            chart1.Titles.Add("Grafik Pemasukan dan Pengeluaran (Bulanan)");
        }

        private List<DateTime> GenerateDateRange(DateTime startDate, DateTime endDate)
        {
            var dates = new List<DateTime>();
            for (var date = startDate.Date; date <= endDate; date = date.AddDays(1))
            {
                dates.Add(date);
            }
            return dates;
        }
        private Series CreateSeries(string name, System.Drawing.Color color)
        {
            return new Series(name)
            {
                ChartType = SeriesChartType.Line,
                Color = color,
                BorderWidth = 2
            };
        }

        private List<DateTime> GenerateMonthRange(DateTime startDate, DateTime endDate)
        {
            var months = new List<DateTime>();
            for (DateTime date = startDate; date <= endDate; date = date.AddMonths(1))
            {
                months.Add(new DateTime(date.Year, date.Month, 1));
            }
            return months;
        }

        private List<(DateTime, decimal)> GetChartData(NpgsqlConnection conn, string query, DateTime startDate)
        {
            var data = new List<(DateTime, decimal)>();

            using (var cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@startDate", startDate);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DateTime tanggal = reader.GetDateTime(0);
                        decimal total = reader.GetDecimal(1);
                        data.Add((tanggal, total));
                    }
                }
            }

            return data;
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            LoadChartData(); // Muat ulang data ketika radio button berubah
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}