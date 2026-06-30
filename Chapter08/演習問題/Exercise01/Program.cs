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
            var dict = new Dictionary<char, int>();

            foreach (var ch in text.ToUpper()) {
                if ('A' <= ch && ch <= 'Z') {
                    if (dict.ContainsKey(ch))
                        //登録されている場合
                        dict[ch]++;
                    else
                        dict[ch] = 1;
                }
            }

            foreach (var item in dict.OrderBy(x => x.Key)) {
                Console.WriteLine("{0}:{1}",item.Key,item.Value);
            }
            
        }

        

        private static void Exercise2(string text) {
            //コミットのコメント(問題8.1.2完成)

        }

    }
}
