namespace Resevasi_Tiket_Pesawat
{
    partial class FormTiketAktif
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTiketAktif));
            this.dataGrid_active_ticket = new System.Windows.Forms.DataGridView();
            this.Column_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Nama_Kontak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_TTL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Nomor_Telp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Negara_Keberangkatan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Negara_Tujuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Tanggal_Waktu_Berangkat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Kelas_Layanan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Layanan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Nama_Hotel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Penerbangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Informasi_Tambahan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total_Harga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.gb_informasi_tbhan = new System.Windows.Forms.GroupBox();
            this.lbl_informasi = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_active_ticket)).BeginInit();
            this.gb_informasi_tbhan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid_active_ticket
            // 
            this.dataGrid_active_ticket.AllowUserToAddRows = false;
            this.dataGrid_active_ticket.AllowUserToDeleteRows = false;
            this.dataGrid_active_ticket.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid_active_ticket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_active_ticket.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_ID,
            this.Column_Nama_Kontak,
            this.Column_TTL,
            this.Column_Email,
            this.Column_Nomor_Telp,
            this.Column_Negara_Keberangkatan,
            this.Column_Negara_Tujuan,
            this.Column_Tanggal_Waktu_Berangkat,
            this.Column_Kelas_Layanan,
            this.Column_Layanan,
            this.Column_Nama_Hotel,
            this.Column_Penerbangan,
            this.Column_Informasi_Tambahan,
            this.Total_Harga});
            this.dataGrid_active_ticket.Location = new System.Drawing.Point(40, 28);
            this.dataGrid_active_ticket.Name = "dataGrid_active_ticket";
            this.dataGrid_active_ticket.ReadOnly = true;
            this.dataGrid_active_ticket.RowHeadersWidth = 51;
            this.dataGrid_active_ticket.RowTemplate.Height = 24;
            this.dataGrid_active_ticket.Size = new System.Drawing.Size(728, 672);
            this.dataGrid_active_ticket.TabIndex = 35;
            // 
            // Column_ID
            // 
            this.Column_ID.HeaderText = "ID";
            this.Column_ID.MinimumWidth = 6;
            this.Column_ID.Name = "Column_ID";
            this.Column_ID.ReadOnly = true;
            this.Column_ID.Width = 125;
            // 
            // Column_Nama_Kontak
            // 
            this.Column_Nama_Kontak.HeaderText = "Nama Kontak";
            this.Column_Nama_Kontak.MinimumWidth = 6;
            this.Column_Nama_Kontak.Name = "Column_Nama_Kontak";
            this.Column_Nama_Kontak.ReadOnly = true;
            this.Column_Nama_Kontak.Width = 125;
            // 
            // Column_TTL
            // 
            this.Column_TTL.HeaderText = "Tanggal Lahir";
            this.Column_TTL.MinimumWidth = 6;
            this.Column_TTL.Name = "Column_TTL";
            this.Column_TTL.ReadOnly = true;
            this.Column_TTL.Width = 125;
            // 
            // Column_Email
            // 
            this.Column_Email.HeaderText = "E-mail";
            this.Column_Email.MinimumWidth = 6;
            this.Column_Email.Name = "Column_Email";
            this.Column_Email.ReadOnly = true;
            this.Column_Email.Width = 125;
            // 
            // Column_Nomor_Telp
            // 
            this.Column_Nomor_Telp.HeaderText = "Nomor Telepon";
            this.Column_Nomor_Telp.MinimumWidth = 6;
            this.Column_Nomor_Telp.Name = "Column_Nomor_Telp";
            this.Column_Nomor_Telp.ReadOnly = true;
            this.Column_Nomor_Telp.Width = 125;
            // 
            // Column_Negara_Keberangkatan
            // 
            this.Column_Negara_Keberangkatan.HeaderText = "Negara Keberangkatan";
            this.Column_Negara_Keberangkatan.MinimumWidth = 6;
            this.Column_Negara_Keberangkatan.Name = "Column_Negara_Keberangkatan";
            this.Column_Negara_Keberangkatan.ReadOnly = true;
            this.Column_Negara_Keberangkatan.Width = 125;
            // 
            // Column_Negara_Tujuan
            // 
            this.Column_Negara_Tujuan.HeaderText = "Negara Tujuan";
            this.Column_Negara_Tujuan.MinimumWidth = 6;
            this.Column_Negara_Tujuan.Name = "Column_Negara_Tujuan";
            this.Column_Negara_Tujuan.ReadOnly = true;
            this.Column_Negara_Tujuan.Width = 125;
            // 
            // Column_Tanggal_Waktu_Berangkat
            // 
            this.Column_Tanggal_Waktu_Berangkat.HeaderText = "Tanggal dan waktu keberangkatan";
            this.Column_Tanggal_Waktu_Berangkat.MinimumWidth = 6;
            this.Column_Tanggal_Waktu_Berangkat.Name = "Column_Tanggal_Waktu_Berangkat";
            this.Column_Tanggal_Waktu_Berangkat.ReadOnly = true;
            this.Column_Tanggal_Waktu_Berangkat.Width = 125;
            // 
            // Column_Kelas_Layanan
            // 
            this.Column_Kelas_Layanan.HeaderText = "Kelas Layanan";
            this.Column_Kelas_Layanan.MinimumWidth = 6;
            this.Column_Kelas_Layanan.Name = "Column_Kelas_Layanan";
            this.Column_Kelas_Layanan.ReadOnly = true;
            this.Column_Kelas_Layanan.Width = 125;
            // 
            // Column_Layanan
            // 
            this.Column_Layanan.HeaderText = "Layanan";
            this.Column_Layanan.MinimumWidth = 6;
            this.Column_Layanan.Name = "Column_Layanan";
            this.Column_Layanan.ReadOnly = true;
            this.Column_Layanan.Width = 125;
            // 
            // Column_Nama_Hotel
            // 
            this.Column_Nama_Hotel.HeaderText = "Hotel_Pilihan";
            this.Column_Nama_Hotel.MinimumWidth = 6;
            this.Column_Nama_Hotel.Name = "Column_Nama_Hotel";
            this.Column_Nama_Hotel.ReadOnly = true;
            this.Column_Nama_Hotel.Width = 125;
            // 
            // Column_Penerbangan
            // 
            this.Column_Penerbangan.HeaderText = "Penerbangan Pilihan";
            this.Column_Penerbangan.MinimumWidth = 6;
            this.Column_Penerbangan.Name = "Column_Penerbangan";
            this.Column_Penerbangan.ReadOnly = true;
            this.Column_Penerbangan.Width = 125;
            // 
            // Column_Informasi_Tambahan
            // 
            this.Column_Informasi_Tambahan.HeaderText = "Informasi Tambahan";
            this.Column_Informasi_Tambahan.MinimumWidth = 6;
            this.Column_Informasi_Tambahan.Name = "Column_Informasi_Tambahan";
            this.Column_Informasi_Tambahan.ReadOnly = true;
            this.Column_Informasi_Tambahan.Width = 125;
            // 
            // Total_Harga
            // 
            this.Total_Harga.HeaderText = "Harga";
            this.Total_Harga.MinimumWidth = 6;
            this.Total_Harga.Name = "Total_Harga";
            this.Total_Harga.ReadOnly = true;
            this.Total_Harga.Width = 125;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(786, 751);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(258, 23);
            this.progressBar1.TabIndex = 39;
            this.progressBar1.Visible = false;
            // 
            // gb_informasi_tbhan
            // 
            this.gb_informasi_tbhan.Controls.Add(this.lbl_informasi);
            this.gb_informasi_tbhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_informasi_tbhan.Location = new System.Drawing.Point(786, 28);
            this.gb_informasi_tbhan.Name = "gb_informasi_tbhan";
            this.gb_informasi_tbhan.Size = new System.Drawing.Size(414, 642);
            this.gb_informasi_tbhan.TabIndex = 51;
            this.gb_informasi_tbhan.TabStop = false;
            this.gb_informasi_tbhan.Text = "Informasi Selengkapnya";
            // 
            // lbl_informasi
            // 
            this.lbl_informasi.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_informasi.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_informasi.Location = new System.Drawing.Point(18, 26);
            this.lbl_informasi.Name = "lbl_informasi";
            this.lbl_informasi.Size = new System.Drawing.Size(378, 589);
            this.lbl_informasi.TabIndex = 44;
            this.lbl_informasi.Click += new System.EventHandler(this.lbl_informasi_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage_1);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            this.printPreviewDialog1.Load += new System.EventHandler(this.printPreviewDialog1_Load);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(921, 727);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 16);
            this.label5.TabIndex = 63;
            this.label5.Text = "Cetak";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(900, 676);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(86, 50);
            this.pictureBox2.TabIndex = 64;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(805, 676);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(86, 50);
            this.pictureBox1.TabIndex = 65;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(783, 727);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 16);
            this.label1.TabIndex = 66;
            this.label1.Text = "Baca Selengkapnya";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.pictureBox8);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.pictureBox7);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.pictureBox5);
            this.groupBox4.Controls.Add(this.pictureBox4);
            this.groupBox4.Controls.Add(this.pictureBox3);
            this.groupBox4.Controls.Add(this.pictureBox6);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(40, 706);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(614, 92);
            this.groupBox4.TabIndex = 67;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Menu";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(516, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 16);
            this.label8.TabIndex = 69;
            this.label8.Text = "Menu";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(410, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 16);
            this.label7.TabIndex = 63;
            this.label7.Text = "Tiket Baru";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox8.BackgroundImage")));
            this.pictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox8.Location = new System.Drawing.Point(493, 18);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(86, 50);
            this.pictureBox8.TabIndex = 68;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.Click += new System.EventHandler(this.pictureBox8_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(319, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 16);
            this.label6.TabIndex = 62;
            this.label6.Text = "Tiket Mati";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(236, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 16);
            this.label4.TabIndex = 61;
            this.label4.Text = "Hapus";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(129, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 16);
            this.label3.TabIndex = 60;
            this.label3.Text = "Nonaktifkan";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox7.BackgroundImage")));
            this.pictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox7.Location = new System.Drawing.Point(401, 18);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(86, 50);
            this.pictureBox7.TabIndex = 59;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Click += new System.EventHandler(this.pictureBox7_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(51, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 49;
            this.label2.Text = "Refesh";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox5.BackgroundImage")));
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox5.Location = new System.Drawing.Point(309, 18);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(86, 50);
            this.pictureBox5.TabIndex = 58;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.BackgroundImage")));
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox4.Location = new System.Drawing.Point(217, 18);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(86, 50);
            this.pictureBox4.TabIndex = 57;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Location = new System.Drawing.Point(125, 18);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(86, 50);
            this.pictureBox3.TabIndex = 56;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox6.BackgroundImage")));
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox6.Location = new System.Drawing.Point(33, 18);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(86, 50);
            this.pictureBox6.TabIndex = 53;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // FormTiketAktif
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 814);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.gb_informasi_tbhan);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.dataGrid_active_ticket);
            this.Name = "FormTiketAktif";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Daftar Tiket Aktif";
            this.Load += new System.EventHandler(this.FormTiketAktif_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_active_ticket)).EndInit();
            this.gb_informasi_tbhan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGrid_active_ticket;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Nama_Kontak;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_TTL;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Nomor_Telp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Negara_Keberangkatan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Negara_Tujuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Tanggal_Waktu_Berangkat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Kelas_Layanan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Layanan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Nama_Hotel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Penerbangan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Informasi_Tambahan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total_Harga;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox gb_informasi_tbhan;
        private System.Windows.Forms.Label lbl_informasi;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox8;
    }
}