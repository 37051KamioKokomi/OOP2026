

namespace Section04 {
    internal class Program {
        static void Main(string[] args) {

            #region nullの判定
            string? name = "null";
            if(!(name is not null)){
                Console.WriteLine("nameはnullです");
            }
            #endregion

            #region null合体演算子
            string code = "12345";

            //GetMessage()メソッドの戻り値がnullだったら
            //DefaltMessage()目祖度が実行される
            var message = GetMessage(code) ?? DefaltMessage();
            Console.WriteLine(message);

            #endregion

            #region null合体代入演算子
            message = null;
            message ??= DefaltMessage();
            #endregion

            #region null条件演算子
            Sale? sale = new Sale {
                ShopName = "新宿店",
                ProductCategory = "洋菓子",
                Amount = 523100,
            };

            sale = null;

            int? amount = sale?.Amount;
            Console.WriteLine("売上高:" + amount);
            #endregion

        }

        private static object? DefaltMessage() {
            return "DefaltMessage";
        }

        private static object? GetMessage(string code) {
            return code;
        }
    }

    //売り上げクラス
    public class Sale {
        //店舗名
        public string ShopName { get; set; } = string.Empty;
        //商品カテゴリー
        public string ProductCategory { get; set; } = string.Empty;
        //売上高
        public int Amount { get; set; }
    }
}
