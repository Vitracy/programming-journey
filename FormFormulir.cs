using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // tambahan NuGet Packages, untuk include MySQL

namespace Resevasi_Tiket_Pesawat
{
    public partial class FormFormulir : Form
    {
        string[] namaTiket = new string[] { "Ekonomi", "Ekonomi Premium", "Bisnis", "Kelas Utama (First Class)" }; // menginisialisasi nama dari tiket
        int[] hargaTiket = new int[] { 500000, 1000000, 1500000, 2000000 }; // menginisialisasi harga dari tiket
        string[] namaPenerbangan = new string[] { "Indonesia", "Citilink", "Lion Air", "Batik Air", "AirAsia" };

        public FormFormulir()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e) // ketika form di load
        {
            for (int i = 0; i < namaTiket.Length; i++) // melakukan pengulangan sebanyak total item di array naamaa tiket
            {
                comboBox_kelas_layanan.Items.Add($"{namaTiket[i]} | Rp. {FormatMoney(hargaTiket[i])}"); // menambahkan pilihan ke comboBox_kelas_layanan.Items dengan array nama dan harga tiket index (i)
            }
            if(namaPenerbangan.Length > 0) // jika array namaPenerbangan item nya lebih dari 0
            {
                int totalnamaPenerbangan = 0; // set jumlah awal 0
                do // lakukan sekali
                {
                    comboBox_penerbangan.Items.Add($"{namaPenerbangan[totalnamaPenerbangan]}"); // tambahkan pilihan di comboBox_penerbangan.Items sesuai index dari array namaPenerbangan
                    totalnamaPenerbangan++; // tambah 1
                }
                while (totalnamaPenerbangan < namaPenerbangan.Length); // jika masih kurang dari jumlah nama penerbangan ulangi lagi
                
            }
        }

        public static string FormatRupiah(decimal angka) // fungsi format angka ke rupiah
        {
            return angka.ToString("C", new System.Globalization.CultureInfo("id-ID")); // menyesuaikan dengan mata uang indonesia
        }

        public static string FormatMoney(decimal angka) // fungsi dari angka ke digit uang
        {
            return angka.ToString("#,0").Replace(",", "."); // mengganti nilai menjadi ada koma dari setiap 3 digit lalu diubah lagi menjadi titik.
        }

        
        

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (!checkBox_akomodasi_hotel.Checked && !string.IsNullOrEmpty(textBox_nama_hotel_pilihan.Text)) // memeriksa apakah pengguna memilih akomodasi hotel
            {
                textBox_nama_hotel_pilihan.Clear(); // membersihkan textBox_nama_hotel_pilihan
                MessageBox.Show("Anda tidak memilih layanan Akomodasi Hotel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // message box error ditampilkan
            }
        }

        private bool IsValidEmail(string email) // fungsi untuk mendeteksi apakah suatu string adalah email yang valid
        {
            if (string.IsNullOrWhiteSpace(email)) // jika email kosong
                return false;

            // Pola regex sederhana dan umum digunakan
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"; // mendeteksi apakah ada char '@' dan char '.'

            return Regex.IsMatch(email, pattern); // jika ada lanjut return, nilai true
        }

        private void btn_kirim_formulir_Click(object sender, EventArgs e) // jika tombol kirim di klik
        {
            bool invalid = false; // variable bool, untuk menjadi saklar, apakah invalid atau tidak
            string nama = txtBox_nama.Text; //  variable nama diset ke txtBox_nama.Text
            if (string.IsNullOrWhiteSpace(nama)) //mendeteki apakah variable "nama" kosong
            {
                MessageBox.Show("Nama kontak tidak terisi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); invalid = true; // invalid menjadi true
                txtBox_nama.Focus(); //focus ke txtBox_nama
                return; // berhentikan program
            }
            

            string ttl = dateTime_ttl.Text; // variable ttl diset ke dateTime_ttl.Text

            string email = textBox_email.Text; // variable email diset ke textBox_email.Text
            if (!IsValidEmail(email)) // mendeteksi apakah variable "mail" adalah email yang valid
            {
                MessageBox.Show("Email tidak valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); invalid = true; // invalid menjadi true
                textBox_email.Focus(); // fokus ke textBox_email
                return; // berhentikan program
            }

            if (combo_nomor_negara.SelectedIndex == -1) // jika pengguna tidak memilih combo_nomor_negara
            {
                MessageBox.Show("Nomor negara tidak dipilih", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); invalid = true; // invalid menjadi true
                combo_nomor_negara.Focus(); // fokus ke combo_nomor_negara
                return; // berhentikan program
            }

            string nomor_negara = combo_nomor_negara.SelectedItem?.ToString(); // mengeset variable nomor_negara ke combo_nomor_negara.SelectedItem yang diubah dulu menjadi string.

            if (int.TryParse(textBox_nomor_telepon.Text, out int nomor_telepon)) // mendeteksi kalau textBox_nomor_telepon.Text adalah angka, dan dimasukkan ke var nomor_telepon
            {
                nomor_negara += $", {nomor_telepon}"; // menggabungkan nomor_negara dengan nomor telepon
            }
            else // jika textBox_nomor_telepon.Text tidak angka
            {
                MessageBox.Show("Nomor telepon tidak valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); invalid = true; // invalid menjadi true
                textBox_nomor_telepon.Focus(); // fokus ke textBox_nomor_telepon
                return; //berhentikan program
            }

            string negara_keberangkatan = txtBox_keberangkatan.Text; // mengeset var negara_keberangkatan ke txtBox_keberangkatan.Text
            if (string.IsNullOrWhiteSpace(negara_keberangkatan)) // jika var negara_keberangkatan kosong
            {
                MessageBox.Show("Negara keberangkatan tidak terisi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); invalid = true; // invalid menjadi true
                txtBox_keberangkatan.Focus(); // fokus ke txtBox_keberangkatan
                return; // berhentikan program
            }

            string negara_tujuan = txtBox_tujuan.Text; // mengeset var negara_tujuan ke txtBox_tujuan.Text
            if (string.IsNullOrWhiteSpace(negara_tujuan)) // jika negara_tujuan kosong
            {
                MessageBox.Show("Negara tujuan tidak terisi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); invalid = true; // invalid menjadi true
                txtBox_tujuan.Focus(); // fokus ke txtBox_tujuan
                return; // berhentikan program
            }

            string tanggal_berangkat = $"{dateTime_keberangkatan.Text}, {maskedTextBox_waktu_berangkat.Text}"; // var tanggal_berangkat di set menjadi gabungan dateTime_keberangkatan.Text dengan maskedTextBox_waktu_berangkat.Text

            string input_berangkat = maskedTextBox_waktu_berangkat.Text; // var input_berangkat diset ke maskedTextBox_waktu_berangkat.Text

            // Pastikan user sudah isi lengkap (misal "14:30")
            if (!maskedTextBox_waktu_berangkat.MaskCompleted) // jika maskedTextBox_waktu_berangkat tidak diisi penuh
            {
                MessageBox.Show("Input waktu berangkat belum lengkap! Format: HH:mm",
                                "Validasi Waktu", MessageBoxButtons.OK, MessageBoxIcon.Warning); // message box warning ditampilkan
                maskedTextBox_waktu_berangkat.Focus(); // fokus ke maskedTextBox_waktu_berangkat
                invalid = true; // invalid menjadi true
                return; // berhentikan program
            }



            // Coba parse input jadi DateTime
            if (DateTime.TryParseExact(input_berangkat, "HH:mm",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out DateTime waktu))
            {

            }
            else
            {
                // ❌ Jika tidak valid
                MessageBox.Show("Waktu berangkat tidak valid! Gunakan format HH:mm (contoh: 14:30)",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // message box warning ditampilkan
                maskedTextBox_waktu_berangkat.Focus(); // fokus ke maskedTextBox_waktu_berangkat
                invalid = true; // invalid menjadi true
                return; // berhentikan program
            }


            if (comboBox_kelas_layanan.SelectedIndex == -1) // jika comboBox_kelas_layanan tidak dipilih
            {
                MessageBox.Show("Kelas layanan tidak dipilih", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); invalid = true; // invalid menjadi true
                comboBox_kelas_layanan.Focus(); // fokus ke comboBox_kelas_layanan;
                return; // program dihentikan
            }


            string kelas_layanan = ""; // membuat var kelas_layanan dengan tidak ada isinya

            

            switch (comboBox_kelas_layanan.SelectedIndex) // membuat pilihan dari comboBox_kelas_layanan.SelectedIndex
            {
                case 0:
                    kelas_layanan = "Ekonomi"; // kelas layanan di ubah
                    break;
                case 1:
                    kelas_layanan = "Ekonomi Premium"; // kelas layanan di ubah
                    break;
                case 2:
                    kelas_layanan = "Bisnis"; // kelas layanan di ubah
                    break;
                case 3:
                    kelas_layanan = "Kelas Utama (First Class)"; // kelas layanan di ubah
                    break;
                default:
                    break;
            }

            
            string layanan = ""; //  var layanan dengan isi kosong
            if(checkBox_tiket_maskapai.Checked) // jika checkBox_tiket_maskapai dipilih
            {
                layanan += "Tiket Maskapai Penerbangan"; // menambahkan pilihana ke var layanan
            }
            if (checkBox_rent_car.Checked) // jika checkBox_rent_car dipilih
            {
                layanan += ", Rental Mobil"; // menambahkan pilihana ke var layanan
            }
            if (checkBox_akomodasi_hotel.Checked) // jika checkBox_akomodasi_hotel dipilih
            {
                layanan += ", Akomodasi Hotel"; // menambahkan pilihana ke var layanan
            }

            string hotel_pilihan = textBox_nama_hotel_pilihan.Text; // set var hotel_pilihan ke textBox_nama_hotel_pilihan.Text
            if (string.IsNullOrWhiteSpace(hotel_pilihan) && checkBox_akomodasi_hotel.Checked) // jika var hotel_pilihan kosong namun checkBox_akomodasi_hotel dipilih
            {
                MessageBox.Show("Nama hotel untuk akomodasi tidak terisi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); invalid = true; // invalid menjadi true
                textBox_nama_hotel_pilihan.Focus(); // fokus ke textBox_nama_hotel_pilihan
                return; // berhentikan program
            }
            if (!string.IsNullOrEmpty(hotel_pilihan) && !checkBox_akomodasi_hotel.Checked) // jika var hotel_pilihan tidak kosong namun checkBox_akomodasi_hotel tidak dipilih
            {
                textBox_nama_hotel_pilihan.Focus(); // fokus ke textBox_nama_hotel_pilihan
                MessageBox.Show("Anda tidak mencentang layanan Akomodasi Hotel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); invalid = true; // invalid menjadi true
                return; // berhentikan program
            }
            string penerbangan_pilihan = comboBox_penerbangan.Text; // set var penerbangan_pilihan ke comboBox_penerbangan.Text
            if (string.IsNullOrWhiteSpace(penerbangan_pilihan)) // jika var penerbangan_pilihan kosong
            {
                MessageBox.Show("Penerbangan pilihan tidak terisi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); invalid = true; // invalid menjadi true
                comboBox_penerbangan.Focus(); // fokus ke comboBox_penerbangan;
                return; // berhentikan program
            }
            string informasi_tambahan = textBox_informasi_tambahan.Text; //set var informasi_tambahan ke textBox_informasi_tambahan.Text








            int harga = 0; // mendefinisikan awal harga menjadi 0

            // tiket default (ekonomi, ekonomi premium, bisnis, kelas atas)
            if (comboBox_kelas_layanan.SelectedIndex == 0) // jika comboBox_kelas_layanan dipilih index 0
            {
                harga = hargaTiket[0]; // var harga diubah menyesuaikan dengan array hargaTiket index 0

            }
            else if (comboBox_kelas_layanan.SelectedIndex == 1) // jika tidak dan comboBox_kelas_layanan dipilih index 1
            {
                harga = hargaTiket[1]; // var harga diubah menyesuaikan dengan array hargaTiket index 1
            }
            else if (comboBox_kelas_layanan.SelectedIndex == 2) // jika tidak dan comboBox_kelas_layanan dipilih index 2
            {
                harga = hargaTiket[2]; // var harga diubah menyesuaikan dengan array hargaTiket index 2
            }
            else if (comboBox_kelas_layanan.SelectedIndex == 3) // jika tidak dan comboBox_kelas_layanan dipilih index 3
            {
                harga = hargaTiket[3]; // var harga diubah menyesuaikan dengan array hargaTiket index 3

            }
            else // tiket tambahan
            {
                harga = hargaTiket[comboBox_kelas_layanan.SelectedIndex]; // var harga diubah menyesuaikan dengan array hargaTiket index sesuai index pilihan
            }




            if (invalid == false) // jika nilai invalid tidak true
            {
                dataGrid_ticket.Rows.Add(nama, ttl, email, nomor_negara, negara_keberangkatan, negara_tujuan, tanggal_berangkat, kelas_layanan, layanan, hotel_pilihan, penerbangan_pilihan, informasi_tambahan, harga); // tambahkan var tadi ke dataGrid_ticket.Rows dengan urutan yang pas
                int total_harga = Convert.ToInt32(label_total_harga.Text); // mengisi var total_harga menjadi nilai dari label total harga yang diconvert ke int
                total_harga += harga; // pengisian dan penambahan nilai var total_harga dengan var harga
                label_total_harga.Text = $"{total_harga}"; // mengubah label_total_harga.Text sesuai dengan harga
            }
                
        }

       

        

        private void button_clear_form_Click(object sender, EventArgs e)
        {
            //membersihkan text, pilihan, dan status ceklis pada semua input.
            txtBox_nama.Clear();
            dateTime_ttl.ResetText();
            textBox_email.Clear();
            textBox_nomor_telepon.Clear();
            txtBox_keberangkatan.Clear();
            txtBox_tujuan.Clear();
            dateTime_keberangkatan.ResetText();
            maskedTextBox_waktu_berangkat.ResetText();
            comboBox_kelas_layanan.ResetText();
            checkBox_tiket_maskapai.Checked = false;
            checkBox_rent_car.Checked = false;
            checkBox_akomodasi_hotel.Checked = false;
            textBox_nama_hotel_pilihan.Clear();
            comboBox_penerbangan.ResetText();
            textBox_informasi_tambahan.Clear();
            comboBox_kelas_layanan.SelectedIndex = -1;
            combo_nomor_negara.SelectedIndex = -1;
            comboBox_penerbangan.SelectedIndex = -1;
        }

        private void button_hapus_tiket_Click(object sender, EventArgs e)
        {
            if (dataGrid_ticket.CurrentRow != null) // jika pengguna tidak memilih baris dari dataGrid_ticket
            {
                label_total_harga.Text = $"{Convert.ToInt32(label_total_harga.Text) - Convert.ToInt32(dataGrid_ticket.CurrentRow.Cells["Total_Harga"].Value)}"; // set label_total_harga.Text ke label_total_harga.Text yang diubah menjadi int lalu di kurang nilai dari sel Total_Harga pada dataGrid_ticket row saat ini yang sudah diubah ke int
                dataGrid_ticket.Rows.RemoveAt(dataGrid_ticket.CurrentRow.Index); //  menghapus baris yang dipilih
                lbl_informasi.Text = ""; // mengosongkan lbl_informasi.Text


            }
            else
            {
                MessageBox.Show("Pilih baris tiket yang ingin dihapus.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // message box error di tampilkan
            }
        }

        

        private void button_print_Click(object sender, EventArgs e) // ketika button print di klik
        {
            PrintPreviewDialog preview = new PrintPreviewDialog(); // membuat var preview
            preview.Document = printDocument1; // set ke preview dari printDocument1
            preview.ShowDialog(); // menunjukka preview

        }

        

        private void button1_Click(object sender, EventArgs e) // ketika tombol hitung kembalian di klik
        {
            if (double.TryParse(textBox_uang_pelanggan.Text, out double uang_pelanggan)) // jika textBox_uang_pelanggan.Text adalah angka, dimasukkan ke var uang_pelanggan
            {
                double total = uang_pelanggan - Convert.ToInt32(label_total_harga.Text); // set var total (total kembalian) dengan uang pelanggan - label_total_harga.Text yang sudah diubah ke int
                if (!string.IsNullOrEmpty(textBox_biaya_admin.Text)) // jika textBox_biaya_admin.Text tidak kosong
                {
                    if (double.TryParse(textBox_biaya_admin.Text, out double biaya_admin)) // jika textBox_biaya_admin.Text adalah angka, masukkan ke var biaya_admin
                    {
                        total -= biaya_admin; // total dikurang biaya admin
                    }
                    else MessageBox.Show("Biaya admin tidak valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // messagebox error ditampilkan
                }
                lbl_kembalian.Text = $"Rp.  {total}"; // mengganti lbl_kembalian.Text dengan total
                if (total < 0) MessageBox.Show("Uang pelanggan tidak cukup", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  // messagebox error ditampilkan

            }
            // jika textBox_uang_pelanggan.Text bukan angka
            else MessageBox.Show("Uang pelanggan tidak valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  // messagebox error ditampilkan
        }

      

        private void button_informasi_tambahan_Click_1(object sender, EventArgs e) // ketika tombol informasi tamabahan di klik
        {
            
            if (dataGrid_ticket.CurrentRow != null) // jika row dari dataGrid_ticket tidak ada yang dipilih.
            {
                lbl_informasi.Text = ""; // dataGrid_ticket diksongkan terlebih dahulu
                lbl_informasi.Text += "# Informasi Pribadi";
                lbl_informasi.Text += "\n • Nama Kontak: ";
                lbl_informasi.Text += dataGrid_ticket.CurrentRow.Cells["Column_Nama_Kontak"].Value?.ToString() ?? ""; // ambil data dari dataGrid_ticket.CurrentRow.Cells
                lbl_informasi.Text += "\n • Tanggal lahir: ";
                lbl_informasi.Text += dataGrid_ticket.CurrentRow.Cells["Column_TTL"].Value?.ToString() ?? ""; // ambil data dari dataGrid_ticket.CurrentRow.Cells
                lbl_informasi.Text += "\n • E-mail: ";
                lbl_informasi.Text += dataGrid_ticket.CurrentRow.Cells["Column_Email"].Value?.ToString() ?? ""; // ambil data dari dataGrid_ticket.CurrentRow.Cells
                lbl_informasi.Text += "\n • No. Telp: ";
                lbl_informasi.Text += dataGrid_ticket.CurrentRow.Cells["Column_Nomor_Telp"].Value?.ToString() ?? ""; // ambil data dari dataGrid_ticket.CurrentRow.Cells

                lbl_informasi.Text += "\n\n# Detail Perjalanan";
                lbl_informasi.Text += "\n • Negara Keberangkatan: ";
                lbl_informasi.Text += dataGrid_ticket.CurrentRow.Cells["Column_Negara_Keberangkatan"].Value?.ToString() ?? ""; // ambil data dari dataGrid_ticket.CurrentRow.Cells
                lbl_informasi.Text += "\n • Negara Tujuan: ";
                lbl_informasi.Text += dataGrid_ticket.CurrentRow.Cells["Column_Negara_Tujuan"].Value?.ToString() ?? ""; // ambil data dari dataGrid_ticket.CurrentRow.Cells
                lbl_informasi.Text += "\n • Tanggal dan Waktu Keberangkatan: ";
                lbl_informasi.Text += dataGrid_ticket.CurrentRow.Cells["Column_Tanggal_Waktu_Berangkat"].Value?.ToString() ?? ""; // ambil data dari dataGrid_ticket.CurrentRow.Cells
                lbl_informasi.Text += "\n • Kelas Layanan: ";
                lbl_informasi.Text += dataGrid_ticket.CurrentRow.Cells["Column_Kelas_Layanan"].Value?.ToString() ?? ""; // ambil data dari dataGrid_ticket.CurrentRow.Cells
                lbl_informasi.Text += "\n • Layanan Lainnya: ";
                lbl_informasi.Text += dataGrid_ticket.CurrentRow.Cells["Column_Layanan"].Value?.ToString() ?? ""; // ambil data dari dataGrid_ticket.CurrentRow.Cells

                lbl_informasi.Text += "\n\n# Rincian Perjalanan";
                if(!string.IsNullOrEmpty(dataGrid_ticket.CurrentRow.Cells["Column_Nama_Hotel"].Value?.ToString()))
                {
                    lbl_informasi.Text += "\n • Hotel Pilihan: ";
                    lbl_informasi.Text += dataGrid_ticket.CurrentRow.Cells["Column_Nama_Hotel"].Value?.ToString() ?? ""; // ambil data dari dataGrid_ticket.CurrentRow.Cells
                }
                lbl_informasi.Text += "\n • Penerbangan Pilihan: ";
                lbl_informasi.Text += dataGrid_ticket.CurrentRow.Cells["Column_Penerbangan"].Value?.ToString() ?? ""; // ambil data dari dataGrid_ticket.CurrentRow.Cells
                lbl_informasi.Text += "\n • Informasi Tambahan: ";
                lbl_informasi.Text += dataGrid_ticket.CurrentRow.Cells["Column_Informasi_Tambahan"].Value?.ToString() ?? ""; // ambil data dari dataGrid_ticket.CurrentRow.Cells
                lbl_informasi.Text += "\n • Harga Tiket: ";
                lbl_informasi.Text += "Rp. " + FormatMoney(Convert.ToInt32(dataGrid_ticket.CurrentRow.Cells["Total_Harga"].Value)); // ambil data dari dataGrid_ticket.CurrentRow.Cells, lalu di convert ke int dan diformat ke money, 
            }
            else
            {
                MessageBox.Show("Pilih baris tiket yang ingin anda lihat informasi tambahannya", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // messagebox error ditampilkan
            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
           
        }

       

        private void button_aktifkan_tiket_Click(object sender, EventArgs e)
        {
      
            if (dataGrid_ticket.CurrentRow == null) // jika dataGrid_ticket tidak ada baris yang dipilih
            {
                MessageBox.Show("Tidak ada baris yang dipilih.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // messagebox error ditampilkan
                return; // program diberhentikan
            }

            string koneksi = "server=localhost;user id=root;password=;database=katasi;"; // menulis database mysql yang akan dihubungkan

            using (MySqlConnection conn = new MySqlConnection(koneksi)) // hubungkan mysql
            {
                conn.Open(); // buka mysql

                string query = @"INSERT INTO tiket 
            (nama_kontak, tanggal_lahir, email, no_telp, negara_keberangkatan, negara_tujuan, 
             tanggal_waktu_keberangkatan, kelas_layanan, layanan_lainnya, hotel_pilihan, 
             penerbangan_pilihan, informasi_tambahan, harga_tiket)
            VALUES 
            (@nama_kontak, @tanggal_lahir, @email, @no_telp, @negara_keberangkatan, @negara_tujuan, 
             @tanggal_waktu_keberangkatan, @kelas_layanan, @layanan_lainnya, @hotel_pilihan, 
             @penerbangan_pilihan, @informasi_tambahan, @harga_tiket)"; // perintah querry sql, (INSERT INTO, VALUES, dll.) untuk menambah baris baru sesuai parimeter

                MySqlCommand cmd = new MySqlCommand(query, conn); // perintah querry

                DataGridViewRow r = dataGrid_ticket.CurrentRow;
                cmd.Parameters.AddWithValue("@nama_kontak", r.Cells["Column_Nama_Kontak"].Value?.ToString() ?? "");
                cmd.Parameters.AddWithValue("@tanggal_lahir", r.Cells["Column_TTL"].Value?.ToString() ?? "");
                cmd.Parameters.AddWithValue("@email", r.Cells["Column_Email"].Value?.ToString() ?? "");
                cmd.Parameters.AddWithValue("@no_telp", r.Cells["Column_Nomor_Telp"].Value?.ToString() ?? "");
                cmd.Parameters.AddWithValue("@negara_keberangkatan", r.Cells["Column_Negara_Keberangkatan"].Value?.ToString() ?? "");
                cmd.Parameters.AddWithValue("@negara_tujuan", r.Cells["Column_Negara_Tujuan"].Value?.ToString() ?? "");
                cmd.Parameters.AddWithValue("@tanggal_waktu_keberangkatan", r.Cells["Column_Tanggal_Waktu_Berangkat"].Value?.ToString() ?? "");
                cmd.Parameters.AddWithValue("@kelas_layanan", r.Cells["Column_Kelas_Layanan"].Value?.ToString() ?? "");
                cmd.Parameters.AddWithValue("@layanan_lainnya", r.Cells["Column_Layanan"].Value?.ToString() ?? "");
                cmd.Parameters.AddWithValue("@hotel_pilihan", r.Cells["Column_Nama_Hotel"].Value?.ToString() ?? "");
                cmd.Parameters.AddWithValue("@penerbangan_pilihan", r.Cells["Column_Penerbangan"].Value?.ToString() ?? "");
                cmd.Parameters.AddWithValue("@informasi_tambahan", r.Cells["Column_Informasi_Tambahan"].Value?.ToString() ?? "");
                cmd.Parameters.AddWithValue("@harga_tiket", r.Cells["Total_Harga"].Value);
                // menambahkan nilai parameter sesuai nilai

                cmd.ExecuteNonQuery();
                // di perintah di eksekusi

                MessageBox.Show("Baris berhasil dimasukkan ke tabel tiket.", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information); // messagebox berhasil
            }

            label_total_harga.Text = $"{Convert.ToInt32(label_total_harga.Text) - Convert.ToInt32(dataGrid_ticket.CurrentRow.Cells["Total_Harga"].Value)}"; //mengurangi nilai total harga tiket
            dataGrid_ticket.Rows.RemoveAt(dataGrid_ticket.CurrentRow.Index); //menghapus baris tiket di datagridview
            lbl_informasi.Text = ""; //membersihkan label informasi selengkapnya
        }

      

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FormTiketAktif fta = new FormTiketAktif();
            this.Hide(); // tutup form saat ini
            fta.Show();   // tampilkan form daftar tiket aktif
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            FormTiketMati fm = new FormTiketMati();
            this.Hide(); // tutup form saat ini
            fm.Show();   // tampilkan form daftar tiket mati
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            FormVerifikasi fv = new FormVerifikasi();
            this.Hide(); // tutup form saat ini
            fv.Show();   // tampilkan form verifikasi tiket
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            FormMenu fm = new FormMenu();
            this.Hide(); // tutup form saat ini
            fm.Show();   // tampilkan form menu
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtBox_nama_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_email_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void lbl_negara_keberangkatan_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        private void gb_informasi_tbhan_Enter(object sender, EventArgs e)
        {

        }

        private void button_menu_tiket_mati_Click(object sender, EventArgs e)
        {

        }

        private void button_menu_verifikasi_tiket_Click(object sender, EventArgs e)
        {

        }

        private void dataGrid_ticket_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox_nama_hotel_pilihan_AcceptsTabChanged(object sender, EventArgs e)
        {

        }

        private void lbl_informasi_Click(object sender, EventArgs e)
        {

        }

        private void button_cek_aktif_tiket_Click(object sender, EventArgs e)
        {


        }
        private void lbl_pilihan_penerbangan_Click(object sender, EventArgs e)
        {

        }

        private void lbl_nama_hotel_pilihan_Click(object sender, EventArgs e)
        {

        }

        private void lbl_judul_rincian_perjalanan_Click(object sender, EventArgs e)
        {

        }

        private void lbl_keberangkatan_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button_preview_Click(object sender, EventArgs e)
        {

        }

        private void button_informasi_tambahan_Click(object sender, EventArgs e)
        {

        }

        private void groupBox_informasi_tambahan_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox_waktu_berangkat_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox_waktu_kembali_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void listBox13_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
