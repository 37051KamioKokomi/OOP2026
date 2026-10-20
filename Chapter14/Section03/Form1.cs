using System.Diagnostics;
using System.Threading.Tasks;

namespace Section03 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e) {
            //Thread.Sleep(5000);
            //MessageBox.Show("Š®—¹");

            //await Task.Delay(5000);
            //MessageBox.Show("Š®—¹");

            var elapsed = await DoLongtimeWork(5000);
            MessageBox.Show(elapsed + "ƒ~ƒŠ•b");
        }

        //–ß‚è’l‚È‚µ
        private async Task DoLongtimeWork() {
            await Task.Run(() => {
                Thread.Sleep(5000);
            });
        }

        //–ß‚è’l‚ ‚è
        private async Task<long> DoLongtimeWork(int milliseconds) {
            var sw = Stopwatch.StartNew();
            await Task.Run(() => {
                Thread.Sleep(milliseconds);
            });
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
    }
}
