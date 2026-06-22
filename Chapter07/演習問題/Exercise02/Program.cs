using Section01;    //Section01プロジェクトにあるBookクラスを利用

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            var books = new List<Book> {
                new Book { Title = "C#プログラミングの新常識", Price = 3800, Pages = 378 },
                new Book { Title = "ラムダ式とLINQの極意", Price = 2500, Pages = 312 },
                new Book { Title = "ワンダフル・C#ライフ", Price = 2900, Pages = 385 },
                new Book { Title = "一人で学ぶ並列処理プログラミング", Price = 4800, Pages = 464 },
                new Book { Title = "フレーズで覚えるC#入門", Price = 5300, Pages = 604 },
                new Book { Title = "私でも分かったASP.NET Core", Price = 3200, Pages = 453 },
                new Book { Title = "楽しいC#プログラミング教室", Price = 2540, Pages = 348 },
            };
            #region
            Console.WriteLine("\n7.2.1");
            Exercise1(books);

            Console.WriteLine("\n7.2.2");
            Exercise2(books);

            Console.WriteLine("\n7.2.3");
            Exercise3(books);

            Console.WriteLine("\n7.2.4");
            Exercise4(books);

            Console.WriteLine("\n7.2.5");
            Exercise5(books);

            Console.WriteLine("\n7.2.6");
            Exercise6(books);

            Console.WriteLine("\n7.2.7");
            Exercise7(books);
            #endregion
        }

        private static void Exercise1(List<Book> books) {
            var wandorfull = books.FirstOrDefault(x => x.Title == "ワンダフル・C#ライフ");
            //Console.WriteLine($"価格:{wandorfull.Price},ページ数:{wandorfull.Pages}");
            if(wandorfull is not null) {
                Console.WriteLine("{0}{1}" + wandorfull.Price + "," + wandorfull.Pages);
            }
        }

        private static void Exercise2(List<Book> books) {
            var cBooks = books.Count(b => b.Title.Contains("C#"));
            Console.WriteLine(cBooks + "冊");
        }

        private static void Exercise3(List<Book> books) {
            var cBooksAve = books.Where(b => b.Title.Contains("C#"));
            Console.WriteLine(cBooksAve.Average(p => p.Pages) + "ページ");
        }

        private static void Exercise4(List<Book> books) {
            var fourPriBook = books.FirstOrDefault(p => 4000 >= p.Price);
            Console.WriteLine(fourPriBook.Title);
        }

        private static void Exercise5(List<Book> books) {
            var fifPri = books.Where(b => b.Price < 4000);
            Console.WriteLine(fifPri.Max(b => b.Pages) + "ページ");
        }

        private static void Exercise6(List<Book> books) {
            var priHigh = books.Where(b => b.Pages >= 400).OrderByDescending(b => b.Pages);
            foreach(var p in priHigh) {
                Console.WriteLine($"{p.Title},{p.Price}");
            }
        }

        private static void Exercise7(List<Book> books) {
            var cBook = books.Where(b => b.Title.Contains("C#") && b.Pages <= 500);
            foreach(var b in cBook) {
                Console.WriteLine(b.Title);
            }
        }
    }
}
