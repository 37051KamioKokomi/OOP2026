using System.Globalization;

namespace Section01 {
    public partial class pbPic : Form {
        public pbPic() {
            InitializeComponent();
        }

        private void btGet_Click(object sender, EventArgs e) {
            DateTime date = dtpDate.Value;
            //DateTime datee = nudDay.
            var dateee = date.AddDays(2);
            tbOut.Text = date.AddDays((double)nudDay.Value).ToString();//$"{date.AddDays(2)}"



        }

        

        private void btBirthCalc_Click(object sender, EventArgs e) {
            DateTime birth = dtpBirth.Value; //ê∂Ç‹ÇÍÇΩì˙ït
            DateTime today = DateTime.Today; //ç°ì˙ÇÃì˙ït
            var age = today.Year - birth.Year;
            if(today < birth.AddYears(age)) {
                age--;
            }
            tbOut.Text = $"Ç†Ç»ÇΩÇÕ{age.ToString()}çŒÇ≈Ç∑";
            var time = (today.Date - birth.Date);
            tbOut2.Text = $"ê∂Ç‹ÇÍÇƒÇ©ÇÁ{time.Days.ToString()}ì˙åoÇøÇ‹ÇµÇΩ";
        }
    }
}
