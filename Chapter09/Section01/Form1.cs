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
            DateTime birth = dtpBirth.Value.Date; //ê∂Ç‹ÇÍÇΩì˙ït
            DateTime today = DateTime.Today; //ç°ì˙ÇÃì˙ït

            //var age = today.Year - birth.Year;
            //if(today < birth.AddYears(age)) {
            //    age--;
            //}
            var age = GetAge(birth, today);
            tbOut.Text = $"Ç†Ç»ÇΩÇÕ{age}çŒÇ≈Ç∑";

            TimeSpan time = (today.Date - birth.Date);
            tbOut2.Text = $"ê∂Ç‹ÇÍÇƒÇ©ÇÁ{time.Days.ToString()}ì˙åoÇøÇ‹ÇµÇΩ";

            var ntf = NthWeek(birth);
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var dayOfWeek = culture.DateTimeFormat.GetDayName(birth.DayOfWeek);
            tbOut3.Text = $"ê∂Ç‹ÇÍÇΩ{birth.Month}åé{birth.Day}ì˙ÇÕëÊ{ntf}èTÇÃ{dayOfWeek}Ç≈Ç∑";

            //íaê∂ì˙ÇÕç°îNÇ©óàîNÇ©ÅAç°ì˙Ç™íaê∂ì˙Ç»ÇÁíaê∂ì˙ÇÕç°ì˙Ç≈Ç∑Ç∆ï\é¶
            //ç°îNÇÃíaê∂ì˙ÇçÏê¨Ç∑ÇÈ
            DateTime thisYearBirthday = new DateTime(today.Year, birth.Month, birth.Day);
            //Ç∑Ç≈Ç…íaê∂ì˙Ç™âﬂÇ¨ÇΩÇ©ÅH
            var next = NextBirth(birth, today);
            if (next == 0) {
                tbOut4.Text = $"íaê∂ì˙ÇÕç°ì˙Ç≈Ç∑";
            } else {
                tbOut4.Text = $"éüÇÃíaê∂ì˙Ç‹Ç≈{next}ì˙Ç≈Ç∑";
            }
        }
        //îNóÓÇãÅÇﬂÇÈÉÅÉ\ÉbÉh
        static int GetAge(DateTime birthday, DateTime targetDay) {
            var age = targetDay.Year - birthday.Year;
            if (targetDay < birthday.AddYears(age)) {
                age--;
            }
            return age;
        }

        //éwíËÇµÇΩì˙Ç™ëÊâΩèTÇ©ãÅÇﬂÇÈ
        static int NthWeek(DateTime date) {
            var firstDay = new DateTime(date.Year, date.Month, 1);
            var firstDayOfWeek = (int)(firstDay.DayOfWeek);
            return (date.Day + firstDayOfWeek - 1) / 7 + 1;
        }

       
        //éüÇÃíaê∂ì˙Ç‹Ç≈ÇÃì˙êîÇãÅÇﬂÇƒï\é¶
        static int NextBirth(DateTime birth, DateTime today) {
            birth.Year = today.Year;
            if (birth.Month == today.Month && ) {
                return 0;
            }else if(birth.Date<today.Date) {
                return birth.Day + ( - today.Day);
            } else {
                return birth.Day - today.Day;
            }
            
        }
    }
}
