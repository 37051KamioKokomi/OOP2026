namespace Exercise01 {
    using System.Globalization;

    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e) {
            var dateatime = DateTime.Now;
            //P200参照
            tbOut1.Text = dateatime.ToString("g");
            //tbOut1.Text = $"{dateatime.Year}/{dateatime.Month}/{dateatime.Day} {dateatime.Hour}:{dateatime.Minute}";
        }

        private void btButton2_Click(object sender, EventArgs e) {
            var datetimea = DateTime.Now;
            tbOut2.Text = datetimea.ToString("yyyy年MM月dd日 HH時mm分ss秒");
            //tbOut2.Text = $"{datetimea.Year}年{datetimea.Month}月{datetimea.Day}日 {datetimea.Hour}時{datetimea.Minute}分{datetimea.Second}秒";
        }

        private void btButton3_Click(object sender, EventArgs e) {
            var dateatime = DateTime.Now;
            var culture = new CultureInfo("ja-jp");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            tbOut3.Text = dateatime.ToString("ggyy年MM月dd日 (dddd)", culture);
            //tbOut3.Text = $"{dateatime.Year}年 {dateatime.Month}月 {dateatime.Day}日 ({dateatime.DayOfWeek})";
        }

        private void tbOut1_TextChanged(object sender, EventArgs e) {

        }

        private void tbOut2_TextChanged(object sender, EventArgs e) {

        }

       
    }
}
