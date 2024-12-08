using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using iText.Layout.Element;
using Npgsql;

namespace KasKu
{
    public partial class input : Form
    {
        private NpgsqlConnection conn = DatabaseHelper.GetConnection();
        private DataTable siswaTable;

        public input()
        {
            InitializeComponent();
            if (conn == null)
            {
                this.Close();
            }
            dataGridView1.AllowUserToAddRows = false;
            LoadData();
            this.Load += (s, e) => DateTimePicker_ValueChanged(null, EventArgs.Empty);
            dateTimePicker1.ValueChanged += DateTimePicker_ValueChanged;
            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
            dataGridView1.CurrentCellDirtyStateChanged += DataGridView1_CurrentCellDirtyStateChanged;
            tabControl1.SelectedIndex = 1;
            tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
            dataGridView1.ReadOnly = false;
            dataGridView1.Columns["InputAngka"].ReadOnly = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
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

        private void DataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            // Pastikan perubahan pada sel segera dicatat
            if (dataGridView1.IsCurrentCellDirty && dataGridView1.CurrentCell is DataGridViewCheckBoxCell)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["CheckBox"].Index)
            {
                // Ketika checkbox diubah
                var checkBoxCell = dataGridView1.Rows[e.RowIndex].Cells["CheckBox"] as DataGridViewCheckBoxCell;
                var inputCell = dataGridView1.Rows[e.RowIndex].Cells["InputAngka"] as DataGridViewTextBoxCell;
                inputCell.ReadOnly = false;
                bool isChecked = Convert.ToBoolean(checkBoxCell.Value);
                if (isChecked)
                {
                    inputCell.Value = ""; // Kosongkan input angka
                    inputCell.ReadOnly = true; // Nonaktifkan input
                }
                else
                {
                    inputCell.ReadOnly = false; // Aktifkan input kembali
                }
            }
        }

        private void LoadData()
        {
            // Ambil data siswa dari tabel
            string query = "SELECT id_siswa, nama_siswa FROM siswa ORDER BY nama_siswa ASC";
            using (var adapter = new NpgsqlDataAdapter(query, conn))
            {
                siswaTable = new DataTable();
                adapter.Fill(siswaTable);
                dataGridView1.Columns.Clear();

                // Konfigurasi DataGridView
                dataGridView1.DataSource = siswaTable;
                dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn { Name = "CheckBox", HeaderText = "Bayar Semua" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "InputAngka", HeaderText = "Bayar Sebagian", DefaultCellStyle = { NullValue = null }});

                //foreach (DataGridViewRow row in dataGridView1.Rows)
                //{
                //    row.Cells["InputAngka"].Value = "";
                //    row.Cells["InputAngka"].ReadOnly = false; // Default ReadOnly
                //}
            }
        }

        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value.Date;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int idSiswa = Convert.ToInt32(row.Cells["id_siswa"].Value);
                string query = @"
                SELECT bayar 
                FROM kas_masuk 
                WHERE id_siswa = @idSiswa AND tanggal_bayar = @tanggal";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idSiswa", idSiswa);
                    cmd.Parameters.AddWithValue("@tanggal", selectedDate);
                    object bayar = cmd.ExecuteScalar();

                    if (bayar != null)
                    {
                        decimal bayarValue = Convert.ToDecimal(bayar);
                        if (bayarValue == 5000)
                        {
                            row.Cells["CheckBox"].Value = true;
                            row.Cells["InputAngka"].Value = "";
                            row.Cells["InputAngka"].ReadOnly = true;
                        }
                        else
                        {
                            row.Cells["CheckBox"].Value = false;
                            row.Cells["InputAngka"].Value = bayarValue.ToString();
                            row.Cells["InputAngka"].ReadOnly = false;
                        }
                    }
                    else
                    {
                        row.Cells["CheckBox"].Value = false;
                        row.Cells["InputAngka"].Value = "";
                        row.Cells["InputAngka"].ReadOnly = false;
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["CheckBox"].Index)
            {
                var checkBoxCell = dataGridView1.Rows[e.RowIndex].Cells["CheckBox"] as DataGridViewCheckBoxCell;
                var inputCell = dataGridView1.Rows[e.RowIndex].Cells["InputAngka"] as DataGridViewTextBoxCell;

                bool isChecked = Convert.ToBoolean(checkBoxCell.Value);
                if (isChecked)
                {
                    inputCell.Value = "";
                    inputCell.ReadOnly = true;
                }
                else
                {
                    inputCell.ReadOnly = false;
                }
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                // Tanggal yang dipilih dari DateTimePicker
                DateTime selectedDate = dateTimePicker1.Value.Date;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue; // Abaikan baris baru kosong

                    // Ambil nilai dari DataGridView
                    int idSiswa = Convert.ToInt32(row.Cells["id_siswa"].Value);
                    bool isChecked = Convert.ToBoolean(row.Cells["CheckBox"].Value ?? false);
                    decimal bayar = 0;

                    if (isChecked)
                    {
                        bayar = 5000; // Default nilai jika CheckBox dicentang
                    }
                    else
                    {
                        // Ambil nilai dari InputAngka jika ada
                        decimal.TryParse(row.Cells["InputAngka"].Value?.ToString(), out bayar);
                    }

                    // Query untuk cek apakah data sudah ada
                    string checkQuery = "SELECT COUNT(*) FROM kas_masuk WHERE id_siswa = @id_siswa AND tanggal_bayar = @tanggal_bayar";
                    using (var checkCmd = new NpgsqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@id_siswa", idSiswa);
                        checkCmd.Parameters.AddWithValue("@tanggal_bayar", selectedDate);

                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            // Jika data sudah ada, gunakan UPDATE
                            string updateQuery = @"
                            UPDATE kas_masuk
                            SET bayar = @bayar
                            WHERE id_siswa = @id_siswa AND tanggal_bayar = @tanggal_bayar";
                            using (var updateCmd = new NpgsqlCommand(updateQuery, conn))
                            {
                                updateCmd.Parameters.AddWithValue("@id_siswa", idSiswa);
                                updateCmd.Parameters.AddWithValue("@tanggal_bayar", selectedDate);
                                updateCmd.Parameters.AddWithValue("@bayar", bayar);
                                updateCmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            // Jika data tidak ada, gunakan INSERT
                            string insertQuery = @"
                            INSERT INTO kas_masuk (id_siswa, tanggal_bayar, bayar)
                            VALUES (@id_siswa, @tanggal_bayar, @bayar)";
                            using (var insertCmd = new NpgsqlCommand(insertQuery, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@id_siswa", idSiswa);
                                insertCmd.Parameters.AddWithValue("@tanggal_bayar", selectedDate);
                                insertCmd.Parameters.AddWithValue("@bayar", bayar);
                                insertCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }

                MessageBox.Show("Data berhasil disimpan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DateTimePicker_ValueChanged(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}