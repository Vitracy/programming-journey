namespace Radio_Button
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            rd_laki_laki = new RadioButton();
            cb_hobi_makan = new CheckBox();
            rd_perempuan = new RadioButton();
            cb_hobi_minum = new CheckBox();
            cb_jurusan = new ComboBox();
            cb_hobi_tidur = new CheckBox();
            lbl_judul_hobi = new Label();
            lbl_judu_pillih_jurusan = new Label();
            gb_jenis_kelamin = new GroupBox();
            lbl_jenis_kelamin = new Label();
            lbl_hobi = new Label();
            lbl_jurusan = new Label();
            lbl_judul = new Label();
            lbl_judul_nama = new Label();
            txt_nama = new TextBox();
            lbl_judul_alamat = new Label();
            txt_alamat = new TextBox();
            btn_daftar = new Button();
            lbl_nama_lengkap = new Label();
            lbl_alamat = new Label();
            gb_jenis_kelamin.SuspendLayout();
            SuspendLayout();
            // 
            // rd_laki_laki
            // 
            rd_laki_laki.AutoSize = true;
            rd_laki_laki.Location = new Point(6, 26);
            rd_laki_laki.Name = "rd_laki_laki";
            rd_laki_laki.Size = new Size(85, 24);
            rd_laki_laki.TabIndex = 0;
            rd_laki_laki.TabStop = true;
            rd_laki_laki.Text = "Laki-laki";
            rd_laki_laki.UseVisualStyleBackColor = true;
            // 
            // cb_hobi_makan
            // 
            cb_hobi_makan.AutoSize = true;
            cb_hobi_makan.Location = new Point(26, 319);
            cb_hobi_makan.Name = "cb_hobi_makan";
            cb_hobi_makan.Size = new Size(75, 24);
            cb_hobi_makan.TabIndex = 1;
            cb_hobi_makan.Text = "Makan";
            cb_hobi_makan.UseVisualStyleBackColor = true;
            cb_hobi_makan.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // rd_perempuan
            // 
            rd_perempuan.AutoSize = true;
            rd_perempuan.Location = new Point(97, 26);
            rd_perempuan.Name = "rd_perempuan";
            rd_perempuan.Size = new Size(104, 24);
            rd_perempuan.TabIndex = 2;
            rd_perempuan.TabStop = true;
            rd_perempuan.Text = "Perempuan";
            rd_perempuan.UseVisualStyleBackColor = true;
            // 
            // cb_hobi_minum
            // 
            cb_hobi_minum.AutoSize = true;
            cb_hobi_minum.Location = new Point(26, 349);
            cb_hobi_minum.Name = "cb_hobi_minum";
            cb_hobi_minum.Size = new Size(77, 24);
            cb_hobi_minum.TabIndex = 3;
            cb_hobi_minum.Text = "Minum";
            cb_hobi_minum.UseVisualStyleBackColor = true;
            // 
            // cb_jurusan
            // 
            cb_jurusan.FormattingEnabled = true;
            cb_jurusan.Items.AddRange(new object[] { "PPLG", "TKJ", "DKV", "TM", "TO", "TE", "TKL", "AKL", "TB" });
            cb_jurusan.Location = new Point(26, 448);
            cb_jurusan.Name = "cb_jurusan";
            cb_jurusan.Size = new Size(206, 28);
            cb_jurusan.TabIndex = 4;
            // 
            // cb_hobi_tidur
            // 
            cb_hobi_tidur.AutoSize = true;
            cb_hobi_tidur.Location = new Point(26, 379);
            cb_hobi_tidur.Name = "cb_hobi_tidur";
            cb_hobi_tidur.Size = new Size(65, 24);
            cb_hobi_tidur.TabIndex = 5;
            cb_hobi_tidur.Text = "Tidur";
            cb_hobi_tidur.UseVisualStyleBackColor = true;
            // 
            // lbl_judul_hobi
            // 
            lbl_judul_hobi.AutoSize = true;
            lbl_judul_hobi.Location = new Point(26, 296);
            lbl_judul_hobi.Name = "lbl_judul_hobi";
            lbl_judul_hobi.Size = new Size(144, 20);
            lbl_judul_hobi.TabIndex = 8;
            lbl_judul_hobi.Text = "Pilih hobi (Opsional)";
            // 
            // lbl_judu_pillih_jurusan
            // 
            lbl_judu_pillih_jurusan.AutoSize = true;
            lbl_judu_pillih_jurusan.Location = new Point(26, 425);
            lbl_judu_pillih_jurusan.Name = "lbl_judu_pillih_jurusan";
            lbl_judu_pillih_jurusan.Size = new Size(88, 20);
            lbl_judu_pillih_jurusan.TabIndex = 9;
            lbl_judu_pillih_jurusan.Text = "Pilih jurusan";
            // 
            // gb_jenis_kelamin
            // 
            gb_jenis_kelamin.Controls.Add(rd_laki_laki);
            gb_jenis_kelamin.Controls.Add(rd_perempuan);
            gb_jenis_kelamin.Location = new Point(29, 220);
            gb_jenis_kelamin.Name = "gb_jenis_kelamin";
            gb_jenis_kelamin.Size = new Size(206, 64);
            gb_jenis_kelamin.TabIndex = 10;
            gb_jenis_kelamin.TabStop = false;
            gb_jenis_kelamin.Text = "Pilih jenis kelamin";
            // 
            // lbl_jenis_kelamin
            // 
            lbl_jenis_kelamin.AutoSize = true;
            lbl_jenis_kelamin.Location = new Point(255, 220);
            lbl_jenis_kelamin.Name = "lbl_jenis_kelamin";
            lbl_jenis_kelamin.Size = new Size(101, 20);
            lbl_jenis_kelamin.TabIndex = 11;
            lbl_jenis_kelamin.Text = "Jenis Kelamin:";
            // 
            // lbl_hobi
            // 
            lbl_hobi.AutoSize = true;
            lbl_hobi.Location = new Point(255, 296);
            lbl_hobi.Name = "lbl_hobi";
            lbl_hobi.Size = new Size(45, 20);
            lbl_hobi.TabIndex = 12;
            lbl_hobi.Text = "Hobi:";
            // 
            // lbl_jurusan
            // 
            lbl_jurusan.AutoSize = true;
            lbl_jurusan.Location = new Point(255, 425);
            lbl_jurusan.Name = "lbl_jurusan";
            lbl_jurusan.Size = new Size(60, 20);
            lbl_jurusan.TabIndex = 13;
            lbl_jurusan.Text = "Jurusan:";
            // 
            // lbl_judul
            // 
            lbl_judul.AutoSize = true;
            lbl_judul.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_judul.Location = new Point(26, 69);
            lbl_judul.Name = "lbl_judul";
            lbl_judul.Size = new Size(195, 20);
            lbl_judul.TabIndex = 14;
            lbl_judul.Text = "Formulir Pendaftaran SMK";
            // 
            // lbl_judul_nama
            // 
            lbl_judul_nama.AutoSize = true;
            lbl_judul_nama.Location = new Point(29, 103);
            lbl_judul_nama.Name = "lbl_judul_nama";
            lbl_judul_nama.Size = new Size(109, 20);
            lbl_judul_nama.TabIndex = 15;
            lbl_judul_nama.Text = "Nama Lengkap";
            // 
            // txt_nama
            // 
            txt_nama.Location = new Point(29, 126);
            txt_nama.Name = "txt_nama";
            txt_nama.Size = new Size(206, 27);
            txt_nama.TabIndex = 16;
            // 
            // lbl_judul_alamat
            // 
            lbl_judul_alamat.AutoSize = true;
            lbl_judul_alamat.Location = new Point(29, 156);
            lbl_judul_alamat.Name = "lbl_judul_alamat";
            lbl_judul_alamat.Size = new Size(57, 20);
            lbl_judul_alamat.TabIndex = 17;
            lbl_judul_alamat.Text = "Alamat";
            // 
            // txt_alamat
            // 
            txt_alamat.Location = new Point(29, 179);
            txt_alamat.Name = "txt_alamat";
            txt_alamat.Size = new Size(206, 27);
            txt_alamat.TabIndex = 18;
            // 
            // btn_daftar
            // 
            btn_daftar.Location = new Point(26, 485);
            btn_daftar.Name = "btn_daftar";
            btn_daftar.Size = new Size(94, 29);
            btn_daftar.TabIndex = 19;
            btn_daftar.Text = "Daftar";
            btn_daftar.UseVisualStyleBackColor = true;
            btn_daftar.Click += btn_daftar_Click;
            // 
            // lbl_nama_lengkap
            // 
            lbl_nama_lengkap.AutoSize = true;
            lbl_nama_lengkap.Location = new Point(255, 103);
            lbl_nama_lengkap.Name = "lbl_nama_lengkap";
            lbl_nama_lengkap.Size = new Size(112, 20);
            lbl_nama_lengkap.TabIndex = 20;
            lbl_nama_lengkap.Text = "Nama Lengkap:";
            // 
            // lbl_alamat
            // 
            lbl_alamat.AutoSize = true;
            lbl_alamat.Location = new Point(255, 156);
            lbl_alamat.Name = "lbl_alamat";
            lbl_alamat.Size = new Size(60, 20);
            lbl_alamat.TabIndex = 21;
            lbl_alamat.Text = "Alamat:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 611);
            Controls.Add(lbl_alamat);
            Controls.Add(lbl_nama_lengkap);
            Controls.Add(btn_daftar);
            Controls.Add(txt_alamat);
            Controls.Add(lbl_judul_alamat);
            Controls.Add(txt_nama);
            Controls.Add(lbl_judul_nama);
            Controls.Add(lbl_judul);
            Controls.Add(lbl_jurusan);
            Controls.Add(lbl_hobi);
            Controls.Add(lbl_jenis_kelamin);
            Controls.Add(gb_jenis_kelamin);
            Controls.Add(lbl_judu_pillih_jurusan);
            Controls.Add(lbl_judul_hobi);
            Controls.Add(cb_hobi_tidur);
            Controls.Add(cb_jurusan);
            Controls.Add(cb_hobi_minum);
            Controls.Add(cb_hobi_makan);
            Name = "Form1";
            Text = "Form1";
            gb_jenis_kelamin.ResumeLayout(false);
            gb_jenis_kelamin.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton rd_laki_laki;
        private CheckBox cb_hobi_makan;
        private RadioButton rd_perempuan;
        private CheckBox cb_hobi_minum;
        private ComboBox cb_jurusan;
        private CheckBox cb_hobi_tidur;
        private Label lbl_judul_hobi;
        private Label lbl_judu_pillih_jurusan;
        private GroupBox gb_jenis_kelamin;
        private Label lbl_jenis_kelamin;
        private Label lbl_hobi;
        private Label lbl_jurusan;
        private Label lbl_judul;
        private Label lbl_judul_nama;
        private TextBox txt_nama;
        private Label lbl_judul_alamat;
        private TextBox txt_alamat;
        private Button btn_daftar;
        private Label lbl_nama_lengkap;
        private Label lbl_alamat;
    }
}
