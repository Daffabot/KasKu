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
    public partial class transaksi : Form
    {
        private NpgsqlConnection conn = DatabaseHelper.GetConnection();
        public transaksi()
        {
            InitializeComponent();
            if (conn == null)
            {
                this.Close();
            }
            tabControl1.SelectedIndex = 4;
            tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
            dateTimePickerBulan.ValueChanged += dateTimePickerBulan_ValueChanged;
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

        private void transaksi_Load(object sender, EventArgs e)
        {
            // Set format DateTimePicker ke MM/yyyy
            dateTimePickerBulan.CustomFormat = "MM/yyyy";
            dateTimePickerBulan.Format = DateTimePickerFormat.Custom;

            // Load data awal
            LoadDataGridView();
        }

        private void dateTimePickerBulan_ValueChanged(object sender, EventArgs e)
        {
            // Load data saat nilai DateTimePicker berubah
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            // Ambil bulan dan tahun dari DateTimePicker
            DateTime selectedDate = dateTimePickerBulan.Value;
            int selectedMonth = selectedDate.Month;
            int selectedYear = selectedDate.Year;

            string query = @"
                SELECT 
                    id_pengeluaran, 
                    nama_barang, 
                    jumlah_barang, 
                    harga_satuan, 
                    tanggal_pengeluaran
                FROM pengeluaran
                WHERE EXTRACT(MONTH FROM tanggal_pengeluaran) = @month
                  AND EXTRACT(YEAR FROM tanggal_pengeluaran) = @year";

            DataTable table = new DataTable();
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("month", selectedMonth);
                cmd.Parameters.AddWithValue("year", selectedYear);

                using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                {
                    adapter.Fill(table);
                }
            }

            // Set hasil query ke DataGridView
            dataGridViewPengeluaran.DataSource = table;

            // Konfigurasi kolom DataGridView (opsional)
            if (dataGridViewPengeluaran.Columns.Count > 0)
            {
                dataGridViewPengeluaran.Columns["id_pengeluaran"].HeaderText = "ID";
                dataGridViewPengeluaran.Columns["nama_barang"].HeaderText = "Penggunaan";
                dataGridViewPengeluaran.Columns["jumlah_barang"].HeaderText = "Kuantitas";
                dataGridViewPengeluaran.Columns["harga_satuan"].HeaderText = "Harga Satuan";
                dataGridViewPengeluaran.Columns["tanggal_pengeluaran"].HeaderText = "Tanggal";
                dataGridViewPengeluaran.Columns["tanggal_pengeluaran"].DefaultCellStyle.Format = "yyyy-MM-dd";
            }
        }

        private void addTrans_Click(object sender, EventArgs e)
        {
            TambahPengeluaran form6 = new TambahPengeluaran();
            form6.Show();
            this.Hide();
        }
    }
}
