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
            Console.WriteLine("Input Biodata Saya");
            Console.Write("Nama :");
            string nama = Console.ReadLine();
            Console.Write("Nama Panggilan :");
            string nama_panggilan = Console.ReadLine();
            Console.Write("Jenis Kelamin :");
            string jenis_kelamin = Console.ReadLine();
            Console.Write("Agama :");
            string agama = Console.ReadLine();
            Console.Write("Usia :");
            string usia = Console.ReadLine();
            Console.Write("Sekolah di :");
            string sekolah_di = Console.ReadLine();
            Console.Write("Jurusan :");
            string jurusan = Console.ReadLine();
            Console.Write("Alamat :");
            string alamat = Console.ReadLine();
            Console.Write("Hobi :");
            string hobi = Console.ReadLine();
            Console.Write("Cita-cita :");
            string cita_cita = Console.ReadLine();
            Console.WriteLine("********************************");
            Console.WriteLine("          BIODATA SAYA          ");
            Console.WriteLine("********************************");
            Console.WriteLine("Nama             :" + nama);
            Console.WriteLine("Nama Panggilan   :" + nama_panggilan);
            Console.WriteLine("Jenis Kelamin    :" + jenis_kelamin);
            Console.WriteLine("Agama            :" + agama);
            Console.WriteLine("Usia             :" + usia);
            Console.WriteLine("Sekolah di       :" + sekolah_di);
            Console.WriteLine("Jurusan          :" + jurusan);
            Console.WriteLine("Alamat           :" + alamat);
            Console.WriteLine("Hobi             :" + hobi);
            Console.WriteLine("Cita-cita        :" + cita_cita);
        }
    }
}
