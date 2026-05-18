namespace Section01 {
    internal class Program {

        

        static void Main(string[] args) {
            var numbers = new[] { 5, 3, 9, 6, 7, 5, 8, 1, 0, 5, 10, 4 };

            var count = Count(numbers, n => n % 4 == 0 || n % 5 == 0);//delegate(int n){ return n % 2 == 0; });//処理の異常
            Console.WriteLine(count);
        }

        static int Count(int[] numbers,Predicate<int> judge) {//山かっこ、型引数
            
            var count = 0;
            foreach (var n in numbers) {
                if (judge(n) == true) {
                    count++;
                }
            }
            return count;
        }
    }
}
