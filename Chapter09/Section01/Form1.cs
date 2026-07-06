namespace Section01 {
    public partial class pbPic : Form {
        public pbPic() {
            InitializeComponent();
        }

        private void btGet_Click(object sender, EventArgs e) {
            DateTime dt1 = dtpDate.Value;

            if (DateTime.IsLeapYear(dt1.Year)) {
                tbOut.Text = "‚¤‚é‚¤”N‚Å‚·";
            } else {
                tbOut.Text = "‚¤‚é‚¤”N‚Å‚Í‚ ‚è‚Ü‚¹‚ñ";
            }

            switch (dt1.DayOfWeek) {
                case DayOfWeek.Saturday:
                    tbOut.Text = "¡“ú‚Í“y—j“ú‚Å‚·B";
                    break;
                case DayOfWeek.Sunday:
                    tbOut.Text = "¡“ú‚Í“ú—j“ú‚Å‚·B";
                    break;
                case DayOfWeek.Monday:
                    tbOut.Text = "¡“ú‚ÍŒ—j“ú‚Å‚·B";
                    break;
                case DayOfWeek.Tuesday:
                    tbOut.Text = "¡“ú‚Í‰Î—j“ú‚Å‚·B";
                    break;
                case DayOfWeek.Wednesday:
                    tbOut.Text = "¡“ú‚Í…—j“ú‚Å‚·B";
                    break;
                case DayOfWeek.Thursday:
                    tbOut.Text = "¡“ú‚Í–Ø—j“ú‚Å‚·B";
                    break;
                case DayOfWeek.Friday:
                    tbOut.Text = "¡“ú‚Í‹à—j“ú‚Å‚·B";
                    break;
            }
        }
    }
}
