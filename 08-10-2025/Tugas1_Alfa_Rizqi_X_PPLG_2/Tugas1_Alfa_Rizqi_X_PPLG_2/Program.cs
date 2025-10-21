using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tugas1_Alfa_Rizqi_X_PPLG_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Buatlah sebuah array untuk menampilkan tiga buah elemen yang berisi : 
            nama siswa, jenis kelamin dan kelas. 
             Nama siswa → bertipe string 
             Jenis kelamin (L/P) → bertipe char 
             Kelas → bertipe string */

            string[] nama = new string[3];
            char[] jenis_kelamin = new char[3];
            string[] kelas = new string[3];

            Console.Write("Masukkan nama siswa ke-1: ");
            nama[0] = Console.ReadLine();
            Console.Write("Masukkan jenis kelamin (L/P) siswa ke-1: ");
            jenis_kelamin[0] = char.Parse(Console.ReadLine());
            Console.Write("Masukkan kelas siswa ke-1: ");
            kelas[0] = Console.ReadLine();

            Console.Write("Masukkan nama siswa ke-2: ");
            nama[1] = Console.ReadLine();
            Console.Write("Masukkan jenis kelamin (L/P) siswa ke-2: ");
            jenis_kelamin[1] = char.Parse(Console.ReadLine());
            Console.Write("Masukkan kelas siswa ke-2: ");
            kelas[1] = Console.ReadLine();

            Console.Write("Masukkan nama siswa ke-3: ");
            nama[2] = Console.ReadLine();
            Console.Write("Masukkan jenis kelamin (L/P) siswa ke-3: ");
            jenis_kelamin[2] = char.Parse(Console.ReadLine());
            Console.Write("Masukkan kelas siswa ke-3: ");
            kelas[2] = Console.ReadLine();

            if(jenis_kelamin[0] != 'L' && jenis_kelamin[0] != 'P' || jenis_kelamin[1] != 'L' && jenis_kelamin[1] != 'P' || jenis_kelamin[2] != 'L' && jenis_kelamin[2] != 'P')
            {
                Console.WriteLine("Input jenis kelamin harus 'L' atau 'P'. Program dihentikan.");
                return;
            }   

            Console.WriteLine("\n===Data Siswa===");
            Console.WriteLine("Nama: " + nama[0] + " | Jenis Kelamin: " + jenis_kelamin[0] + " | Kelas: " + kelas[0]);
            Console.WriteLine("Nama: " + nama[1] + " | Jenis Kelamin: " + jenis_kelamin[1] + " | Kelas: " + kelas[1]);
            Console.WriteLine("Nama: " + nama[2] + " | Jenis Kelamin: " + jenis_kelamin[2] + " | Kelas: " + kelas[2]);
        }
    }
}
