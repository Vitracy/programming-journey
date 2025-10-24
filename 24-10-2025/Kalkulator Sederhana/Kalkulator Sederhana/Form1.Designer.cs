namespace Kalkulator_Sederhana
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            lbl_operasi = new Label();
            btn_tambah = new Button();
            btn_kurang = new Button();
            btn_kali = new Button();
            btn_bagi = new Button();
            btn_modulus = new Button();
            btn_samadengan = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(112, 117);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(281, 117);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 1;
            // 
            // lbl_operasi
            // 
            lbl_operasi.AutoSize = true;
            lbl_operasi.Location = new Point(250, 121);
            lbl_operasi.Name = "lbl_operasi";
            lbl_operasi.Size = new Size(19, 20);
            lbl_operasi.TabIndex = 2;
            lbl_operasi.Text = "×";
            lbl_operasi.TextAlign = ContentAlignment.MiddleCenter;
            lbl_operasi.Click += lbl_operasi_Click;
            // 
            // btn_tambah
            // 
            btn_tambah.Location = new Point(112, 152);
            btn_tambah.Name = "btn_tambah";
            btn_tambah.Size = new Size(94, 29);
            btn_tambah.TabIndex = 3;
            btn_tambah.Text = "+";
            btn_tambah.UseVisualStyleBackColor = true;
            btn_tambah.Click += btn_tambah_Click;
            // 
            // btn_kurang
            // 
            btn_kurang.Location = new Point(112, 187);
            btn_kurang.Name = "btn_kurang";
            btn_kurang.Size = new Size(94, 29);
            btn_kurang.TabIndex = 4;
            btn_kurang.Text = "-";
            btn_kurang.UseVisualStyleBackColor = true;
            btn_kurang.Click += btn_kurang_Click;
            // 
            // btn_kali
            // 
            btn_kali.Location = new Point(212, 152);
            btn_kali.Name = "btn_kali";
            btn_kali.Size = new Size(94, 29);
            btn_kali.TabIndex = 5;
            btn_kali.Text = "×";
            btn_kali.UseVisualStyleBackColor = true;
            btn_kali.Click += btn_kali_Click;
            // 
            // btn_bagi
            // 
            btn_bagi.Location = new Point(212, 187);
            btn_bagi.Name = "btn_bagi";
            btn_bagi.Size = new Size(94, 29);
            btn_bagi.TabIndex = 6;
            btn_bagi.Text = "÷";
            btn_bagi.UseVisualStyleBackColor = true;
            btn_bagi.Click += btn_bagi_Click;
            // 
            // btn_modulus
            // 
            btn_modulus.Location = new Point(312, 152);
            btn_modulus.Name = "btn_modulus";
            btn_modulus.Size = new Size(94, 29);
            btn_modulus.TabIndex = 7;
            btn_modulus.Text = "%";
            btn_modulus.UseVisualStyleBackColor = true;
            btn_modulus.Click += btn_modulus_Click;
            // 
            // btn_samadengan
            // 
            btn_samadengan.Location = new Point(312, 187);
            btn_samadengan.Name = "btn_samadengan";
            btn_samadengan.Size = new Size(94, 29);
            btn_samadengan.TabIndex = 8;
            btn_samadengan.Text = "=";
            btn_samadengan.UseVisualStyleBackColor = true;
            btn_samadengan.Click += btn_samadengan_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(101, 91);
            label1.Name = "label1";
            label1.Size = new Size(159, 20);
            label1.TabIndex = 9;
            label1.Text = "Kalkulator 2 Bilangan";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(112, 219);
            label2.Name = "label2";
            label2.Size = new Size(45, 20);
            label2.TabIndex = 10;
            label2.Text = "Hasil:";
            label2.Click += label2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btn_samadengan);
            Controls.Add(btn_modulus);
            Controls.Add(btn_bagi);
            Controls.Add(btn_kali);
            Controls.Add(btn_kurang);
            Controls.Add(btn_tambah);
            Controls.Add(lbl_operasi);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private Label lbl_operasi;
        private Button btn_tambah;
        private Button btn_kurang;
        private Button btn_kali;
        private Button btn_bagi;
        private Button btn_modulus;
        private Button btn_samadengan;
        private Label label1;
        private Label label2;
    }
}
