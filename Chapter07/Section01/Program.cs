namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var numbers = new List<int> { 9, 7, 5, 4, 2, 5, 4, 0, 4, 1, 0, 4 };

            var books = Books.GetBooks();
            var priceAverage = books.Average(x => x.Price);
            var pageAverage = books.Sum(x => x.Pages);
            var maxPrice = books.Max(x => x.Price);
            

            Console.WriteLine("平均金額:" + priceAverage);
            Console.WriteLine("合計ページ:" + pageAverage);
            Console.WriteLine("高価な本:" + maxPrice);

            Console.WriteLine("--- 500円以上の本 ---");
            var fifPrice = books.Where(x => 500 <= x.Price ).ToList();
            fifPrice.ForEach(x => Console.WriteLine(x.Title));

            foreach(var book in books.Where(x => x.Price >= 500)){
                Console.WriteLine(book.Title);
            }

            //本のページが250ページ以上の本を上位三冊出力
            //var twoFivePege =();
            //twoFivePege.ForEach(Console.WriteLine(x.Title));
            Console.WriteLine("--- 250ページ以上の本 ---");
            foreach (var book in books.Where(x => x.Pages >= 250).Take(3)) {
                Console.WriteLine(book.Title);
            }



        }
    }
}
