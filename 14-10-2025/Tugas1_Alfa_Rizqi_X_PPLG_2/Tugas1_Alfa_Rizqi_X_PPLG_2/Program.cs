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
            /*Buat program menggunakan for untuk menampilkan perkalian 5 (tabel 5). */
            int nilaiAwal = 5;
            int nilaiPerkalian = 1;
            for(int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{nilaiAwal} x {nilaiPerkalian} = {nilaiAwal * nilaiPerkalian}");
                nilaiPerkalian++;
            }
        }
    }
}
