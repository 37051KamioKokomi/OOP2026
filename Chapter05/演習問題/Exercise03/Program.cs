using Exercise01;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            var day1 = new YearMonth(2006,3) ;
            var day2 = new YearMonth(2006,3) ;
            if (day1 == day2) {
                Console.WriteLine("等しい");
            } else {
                Console.WriteLine("等しくない");
            }
        }
    }
}
