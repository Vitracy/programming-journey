using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktik6._8_Alfa_Rizqi_X_PPLG_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Program akan meminta nama pengguna dan kemudian bertanya apakah akan 
            mengulang. */

            string ulangiPilihan;

            do
            {
                // --- Blok Proses yang Akan Diulang ---
                Console.WriteLine("----------------------------------");
                Console.Write("Masukkan nama Anda: ");
                string nama = Console.ReadLine();
                Console.WriteLine("Halo, " + nama + "! Proses telah selesai.");
                // ----------------------------------
                // Pertanyaan untuk mengulang
                Console.Write("Apakah Anda ingin mengulangi? (ya/tidak): ");
                ulangiPilihan = Console.ReadLine().ToLower();

                Console.WriteLine(); // Baris kosong untuk kerapian

            }
            // Kondisi diperiksa di akhir: Ulangi selama pengguna memasukkan "ya"
            while (ulangiPilihan == "ya");
            Console.WriteLine("Terima kasih! Program selesai.");
        }
    }
}
