using System;
using System.Globalization;
using System.Text;
namespace MyLibrary
{
    public class Bai5
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Nhập ngày (dd/mm/yyyy): ");
            string input = Console.ReadLine();

            DateTime date = DateTime.ParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine(date.DayOfWeek);
        }
    }
}







