using System;
using MyLibrary;

namespace MultiExerciseProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== MENU CHỌN BÀI ===");
                Console.WriteLine("1. Bài 1: Kiểm tra ngày hợp lệ");
                Console.WriteLine("2. Bài 2: Tìm thứ trong tuần");
                Console.WriteLine("3. Bài 3: Xử lý mảng số nguyên");
                Console.WriteLine("4. Bài 4: Tính tổng các số nguyên tố nhỏ hơn n");
                Console.WriteLine("5. Bài 5: Tính số ngày trong tháng");
                Console.WriteLine("6. Bài 6: Xử lý ma trận");
                Console.WriteLine("0. Thoát");
                Console.Write("Nhập lựa chọn của bạn: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1": Bai1(); break;
                    case "2": Bai2(); break;
                    case "3": Bai3(); break;
                    case "4": Bai4(); break;
                    case "5": Bai5(); break;
                    case "6": Bai6(); break;
                    case "0":
                        Console.WriteLine("Tạm biệt!");
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ, mời nhập lại!");
                        break;
                }

                Console.WriteLine("\nNhấn phím bất kỳ để quay lại menu...");
                Console.ReadKey();
            }
        }

        // === BÀI 1 ===
        static void Bai1()
        {
            Console.WriteLine("=== Bài 1: ===");

            int n = ArrayUtilities.ReadPositiveInt("Nhập số phần tử mảng: ");
            int[] a = new int[n];

            Console.WriteLine("Nhập các phần tử của mảng:");
            ArrayUtilities.InputArray(a, n);

            Console.WriteLine($"Tổng các số lẻ trong mảng: {ArrayUtilities.SumOdd(a, n)}");
            Console.WriteLine($"Số lượng số nguyên tố trong mảng: {ArrayUtilities.CountPrimes(a, n)}");
            Console.WriteLine($"Số chính phương nhỏ nhất trong mảng: {ArrayUtilities.MinPerfectSquare(a, n)}");
        }

        // === BÀI 2 ===
        static void Bai2()
        {
            Console.WriteLine("=== Bài 4: Tính tổng các số nguyên tố nhỏ hơn n ===");
            int n = MathHelper.ReadPositiveInt("Nhập số nguyên dương n: ");
            int sum = MathHelper.SumPrimesLessThan(n);
            Console.WriteLine($"Tổng các số nguyên tố nhỏ hơn {n} là: {sum}");
        }

        // === BÀI 3 ===
        static void Bai3()
        {
            Console.WriteLine("=== Bài 3: ===");
            int day = DateHelper.ReadPositiveInt("Nhập ngày: ");
            int month = DateHelper.ReadPositiveInt("Nhập tháng: ");
            int year = DateHelper.ReadPositiveInt("Nhập năm: ");

            if (DateHelper.IsValidDate(day, month, year))
                Console.WriteLine("=> Ngày/tháng/năm hợp lệ.");
            else
                Console.WriteLine("=> Ngày/tháng/năm không hợp lệ!");
        }

        // === BÀI 4 ===
        static void Bai4()
        {
            Console.WriteLine("=== Bài 4: ===");
            int month = DateHelper.ReadPositiveInt("Nhập tháng: ");
            int year = DateHelper.ReadPositiveInt("Nhập năm: ");

            int days = DateHelper.DaysInMonth(month, year);
            if (days == -1)
                Console.WriteLine("=> Tháng không hợp lệ!");
            else
                Console.WriteLine($"=> Tháng {month} năm {year} có {days} ngày.");
        }

        // === BÀI 5 ===
        static void Bai5()
        {
            Console.WriteLine("=== Bài 5: ===");
            int day = DateHelper.ReadPositiveInt("Nhập ngày: ");
            int month = DateHelper.ReadPositiveInt("Nhập tháng: ");
            int year = DateHelper.ReadPositiveInt("Nhập năm: ");

            string weekday = DateHelper.DayOfWeek(day, month, year);
            Console.WriteLine($"=> Thứ trong tuần của {day}/{month}/{year} là: {weekday}");
        }

        // === BÀI 6 ===
        static void Bai6()
        {
            Console.WriteLine("=== Bài 6: Xử lý ma trận ===");
            Console.Write("Nhập số dòng n: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Nhập số cột m: ");
            int m = int.Parse(Console.ReadLine());

            int[,] matrix = MatrixHelper.CreateRandomMatrix(n, m, 0, 50);
            Console.WriteLine("\nMa trận ban đầu:");
            MatrixHelper.PrintMatrix(matrix);

            Console.WriteLine($"\nPhần tử lớn nhất: {MatrixHelper.MaxElement(matrix)}");
            Console.WriteLine($"Phần tử nhỏ nhất: {MatrixHelper.MinElement(matrix)}");
            Console.WriteLine($"Dòng có tổng lớn nhất: {MatrixHelper.RowWithMaxSum(matrix)}");
            Console.WriteLine($"Tổng các phần tử KHÔNG phải số nguyên tố: {MatrixHelper.SumNonPrimes(matrix)}");

            Console.Write("\nNhập dòng k cần xóa: ");
            int k = int.Parse(Console.ReadLine());
            matrix = MatrixHelper.DeleteRow(matrix, k);
            Console.WriteLine($"\nMa trận sau khi xóa dòng thứ {k}:");
            MatrixHelper.PrintMatrix(matrix);

            matrix = MatrixHelper.DeleteColumnWithMax(matrix);
            Console.WriteLine("\nMa trận sau khi xóa cột chứa phần tử lớn nhất:");
            MatrixHelper.PrintMatrix(matrix);
        }
    }
}
