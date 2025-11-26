using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Resevasi_Tiket_Pesawat
{
    public partial class FormVerifikasi : Form
    {
        public FormVerifikasi()
        {
            InitializeComponent();
        }

        private void button_verifikasi_tiket_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormFormulir ff = new FormFormulir();
            this.Hide(); // tutup form saat ini
            ff.Show();   // tampilkan form buat tiket
        }

        private void HapusData(string id)
        {
            string koneksi = "server=localhost;user id=root;password=;database=katasi;";
            using (MySqlConnection conn = new MySqlConnection(koneksi))
            {
                conn.Open();
                string query = "DELETE FROM tiket WHERE id = @id";
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
                string insertQuery = "INSERT INTO tiket_mati SELECT * FROM tiket WHERE id = @id";
                MySqlCommand cmdInsert = new MySqlCommand(insertQuery, conn);
                cmdInsert.Parameters.AddWithValue("@id", id);
                cmdInsert.ExecuteNonQuery();

                // 2) Hapus dari tabel asal
                string deleteQuery = "DELETE FROM tiket WHERE id = @id";
                MySqlCommand cmdDelete = new MySqlCommand(deleteQuery, conn);
                cmdDelete.Parameters.AddWithValue("@id", id);
                cmdDelete.ExecuteNonQuery();
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_tiket_id.Text))
            {
                MessageBox.Show("ID Tiket tidak terisi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_tiket_id.Focus();
                lbl_informasi.Text = "";
                return;
            }
            if (double.TryParse(textBox_tiket_id.Text, out double id))
            {
                string koneksi = "server=localhost;user id=root;password=;database=katasi;";

                using (MySqlConnection conn = new MySqlConnection(koneksi))
                {
                    conn.Open();

                    string query = "SELECT * FROM tiket WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    MySqlDataReader rd = cmd.ExecuteReader();

                    if (rd.Read())
                    {
                        // Tiket ditemukan → tampilkan ke label
                       
                        if (MessageBox.Show("Yakin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            HapusData(id.ToString());
                            lbl_informasi.Text = ""; // clear informasi selengkapnya
                        }


                    }
                    else
                    {
                        MessageBox.Show("Status: Tiket Tidak Aktif", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lbl_informasi.Text = "";
                        textBox_tiket_id.Focus();
                    }


                }
            }
            else
            {
                MessageBox.Show("ID Tiket harus angka", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_tiket_id.Focus();
                return;
            }
        }

        private void button_nonaktifkan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_tiket_id.Text))
            {
                MessageBox.Show("ID Tiket tidak terisi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_tiket_id.Focus();
                lbl_informasi.Text = "";
                return;
            }
            if (double.TryParse(textBox_tiket_id.Text, out double id))
            {
                string koneksi = "server=localhost;user id=root;password=;database=katasi;";

                using (MySqlConnection conn = new MySqlConnection(koneksi))
                {
                    conn.Open();

                    string query = "SELECT * FROM tiket WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    MySqlDataReader rd = cmd.ExecuteReader();

                    if (rd.Read())
                    {
                        // Tiket ditemukan → tampilkan ke label

                        if (MessageBox.Show("Yakin menonaktfikan data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            PindahkanBaris(id.ToString());
                            lbl_informasi.Text = ""; // clear informasi selengkapnya
                        }


                    }
                    else
                    {
                        MessageBox.Show("Status: Tiket Tidak Aktif", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lbl_informasi.Text = "";
                        textBox_tiket_id.Focus();
                    }


                }
            }
            else
            {
                MessageBox.Show("ID Tiket harus angka", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_tiket_id.Focus();
                return;
            }
        }

        private void button_cek_aktif_tiket_Click(object sender, EventArgs e)
        {
            FormTiketAktif fta = new FormTiketAktif();
            this.Hide(); // tutup form saat ini
            fta.Show();   // tampilkan form daftar tiket aktif
        }

        private void button_menu_tiket_mati_Click(object sender, EventArgs e)
        {
            FormTiketMati fm = new FormTiketMati();
            this.Hide(); // tutup form saat ini
            fm.Show();   // tampilkan form daftar tiket mati
        }

        private void FormVerifikasi_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e) // ketika gambar tombolverifikasi diklik
        {
            if (string.IsNullOrWhiteSpace(textBox_tiket_id.Text)) // jika textBox_tiket_id.Text kosong
            {
                MessageBox.Show("ID Tiket tidak terisi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // msgbox error
                textBox_tiket_id.Focus(); // fokus ke textBox_tiket_id
                lbl_informasi.Text = ""; // kosongkan lbl_informasi.Text
                return; // berhentikan program
            }
            if (double.TryParse(textBox_tiket_id.Text, out double id)) // jika textBox_tiket_id.Text adalah double masukkan ke var id
            {
                string koneksi = "server=localhost;user id=root;password=;database=katasi;"; // server, userid, password, dan nama database 

                using (MySqlConnection conn = new MySqlConnection(koneksi)) // koneksi database
                {
                    conn.Open(); // buka database

                    string query = "SELECT * FROM tiket WHERE id = @id"; // perintah sql
                    MySqlCommand cmd = new MySqlCommand(query, conn); // var command sql
                    cmd.Parameters.AddWithValue("@id", id); // menambahkan parameter ke perintah sql

                    MySqlDataReader rd = cmd.ExecuteReader(); // eksekusi cmd sql

                    if (rd.Read()) // jika terbaca
                    {
                        // Tiket ditemukan → tampilkan ke label
                        MessageBox.Show("Status: Tiket Aktif", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lbl_informasi.Text = ""; // kosongkan lbl_informasi.Text
                        lbl_informasi.Text += "# Tiket ID: ";
                        lbl_informasi.Text += rd["id"].ToString() ?? ""; // isi dari kolom databases
                        lbl_informasi.Text += "\n\n# Informasi Pribadi";
                        lbl_informasi.Text += "\n • Nama Kontak: ";
                        lbl_informasi.Text += rd["nama_kontak"].ToString() ?? ""; // isi dari kolom databases
                        lbl_informasi.Text += "\n • Tanggal lahir: ";
                        lbl_informasi.Text += rd["tanggal_lahir"].ToString() ?? ""; // isi dari kolom databases
                        lbl_informasi.Text += "\n • E-mail: ";
                        lbl_informasi.Text += rd["email"].ToString() ?? ""; // isi dari kolom databases
                        lbl_informasi.Text += "\n • No. Telp: ";
                        lbl_informasi.Text += rd["no_telp"].ToString() ?? ""; // isi dari kolom databases

                        lbl_informasi.Text += "\n\n# Detail Perjalanan";
                        lbl_informasi.Text += "\n • Negara Keberangkatan: ";
                        lbl_informasi.Text += rd["negara_keberangkatan"].ToString() ?? ""; // isi dari kolom databases
                        lbl_informasi.Text += "\n • Negara Tujuan: ";
                        lbl_informasi.Text += rd["negara_tujuan"].ToString() ?? ""; // isi dari kolom databases
                        lbl_informasi.Text += "\n • Tanggal dan Waktu Keberangkatan: ";
                        lbl_informasi.Text += rd["tanggal_waktu_keberangkatan"].ToString() ?? ""; // isi dari kolom databases
                        lbl_informasi.Text += "\n • Kelas Layanan: ";
                        lbl_informasi.Text += rd["kelas_layanan"].ToString() ?? ""; // isi dari kolom databases
                        lbl_informasi.Text += "\n • Layanan Lainnya: ";
                        lbl_informasi.Text += rd["layanan_lainnya"].ToString() ?? ""; // isi dari kolom databases

                        lbl_informasi.Text += "\n\n# Rincian Perjalanan";
                        if (!string.IsNullOrEmpty(rd["hotel_pilihan"].ToString())) // jika kolom hotel_pilihan dari database kosong
                        {
                            lbl_informasi.Text += "\n • Hotel Pilihan: ";
                            lbl_informasi.Text += rd["hotel_pilihan"].ToString() ?? "";  // isi dari kolom databases
                        }
                        lbl_informasi.Text += "\n • Penerbangan Pilihan: ";
                        lbl_informasi.Text += rd["penerbangan_pilihan"].ToString() ?? "";  // isi dari kolom databases
                        lbl_informasi.Text += "\n • Informasi Tambahan: ";
                        lbl_informasi.Text += rd["informasi_tambahan"].ToString() ?? "";  // isi dari kolom databases
                        lbl_informasi.Text += "\n • Harga Tiket: ";
                        lbl_informasi.Text += "Rp. " + FormatMoney(Convert.ToInt32(rd["harga_tiket"])); // isi dari kolom databases lalu format ke money


                    }
                    else
                    {
                        MessageBox.Show("Status: Tiket Tidak Aktif", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lbl_informasi.Text = ""; // kosongkan lbl_informasi.Text 
                        textBox_tiket_id.Focus(); // fokus ke textBox_tiket_id
                    }


                }
            }
            else
            {
                MessageBox.Show("ID Tiket harus angka", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_tiket_id.Focus(); // fokus ke textBox_tiket_id
                return; // berhentikan program
            }
        }

        public static string FormatMoney(int angka)
        {
            return angka.ToString("#,0").Replace(",", ".");
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            FormFormulir ff = new FormFormulir();
            this.Hide(); // tutup form saat ini
            ff.Show();   // tampilkan form buat tiket
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_tiket_id.Text))
            {
                MessageBox.Show("ID Tiket tidak terisi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_tiket_id.Focus();
                lbl_informasi.Text = "";
                return;
            }
            if (double.TryParse(textBox_tiket_id.Text, out double id))
            {
                string koneksi = "server=localhost;user id=root;password=;database=katasi;";

                using (MySqlConnection conn = new MySqlConnection(koneksi))
                {
                    conn.Open();

                    string query = "SELECT * FROM tiket WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    MySqlDataReader rd = cmd.ExecuteReader();

                    if (rd.Read())
                    {
                        // Tiket ditemukan → tampilkan ke label

                        if (MessageBox.Show("Yakin menonaktfikan data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            PindahkanBaris(id.ToString());
                            lbl_informasi.Text = ""; // clear informasi selengkapnya
                        }


                    }
                    else
                    {
                        MessageBox.Show("Status: Tiket Tidak Aktif", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lbl_informasi.Text = "";
                        textBox_tiket_id.Focus();
                    }


                }
            }
            else
            {
                MessageBox.Show("ID Tiket harus angka", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_tiket_id.Focus();
                return;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_tiket_id.Text))
            {
                MessageBox.Show("ID Tiket tidak terisi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_tiket_id.Focus();
                lbl_informasi.Text = "";
                return;
            }
            if (double.TryParse(textBox_tiket_id.Text, out double id))
            {
                string koneksi = "server=localhost;user id=root;password=;database=katasi;";

                using (MySqlConnection conn = new MySqlConnection(koneksi))
                {
                    conn.Open();

                    string query = "SELECT * FROM tiket WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    MySqlDataReader rd = cmd.ExecuteReader();

                    if (rd.Read())
                    {
                        // Tiket ditemukan → tampilkan ke label

                        if (MessageBox.Show("Yakin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            HapusData(id.ToString());
                            lbl_informasi.Text = ""; // clear informasi selengkapnya
                        }


                    }
                    else
                    {
                        MessageBox.Show("Status: Tiket Tidak Aktif", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lbl_informasi.Text = "";
                        textBox_tiket_id.Focus();
                    }


                }
            }
            else
            {
                MessageBox.Show("ID Tiket harus angka", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_tiket_id.Focus();
                return;
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            FormTiketAktif fta = new FormTiketAktif();
            this.Hide(); // tutup form saat ini
            fta.Show();   // tampilkan form daftar tiket aktif
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            FormTiketMati fm = new FormTiketMati();
            this.Hide(); // tutup form saat ini
            fm.Show();   // tampilkan form daftar tiket mati
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            FormMenu fm = new FormMenu();
            this.Hide(); // tutup form saat ini
            fm.Show();   // tampilkan form menu
        }

        private void lbl_informasi_Click(object sender, EventArgs e)
        {

        }

        private void gb_informasi_tbhan_Enter(object sender, EventArgs e)
        {

        }
    }
}
