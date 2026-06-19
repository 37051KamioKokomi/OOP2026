
using System;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            int[] numbers = [5, 10, 17, 9, 3, 21, 10, 40, 21, 3, 35];
            #region
            Console.WriteLine("\n7.1.1");
            Exercise1(numbers);

            Console.WriteLine("\n7.1.2");
            Exercise2(numbers);

            Console.WriteLine("\n7.1.3");
            Exercise3(numbers);

            Console.WriteLine("\n7.1.4");
            Exercise4(numbers);

            Console.WriteLine("\n7.1.5");
            Exercise5(numbers);
            #endregion
        }


        private static void Exercise1(int[] numbers) {
            var maxNum = numbers.Max();
            Console.WriteLine($"最大値:{maxNum}");
        }

        private static void Exercise2(int[] numbers) {
            var lastSecNum = numbers.TakeLast(2);
            foreach(var num in lastSecNum) {
                Console.WriteLine($"{num}");
            }
        }

        private static void Exercise3(int[] numbers) {
            var zeroNum = numbers.Select(n => n.ToString("000"));
            foreach (var num in zeroNum) {
                Console.WriteLine($"{num}");
            }
        }

        private static void Exercise4(int[] numbers) {
            var smallNum = numbers.Order().Take(3);
            foreach (var num in smallNum) {
                Console.WriteLine($"{num}");
            }
        }

        private static void Exercise5(int[] numbers) {
            var tenOverNum = numbers.Distinct().Count(n => n > 10);
            Console.WriteLine($"{tenOverNum}");
        }
    }
}
