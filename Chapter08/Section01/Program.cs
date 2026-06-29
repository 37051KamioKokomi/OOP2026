
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

                //すでに都道府県が登録されているか？
                if (prefOfficeDict.ContainsKey(pref)) {
                    Console.WriteLine("上書きしますか？(Y/N)");
                    if (Console.ReadLine() == "N") continue;
                }

                //③県庁所在地登録処理
                //prefOfficeDict.Add(pref, prefCaptalLocation);
                prefOfficeDict[pref] = prefCaptalLocation;
                Console.WriteLine();//改行
            }

            Boolean endFlag = false; //終了フラグ(メニューの無限ループを抜ける用)
            while (!endFlag) {
                switch (menuDisp()) {
                    case 1://一覧出力処理

                        allDisp();
                        break;
                    case 2:
                        serchPrefCaptalLocation();
                        break;
                    case 9:
                        endFlag = true;
                        break;
                }
            }
        }

        //メニュー表示
        private static int menuDisp() {
            Console.WriteLine("**** メニュー ****\n1:一覧表示\n2:検索\n9:終了");
            Console.Write(">");
            ///メニュー番号を表示させて呼び出し元へ返却
            var line = Console.ReadLine();
            int num = int.Parse(line);
            return (num);
        }

        //一覧表示処理
        private static void allDisp() {
            ///コレクション(PrefOfficeDict)の中身をすべて出力
            foreach (var p in prefOfficeDict) {
                Console.WriteLine($"{p.Key}の県庁所在地は{p.Value}です。");
            }
        }

        //検索処理
        private static void serchPrefCaptalLocation() {
            Console.Write("都道府県:");
            var key = Console.ReadLine();
            if (key is null) return;
            ///検索した結果を表示
            if (prefOfficeDict.ContainsKey(key)) {
                var preff = prefOfficeDict[key];
                Console.WriteLine($"{key}の県庁所在地は{preff}です。");
            }
        }
    }
}
