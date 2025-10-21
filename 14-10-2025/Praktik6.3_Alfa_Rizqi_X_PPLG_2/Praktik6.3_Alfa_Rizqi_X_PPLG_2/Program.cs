using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktik6._3_Alfa_Rizqi_X_PPLG_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Perulangan While
            // inisialisasi variabel untuk menyimpan input

            string inputUser = "";

            Console.WriteLine("Program akan terus berjalan hingga Anda mengetik 'keluar'.");

            // Perulangan selama isi variabel inputUser TIDAK SAMA DENGAN "keluar"
            while (inputUser.ToLower() != "keluar")
            {
                Console.Write("\nKetik sesuatu (atau ketik 'keluar' untuk berhenti): ");
                inputUser = Console.ReadLine(); // Baca input dari user

                Console.WriteLine("Anda mengetik: " + inputUser);
            }

            Console.WriteLine("\nProgram selesai. Terima kasih!");
        }
    }
}
