using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Exercise01_WPF {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e) {
            try {
                OpenFileDialog ofd = new OpenFileDialog();

                if (ofd.ShowDialog() == true) {
                    MessageBox.Show(ofd.FileName);
                    TextArea.Text = await TextReaderSample.ReadTextAsync(ofd.FileName);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }
    }

    static class TextReaderSample {
        public static async Task<string> ReadTextAsync(string fileName) {
            var sb = new StringBuilder();

            //ここに非同期でテキストファイルを読み込む処理を記述する
            using var sr = new StreamReader(fileName);

            var text = await sr.ReadToEndAsync();

            foreach (char ch in text) {
                sb.Append(ch);
            }

            return sb.ToString();
        }
    }
}