using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
namespace Exercise01 {
    internal class Program {


        static void Main(string[] args) {
            var text = "Cozy lummux gives smart squid who asks for job pen";

            Exercise1(text);
            Console.WriteLine();
            Exercise2(text);

        }

        private static void Exercise1(string text) {
            //コミットのコメント(問題8.1.1完成)
            var dict = new Dictionary<char,int>();

            
            foreach (var t in text) {
                //辞書のキーに登録されているか ?
                if (dict.ContainsKey(t))
                    //登録されている場合
                    dict[t] += dict[t]; //売り上げを足しこみ
                Console.WriteLine(dict[t]);
                //else
                //    //未登録の場合
                //    dict[sale.ShopName] = sale.Amount; //新規に売り上げを登録
            }
            //// 要素を追加
            // public void Add(string abbr, string japanese) => ;

            

            char ch = 'A';

            if ('A' <= ch && ch <= 'Z') {

            }
        }

        

        private static void Exercise2(string text) {
            //コミットのコメント(問題8.1.1完成)

        }

    }
}
