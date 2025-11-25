using MySql.Data.MySqlClient; // tambahan NuGet Packages, untuk include MySQL
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Program hampir mirip seperti dengan* FormTiketAktif, hanya saja
// disini kita yang awalnya dari aktif ke mati, sekarang dari mati ke aktif.

namespace Resevasi_Tiket_Pesawat
{
    public partial class FormTiketMati : Form
    {
        public FormTiketMati()
        {
            InitializeComponent();
        }

        private void button_to_tiket_aktif_Click(object sender, EventArgs e)
        {
            FormTiketAktif fta = new FormTiketAktif();
            this.Hide(); // tutup form saat ini
            fta.Show();   // tampilkan form daftar tiket aktif
        }

        private void FormTiketMati_Load(object sender, EventArgs e)
        {
            TampilkanData(); // refresh datagrid
        }

        private void TampilkanData()
        {
            string koneksi = "server=localhost;user id=root;password=;database=katasi;";
            MySqlConnection conn = new MySqlConnection(koneksi);
            conn.Open();

            // 1. Hitung total baris dulu
            MySqlCommand countCmd = new MySqlCommand("SELECT COUNT(*) FROM tiket_mati", conn);
            int total = Convert.ToInt32(countCmd.ExecuteScalar());

            // Set progress bar
            progressBar1.Value = 0;
            progressBar1.Maximum = total;
            progressBar1.Visible = true;

            // 2. Ambil data

            string query = "SELECT * FROM tiket_mati";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader rd = cmd.ExecuteReader();

            dataGrid_active_ticket.Rows.Clear(); // menghapus isi lama
            while (rd.Read())
            {
                // Tambahkan row baru
                dataGrid_active_ticket.Rows.Add(
                    rd["id"].ToString(),
                    rd["nama_kontak"].ToString(),
                    rd["tanggal_lahir"].ToString(),
                    rd["email"].ToString(),
                    rd["no_telp"].ToString(),
                    rd["negara_keberangkatan"].ToString(),
                    rd["negara_tujuan"].ToString(),
                    rd["tanggal_waktu_keberangkatan"].ToString(),
                    rd["kelas_layanan"].ToString(),
                    rd["layanan_lainnya"].ToString(),
                    rd["hotel_pilihan"].ToString(),
                    rd["penerbangan_pilihan"].ToString(),
                    rd["informasi_tambahan"].ToString(),
                    rd["harga_tiket"].ToString()
                );

                // 3. Update progress setiap baris
                if (progressBar1.Value < progressBar1.Maximum)
                    progressBar1.Value++;
            }

            rd.Close();
            conn.Close();

            // 4. Sembunyikan progress bar setelah selesai
            progressBar1.Visible = false;
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            
        }

        private void HapusData(string id)
        {
            string koneksi = "server=localhost;user id=root;password=;database=katasi;";
            using (MySqlConnection conn = new MySqlConnection(koneksi))
            {
                conn.Open();
                string query = "DELETE FROM tiket_mati WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
        private void PindahkanBaris(string id)
        {
            string koneksi = "server=localhost;user id=root;password=;database=katasi;";
            using (MySqlConnection conn = new MySqlConnection(koneksi))
            {
                conn.Open();

                // 1) Insert ke tabel tujuan
                string insertQuery = "INSERT INTO tiket SELECT * FROM tiket_mati WHERE id = @id";
                MySqlCommand cmdInsert = new MySqlCommand(insertQuery, conn);
                cmdInsert.Parameters.AddWithValue("@id", id);
                cmdInsert.ExecuteNonQuery();

                // 2) Hapus dari tabel asal
                string deleteQuery = "DELETE FROM tiket_mati WHERE id = @id";
                MySqlCommand cmdDelete = new MySqlCommand(deleteQuery, conn);
                cmdDelete.Parameters.AddWithValue("@id", id);
                cmdDelete.ExecuteNonQuery();
            }
        }

        private void button_nonaktifkan_Click(object sender, EventArgs e)
        {
            
        }

        private void button_back_to_form_Click(object sender, EventArgs e)
        {
            
        }

        private void button_informasi_tambahan_Click(object sender, EventArgs e)
        {
            
        }

        private void button_refresh_Click_1(object sender, EventArgs e)
        {
            TampilkanData();
        }

        private void button_aktifkan_Click(object sender, EventArgs e)
        {
            if (dataGrid_active_ticket.CurrentRow == null)
            {
                MessageBox.Show("Tidak ada baris yang dipilih.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string id = dataGrid_active_ticket.CurrentRow.Cells["Column_ID"].Value.ToString();

            if (MessageBox.Show("Pindahkan data ini ke Daftar Tiket Aktif?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                PindahkanBaris(id);
                TampilkanData(); // refresh datagrid
                lbl_informasi.Text = ""; // clear informasi selengkapnya
            }
        }

        private void button_delete_Click_1(object sender, EventArgs e)
        {
            if (dataGrid_active_ticket.CurrentRow == null)
            {
                MessageBox.Show("Tidak ada baris yang dipilih.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string id = dataGrid_active_ticket.CurrentRow.Cells["Column_ID"].Value.ToString();

            if (MessageBox.Show("Yakin hapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                HapusData(id);
                TampilkanData(); // Refresh datagrid
                lbl_informasi.Text = ""; // clear informasi selengkapnya
            }
        }

        private void button_back_to_form_Click_1(object sender, EventArgs e)
        {
            FormFormulir ff = new FormFormulir();
            this.Hide(); // tutup form saat ini
            ff.Show();   // tampilkan form buat tiket
        }

        private void button_informasi_tambahan_Click_1(object sender, EventArgs e)
        {
            
        }

        private void lbl_informasi_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (dataGrid_active_ticket.CurrentRow != null)
            {
                lbl_informasi.Text = "";
                lbl_informasi.Text += "# Tiket ID: ";
                lbl_informasi.Text += dataGrid_active_ticket.CurrentRow.Cells["Column_ID"].Value?.ToString() ?? "";
                lbl_informasi.Text += "\n\n# Informasi Pribadi";
                lbl_informasi.Text += "\n • Nama Kontak: ";
                lbl_informasi.Text += dataGrid_active_ticket.CurrentRow.Cells["Column_Nama_Kontak"].Value?.ToString() ?? "";
                lbl_informasi.Text += "\n • Tanggal lahir: ";
                lbl_informasi.Text += dataGrid_active_ticket.CurrentRow.Cells["Column_TTL"].Value?.ToString() ?? "";
                lbl_informasi.Text += "\n • E-mail: ";
                lbl_informasi.Text += dataGrid_active_ticket.CurrentRow.Cells["Column_Email"].Value?.ToString() ?? "";
                lbl_informasi.Text += "\n • No. Telp: ";
                lbl_informasi.Text += dataGrid_active_ticket.CurrentRow.Cells["Column_Nomor_Telp"].Value?.ToString() ?? "";

                lbl_informasi.Text += "\n\n# Detail Perjalanan";
                lbl_informasi.Text += "\n • Negara Keberangkatan: ";
                lbl_informasi.Text += dataGrid_active_ticket.CurrentRow.Cells["Column_Negara_Keberangkatan"].Value?.ToString() ?? "";
                lbl_informasi.Text += "\n • Negara Tujuan: ";
                lbl_informasi.Text += dataGrid_active_ticket.CurrentRow.Cells["Column_Negara_Tujuan"].Value?.ToString() ?? "";
                lbl_informasi.Text += "\n • Tanggal dan Waktu Keberangkatan: ";
                lbl_informasi.Text += dataGrid_active_ticket.CurrentRow.Cells["Column_Tanggal_Waktu_Berangkat"].Value?.ToString() ?? "";
                lbl_informasi.Text += "\n • Kelas Layanan: ";
                lbl_informasi.Text += dataGrid_active_ticket.CurrentRow.Cells["Column_Kelas_Layanan"].Value?.ToString() ?? "";
                lbl_informasi.Text += "\n • Layanan Lainnya: ";
                lbl_informasi.Text += dataGrid_active_ticket.CurrentRow.Cells["Column_Layanan"].Value?.ToString() ?? "";

                lbl_informasi.Text += "\n\n# Rincian Perjalanan";
                if (!string.IsNullOrEmpty(dataGrid_active_ticket.CurrentRow.Cells["Column_Nama_Hotel"].Value?.ToString()))
                {
                    lbl_informasi.Text += "\n • Hotel Pilihan: ";
                    lbl_informasi.Text += dataGrid_active_ticket.CurrentRow.Cells["Column_Nama_Hotel"].Value?.ToString() ?? "";
                }
                lbl_informasi.Text += "\n • Penerbangan Pilihan: ";
                lbl_informasi.Text += dataGrid_active_ticket.CurrentRow.Cells["Column_Penerbangan"].Value?.ToString() ?? "";
                lbl_informasi.Text += "\n • Informasi Tambahan: ";
                lbl_informasi.Text += dataGrid_active_ticket.CurrentRow.Cells["Column_Informasi_Tambahan"].Value?.ToString() ?? "";
                lbl_informasi.Text += "\n • Harga Tiket: ";
                lbl_informasi.Text += "Rp. " + FormatMoney(Convert.ToInt32(dataGrid_active_ticket.CurrentRow.Cells["Total_Harga"].Value));
            }
            else
            {
                MessageBox.Show("Pilih baris tiket yang ingin anda lihat informasi tambahannya", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string FormatMoney(int angka)
        {
            return angka.ToString("#,0").Replace(",", ".");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            TampilkanData();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (dataGrid_active_ticket.CurrentRow == null)
            {
                MessageBox.Show("Tidak ada baris yang dipilih.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string id = dataGrid_active_ticket.CurrentRow.Cells["Column_ID"].Value.ToString();

            if (MessageBox.Show("Pindahkan data ini ke Daftar Tiket Aktif?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                PindahkanBaris(id);
                TampilkanData(); // refresh datagrid
                lbl_informasi.Text = ""; // clear informasi selengkapnya
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (dataGrid_active_ticket.CurrentRow == null)
            {
                MessageBox.Show("Tidak ada baris yang dipilih.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string id = dataGrid_active_ticket.CurrentRow.Cells["Column_ID"].Value.ToString();

            if (MessageBox.Show("Yakin hapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                HapusData(id);
                TampilkanData(); // Refresh datagrid
                lbl_informasi.Text = ""; // clear informasi selengkapnya
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            FormTiketAktif fta = new FormTiketAktif();
            this.Hide(); // tutup form saat ini
            fta.Show();   // tampilkan form daftar tiket aktif
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            FormFormulir ff = new FormFormulir();
            this.Hide(); // tutup form saat ini
            ff.Show();   // tampilkan form buat tiket
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            FormMenu fm = new FormMenu();
            this.Hide(); // tutup form saat ini
            fm.Show();   // tampilkan form menu
        }

        private void dataGrid_active_ticket_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
