using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktik6._7_Alfa_Rizqi_X_PPLG_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Menu Pilihan Sederhana 
            Aplikasi ini menampilkan menu pilihan dan meminta input hingga pengguna memilih 
            opsi "Keluar" (nomor 3). */

            int pilihan;

            do {
                Console.WriteLine("\n===Menu Aplikasi===");
                Console.WriteLine("1. Lihat data");
                Console.WriteLine("2. Tambah data");
                Console.WriteLine("3. Keluar");
                Console.Write("Masukkan pilihan Anda (1-3): ");

                //Baca input dari pengguna
                if (!int.TryParse(Console.ReadLine(), out pilihan))
                {
                    Console.WriteLine("Input tidak valid. Silakan masukkan angka antara 1-3.");
                    // Tetapkan nilai selain 3 agar loop terus berlanjut
                    pilihan = 0;
                    continue; // Lanjutkan ke iterasi berikutnya
                }

                // Proses pilihan pengguna
                switch (pilihan)
                {
                    case 1:
                        Console.WriteLine("Anda memilih: Lihat Data.");
                        break;
                    case 2:
                        Console.WriteLine("Anda memilih: Tambah Data.");
                        break;
                    case 3:
                        Console.WriteLine("Program akan berhenti...");
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid. Silakan masukkan angka antara 1-3.");
                        break;
                }

            } while (pilihan != 3); // Loop terus menerus hingga pengguna memilih opsi "Keluar"
            Console.WriteLine("Terimakasih telah menggunakan aplikasi ini.");
        }
    }
}
