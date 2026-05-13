
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            // 2.1.3
            //var songs = new Song[] {
            //    new Song("Let it be", "The Beatles", 243),
            //    new Song("Bridge Over Troubled Water", "Simon & Garfunkel", 293),
            //    new Song("Close To You", "Carpenters", 276),
            //    new Song("Honesty", "Billy Joel", 231),
            //    new Song("I Will Always Love You", "Whitney Houston", 273),
            //};
            //PrintSongs(songs);
            //歌のデータを入れるリストオブジェクトを出力
            var songs = new List<Song>(); //コレクション
            //var songs = new Song[5];
            Console.WriteLine("***** 曲の登録 *****");
            //var sc = Console.ReadLine();
            //何件入力があるかわからないので無限ループ
            while (true) {
                Console.Write("曲名:");
                string? title =Console.ReadLine();
                if(title.Equals("end",StringComparison.OrdinalIgnoreCase)) { 
                    //title == "end" || title == "END"
                    //p.31を参考にしてもいいがこういう書き方もある。
                    break;
                }
                Console.Write("アーティスト名:");
                string? artistname = Console.ReadLine();
                Console.Write("演奏時間(秒):");
                //int length = Console.Read();
                //Console.ReadLine(); //Console.ReadLine()を使う場合はバッファをクリアする
                int length = int.Parse(Console.ReadLine());
                Console.WriteLine();

                //Songインスタンスを生成
                Song song = new Song(title, artistname, length);
                songs.Add(song);

                //var items = line.Split(','); //カンマ区切りで分割
                //Song song = new Song(title,artistname,length) {
                //    Title = title,
                //    ProductCategory = items[1],
                //    Amount = int.Parse(items[2])
                //};
            }

            PrintSongs(songs);
        }

        //Mainメソッド内のPrintSongs(songs);をクリックして
        //Alt + Enterを押すと、以下のメソッドが自動的に作成される
        //2.1.4
        private static void PrintSongs(IEnumerable <Song> songs) {
            foreach (var song in songs) {
                //var minutes = song.Length / 60;
                //var seconds = song.Length % 60;
                Console.WriteLine($"{song.Title},{song.ArtistName},{song.Length / 60}:{(song.Length % 60):00}");
            }
            //ゼロサプレス
        }
    }
}
