using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktik7._2_Alfa_Rizqi_X_PPLG_2
{
    internal class Program
    {
        //Fungsi dengan parameter 
        static void SapaNama(string nama)
        {
            Console.WriteLine("Halo, " + nama + "!");
            Console.WriteLine("Selamat belajar C# hari ini!");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Masukkan nama Anda: ");
            string namaSiswa = Console.ReadLine();
            SapaNama(namaSiswa); //Memanggil fungsi dengan argumen
        }
    }
}
