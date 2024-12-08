using Npgsql;
using System;
using System.Windows.Forms;

//Ini untuk mendefinisikan class yang bernama DatabaseHelper
public static class DatabaseHelper
{
    // Ini adalah variabel yang bernama connString dengan tipe data string dan hanya bisa dibaca di dalam class ini (tak bisa diganti isi valuenya) dengan value yang berisi pengaturan koneksi ke supabase
    private static readonly string connString = "Host=[YOUR-HOST]; Port=[YOUR-PORT]; Username=[YOUR-USERNAME]; Password=[YOUR-PASSWORD-DATABASE]; Database=postgres; SslMode=Disable; Timeout=30; CommandTimeout=60; Trust Server Certificate=true";
    // Ini variabel yang hanya bisa dipakai di dalam class ini untuk mengambil fungsi connection di Nuget Package Manager
    private static NpgsqlConnection connection;

    // Ini disebut method yang bisa dipanggil di luar classs ini yang bernama GetConnection
    public static NpgsqlConnection GetConnection()
    {
        // try ini berfungsi untuk mencoba langsung isi di dalamnya pertama kali saat GetConnection dipanggil
        try
        {
            // jika variabel connection tidak memiliki isinya atau status koneksinya rusak maka akan mengeksekusi perintah di dalamnya
            if (connection == null || connection.State == System.Data.ConnectionState.Broken)
            {
                // mengeksekusi variabel connection untuk mendeklarasikan koneksi yang baru berdasarkan pengaturan koneksi ke supabase di variabel connString
                connection = new NpgsqlConnection(connString);
            }
            // jika koneksi status terputus maka akan mengeksekusi perintah di dalamnya
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                // mengeksekusi variabel connection untuk memulai koneksi ke supabase
                connection.Open();
            }
            // mengembalikan isi value variabel connection ke method GetConnection
            return connection;
        }
        // catch ini berfungsi untuk mengambil data error yang terjadi di parameter yang bernama Exception dan mengeksekusi perintah di dalamnya dan juga datanya disimpan ke dalam variabel yang bernama ex, walau kali ini aku tak pakai variabel ex nya untuk menampilkan isi datanya
        catch (Exception ex)
        {
            // Tampilkan pesan error tidak ada internet
            MessageBox.Show("Anda tidak terhubung dengan internet", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null; // Mengembalikan value null ke method GetConnection
        }
    }

    // Ini adalah method yang bisa dipanggil di luar class ini yang bernama CloseConnection
    public static void CloseConnection()
    {
        // Jika variabel connection memiliki isi value dan statusnya sedang terhubung ke koneksi supabase maka akan mengeksekusi perintah di dalamnya
        if (connection != null && connection.State == System.Data.ConnectionState.Open)
        {
            // Mengeksekusi variabel connection untuk memutus koneksi ke supabase
            connection.Close();
        }
    }
}
