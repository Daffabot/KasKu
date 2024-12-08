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
    public partial class pelunasan : Form
    {
        private NpgsqlConnection conn = DatabaseHelper.GetConnection();
        public pelunasan()
        {
            InitializeComponent();
            if (conn == null)
            {
                this.Close();
            }
            tabControl1.SelectedIndex = 3;
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

        private void pelunasan_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            string query = @"
                SELECT 
                    s.id_siswa, 
                    s.nama_siswa,
                    SUM(CASE 
                        WHEN km.bayar = 0 THEN 5000 
                        WHEN km.bayar < 5000 THEN 5000 - km.bayar 
                        ELSE 0 
                    END) AS total_belum_bayar
                FROM siswa s
                LEFT JOIN kas_masuk km ON s.id_siswa = km.id_siswa
                GROUP BY s.id_siswa, s.nama_siswa
                HAVING SUM(CASE 
                    WHEN km.bayar = 0 THEN 5000 
                    WHEN km.bayar < 5000 THEN 5000 - km.bayar 
                    ELSE 0 
                END) > 0";

            DataTable table = new DataTable();
            using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, conn))
            {
                adapter.Fill(table);
            }

            dataGridViewPelunasan.DataSource = table;

            // Tambahkan kolom Bayar Semua dan Bayar Sebagian
            if (!dataGridViewPelunasan.Columns.Contains("Bayar Semua"))
            {
                var checkColumn = new DataGridViewCheckBoxColumn
                {
                    Name = "Bayar Semua",
                    HeaderText = "Bayar Semua",
                    Width = 100
                };
                dataGridViewPelunasan.Columns.Add(checkColumn);
            }

            if (!dataGridViewPelunasan.Columns.Contains("Bayar Sebagian"))
            {
                var inputColumn = new DataGridViewTextBoxColumn
                {
                    Name = "Bayar Sebagian",
                    HeaderText = "Bayar Sebagian",
                    Width = 100
                };
                dataGridViewPelunasan.Columns.Add(inputColumn);
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            using (NpgsqlTransaction transaction = conn.BeginTransaction())
            {
                try
                {
                    foreach (DataGridViewRow row in dataGridViewPelunasan.Rows)
                    {
                        if (row.IsNewRow) continue;

                        int idSiswa = Convert.ToInt32(row.Cells["id_siswa"].Value);
                        bool bayarSemua = Convert.ToBoolean(row.Cells["Bayar Semua"].Value ?? false);
                        string bayarSebagianStr = row.Cells["Bayar Sebagian"].Value?.ToString();
                        decimal bayarSebagian = 0;
                        decimal.TryParse(bayarSebagianStr, out bayarSebagian);

                        if (bayarSemua)
                        {
                            // Update semua baris untuk id_siswa menjadi 5000
                            string updateQuery = @"
                                UPDATE kas_masuk
                                SET bayar = 5000
                                WHERE id_siswa = @id_siswa AND bayar < 5000";

                            using (NpgsqlCommand cmd = new NpgsqlCommand(updateQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("id_siswa", idSiswa);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else if (bayarSebagian > 0)
                        {
                            // Update sebagian
                            string selectQuery = @"
                                SELECT id_kas_masuk, bayar 
                                FROM kas_masuk
                                WHERE id_siswa = @id_siswa AND bayar < 5000
                                ORDER BY tanggal_bayar ASC";

                            var rowsToUpdate = new List<(int IdKasMasuk, decimal Sisa)>();
                            using (NpgsqlCommand selectCmd = new NpgsqlCommand(selectQuery, conn, transaction))
                            {
                                selectCmd.Parameters.AddWithValue("id_siswa", idSiswa);
                                using (NpgsqlDataReader reader = selectCmd.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        int idKasMasuk = reader.GetInt32(0);
                                        decimal sisaBayar = 5000 - reader.GetDecimal(1);
                                        rowsToUpdate.Add((idKasMasuk, sisaBayar));
                                    }
                                }
                            }

                            foreach (var (idKasMasuk, sisa) in rowsToUpdate)
                            {
                                if (bayarSebagian <= 0) break;

                                decimal bayar = Math.Min(bayarSebagian, sisa);
                                bayarSebagian -= bayar;

                                string updateQuery = @"
                                    UPDATE kas_masuk
                                    SET bayar = bayar + @bayar
                                    WHERE id_kas_masuk = @id_kas_masuk";

                                using (NpgsqlCommand updateCmd = new NpgsqlCommand(updateQuery, conn, transaction))
                                {
                                    updateCmd.Parameters.AddWithValue("bayar", bayar);
                                    updateCmd.Parameters.AddWithValue("id_kas_masuk", idKasMasuk);
                                    updateCmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }

                    transaction.Commit();
                    MessageBox.Show("Data berhasil disimpan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
