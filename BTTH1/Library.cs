using System;

namespace MyLibrary
{
    
    // --- LỚP XỬ LÝ MẢNG ---
    public static class ArrayUtilities
    {
        public static int ReadPositiveInt(string message)
        {
            int n;
            do { Console.Write(message); }
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);
            return n;
        }

        public static void InputArray(int[] a, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write($"a[{i}] = ");
                a[i] = int.Parse(Console.ReadLine());
            }
        }

        public static int SumOdd(int[] a, int n)
        {
            int res = 0;
            for (int i = 0; i < n; i++)
                if (a[i] % 2 != 0) res += a[i];
            return res;
        }

        public static bool IsPrime(int x)
        {
            if (x < 2) return false;
            for (int i = 2; i * i <= x; i++)
                if (x % i == 0) return false;
            return true;
        }

        public static int CountPrimes(int[] a, int n)
        {
            int cnt = 0;
            for (int i = 0; i < n; i++)
                if (IsPrime(a[i])) cnt++;
            return cnt;
        }

        public static bool IsPerfectSquare(int x)
        {
            int root = (int)Math.Sqrt(x);
            return root * root == x;
        }

        public static int MinPerfectSquare(int[] a, int n)
        {
            int min = int.MaxValue;
            bool found = false;
            for (int i = 0; i < n; i++)
            {
                if (IsPerfectSquare(a[i]) && a[i] < min)
                {
                    min = a[i];
                    found = true;
                }
            }
            return found ? min : -1;
        }
    }

    // --- LỚP TOÁN HỌC ---
    public static class MathHelper
    {
        public static int ReadPositiveInt(string message)
        {
            int n;
            do { Console.Write(message); }
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);
            return n;
        }

        public static bool IsPrime(int x)
        {
            if (x < 2) return false;
            for (int i = 2; i * i <= x; i++)
                if (x % i == 0) return false;
            return true;
        }

        public static int SumPrimesLessThan(int n)
        {
            int sum = 0;
            for (int i = 2; i < n; i++)
                if (IsPrime(i)) sum += i;
            return sum;
        }
    }

    // --- LỚP XỬ LÝ NGÀY THÁNG ---
    public static class DateHelper
    {
        public static int ReadPositiveInt(string message)
        {
            int n;
            do { Console.Write(message); }
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);
            return n;
        }

        public static bool IsLeapYear(int year)
            => (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);

        public static int DaysInMonth(int month, int year)
        {
            if (month < 1 || month > 12) return -1;
            int[] days = { 31, IsLeapYear(year) ? 29 : 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            return days[month - 1];
        }

        public static bool IsValidDate(int day, int month, int year)
        {
            if (month < 1 || month > 12) return false;
            if (day < 1) return false;
            return day <= DaysInMonth(month, year);
        }

        public static string DayOfWeek(int day, int month, int year)
        {
            if (!IsValidDate(day, month, year)) return "Không hợp lệ";
            if (month < 3) { month += 12; year--; }

            int k = year % 100;
            int j = year / 100;
            int h = (day + 13 * (month + 1) / 5 + k + k / 4 + j / 4 + 5 * j) % 7;
            string[] days = { "Thứ 7", "Chủ nhật", "Thứ 2", "Thứ 3", "Thứ 4", "Thứ 5", "Thứ 6" };
            return days[h];
        }
    }

    // --- LỚP MA TRẬN ---
    public static class MatrixHelper
    {
        private static Random rnd = new Random();

        public static int[,] CreateRandomMatrix(int n, int m, int min = 0, int max = 100)
        {
            int[,] matrix = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    matrix[i, j] = rnd.Next(min, max + 1);
            return matrix;
        }

        public static void PrintMatrix(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write(matrix[i, j] + "\t");
                Console.WriteLine();
            }
        }

        public static int MaxElement(int[,] matrix)
        {
            int max = matrix[0, 0];
            foreach (int x in matrix)
                if (x > max) max = x;
            return max;
        }

        public static int MinElement(int[,] matrix)
        {
            int min = matrix[0, 0];
            foreach (int x in matrix)
                if (x < min) min = x;
            return min;
        }

        public static int RowWithMaxSum(int[,] matrix)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int maxSum = int.MinValue, rowIndex = -1;

            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                for (int j = 0; j < m; j++) sum += matrix[i, j];
                if (sum > maxSum)
                {
                    maxSum = sum;
                    rowIndex = i;
                }
            }
            return rowIndex;
        }

        private static bool IsPrime(int x)
        {
            if (x < 2) return false;
            for (int i = 2; i * i <= x; i++)
                if (x % i == 0) return false;
            return true;
        }

        public static int SumNonPrimes(int[,] matrix)
        {
            int sum = 0;
            foreach (int x in matrix)
                if (!IsPrime(x)) sum += x;
            return sum;
        }

        public static int[,] DeleteRow(int[,] matrix, int k)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (k < 0 || k >= n) return matrix;

            int[,] result = new int[n - 1, m];
            int ri = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == k) continue;
                for (int j = 0; j < m; j++)
                    result[ri, j] = matrix[i, j];
                ri++;
            }
            return result;
        }

        public static int[,] DeleteColumnWithMax(int[,] matrix)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int max = MaxElement(matrix);
            int colIndex = -1;

            for (int j = 0; j < m; j++)
            {
                for (int i = 0; i < n; i++)
                    if (matrix[i, j] == max)
                    {
                        colIndex = j;
                        break;
                    }
                if (colIndex != -1) break;
            }

            if (colIndex == -1) return matrix;
            int[,] result = new int[n, m - 1];
            for (int i = 0; i < n; i++)
            {
                int ci = 0;
                for (int j = 0; j < m; j++)
                {
                    if (j == colIndex) continue;
                    result[i, ci++] = matrix[i, j];
                }
            }
            return result;
        }
    }
}





