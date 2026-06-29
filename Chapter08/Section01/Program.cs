
using System;

namespace Section01 {
    internal class Program {

        static private Dictionary<string, string> prefOfficeDict = new Dictionary<string, string>();

        static void Main(string[] args) {
            string? pref, prefCaptalLocation;
            
            Console.WriteLine("県庁所在地の入力【入力終了:Ctrl + 'Z'】");

            while (true) {

                //①都道府県の入力
                Console.Write("都道府県:");
                pref = Console.ReadLine();
                //if (prefOfficeDict.ContainsKey)

                    
                    if (pref == null) break; //無限ループを抜ける(Ctrl + 'Z')


                //②県庁所在地の入力
                Console.Write("県庁所在地:");
                prefCaptalLocation = Console.ReadLine();

                //③県庁所在地登録処理
                //prefOfficeDict.Add(pref, prefCaptalLocation);
                prefOfficeDict[pref] = prefCaptalLocation;
            }

            while (true) {
                switch (menuDisp()) {
                    case 1:

                        allDisp();
                        break;
                    case 2:
                        serchPrefCaptalLocation();
                        break;
                    case 9:
                        return;
                }
                
            }
        }

        private static void serchPrefCaptalLocation() {
            Console.Write("都道府県:");
            var key = Console.ReadLine();
            if (prefOfficeDict.ContainsKey(key)) {
                var preff = prefOfficeDict[key];
                Console.WriteLine($"{key}の県庁所在地は{preff}です。");
            }
        }

        private static void allDisp() {
            foreach (var p in prefOfficeDict) {
                Console.WriteLine($"{p.Key}の県庁所在地は{p.Value}です。");
            }
        }

        private static int menuDisp() {
            Console.WriteLine("**** メニュー ****\n1:一覧表示\n2:検索\n9:終了");

            var line = Console.ReadLine();
            int num = int.Parse(line);
            return (num);
        }
    }
}
