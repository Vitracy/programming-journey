using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktik2._4_Alfa_Rizqi_X_PPLG_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*variable bervariasi*/

            //deklarasi
            string nama_siswa = "Alfa Rizqi";
            string jk = "Laki-laki";
            int umur = 16;
            int nilai = 99;
            char grade = 'A';
            double tb = 170.5;
            bool lulus = true;

            //menampilkan variable
            Console.WriteLine("Nama Siswa       : " + nama_siswa);
            Console.WriteLine("Jenis Kelamin    : " + jk);
            Console.WriteLine("Umur             : " + umur + " Tahun");
            Console.WriteLine("Nilai            : " + nilai);
            Console.WriteLine("Grade Nilai      : " + grade);
            Console.WriteLine("Tinggi Badan     : " + tb + " cm");
            Console.WriteLine("Lulus            : " + lulus);
            Console.ReadKey();
        }
    }
}
