using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktik5._3_Alfa_Rizqi_X_PPLG_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Membuat array untuk menyimpan nama dan nilai 3 siswa
            string[] nama = new string[3];
            int[] nilai = new int[3];

            // Input nama dan nilai siswa dari keyboard
            Console.Write("Masukkan nama siswa ke-1: ");
            nama[0] = Console.ReadLine();
            Console.Write("Masukkan nilai siswa ke-1: ");
            nilai[0] = int.Parse(Console.ReadLine());

            Console.Write("Masukkan nama siswa ke-2: ");
            nama[1] = Console.ReadLine();
            Console.Write("Masukkan nilai siswa ke-2: ");
            nilai[1] = Convert.ToInt32(Console.ReadLine());

            Console.Write("Masukkan nama siswa ke-3: ");
            nama[2] = Console.ReadLine();
            Console.Write("Masukkan nilai siswa ke-3: ");
            nilai[2] = Convert.ToInt32(Console.ReadLine());

            // Menampilkan nama dan nilai siswa tanpa perulangan
            Console.WriteLine("\n===Data Siswa===");
            Console.WriteLine("Nama: " + nama[0] + " | Nilai: " + nilai[0]);
            Console.WriteLine("Nama: " + nama[1] + " | Nilai: " + nilai[1]);
            Console.WriteLine("Nama: " + nama[2] + " | Nilai: " + nilai[2]);
        }
    }
}
