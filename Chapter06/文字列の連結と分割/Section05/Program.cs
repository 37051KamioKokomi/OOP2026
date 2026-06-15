using System.Text;
namespace Section05 {
    internal class Program {
        static void Main(string[] args) {
            var sb = new StringBuilder();
            var separator = ",";
            var words = String.Join(separator,GetWords() );
            Console.Write(words);
            //sb.Append(word);

        }

        private static IEnumerable<object> GetWords() {
            return ["Orange", "Lemon", "Strawberry"];
        }
    }
}
