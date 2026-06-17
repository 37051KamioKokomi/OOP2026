using System.Diagnostics.Tracing;

namespace Exercise04 {
    internal class Program {
        static void Main(string[] args) {
            var line = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";

            string[]words = line.Split(';');
            
            foreach (var word in words) {
                var wordss = word.Split('=');
                Console.WriteLine(ToJapanese(wordss[0]) + ":" + wordss[1]);

            }
            //for(int i = 0; i < words.Length; i++) {
            //    if (word == null) {

            //    }
            //    var wordd = words[i].Split('=');

            //}


            //var lines = 
            ////ToJapanese();
            //Console.WriteLine($"");
            //string[] ans = { "0", "0", "0", "0", "0", "0" };
            //for(int i = 1; i < ans.Length/2; i += 2) {
            //    Console.WriteLine(ToJapanese(ans[i]));
            //    Console.WriteLine(ToJapanese(ans[i + 1]));
            //}



        }
        static string ToJapanese(string key) {
            return key switch {
                "Novelist" => "作家",
                "BestWork" => "代表作",
                "Born" => "誕生年",
                _ => "引数keyは、正しい値ではありません"
            };
            //古い書き方
            //switch (key) {
            //    case "Novelist":　
            //        return "作家";
            //    case "BestWork":
            //        return "代表作";
            //    case "Born":
            //        return "誕生年";
            //    default:
            //        return "引数keyは、正しい値ではありません";
            //}
        }
    }
}
