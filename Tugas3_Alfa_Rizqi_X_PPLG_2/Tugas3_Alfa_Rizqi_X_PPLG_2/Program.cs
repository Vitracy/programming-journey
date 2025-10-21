using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tugas3_Alfa_Rizqi_X_PPLG_2
{
    internal class Program
    {
        /*Buat fungsi KonversiSuhu untuk mengubah suhu dari Celcius ke Fahrenheit dengan 
        rumus: 
        F = (C × 9/5) + 32. 
        Tampilkan hasil konversi pada program utama! */
        static double ConvertCelciusToFahrenheit(double celsius)
        {
            double fahrenheit = (celsius * 9 / 5) + 32;
            return fahrenheit;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Program Konversi Suhu dari Celcius ke Fahrenheit");
            Console.Write("Masukkan suhu dalam Celcius: ");
            double celsius = Convert.ToDouble(Console.ReadLine());
            double fahrenheit = ConvertCelciusToFahrenheit(celsius);
            Console.WriteLine($"{celsius}°C = {fahrenheit}°F");
        }
    }
}
