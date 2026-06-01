using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    //5.1.1
    public class YearMonth {
        //プロパティ(p114参照)
        public int Year { get; init; }
        public int Month { get; init; }

        //コンストラクタ
        public YearMonth(int year, int month) {
            Year = year;
            Month = month;
        }

        //5.1.2(p116参照)
        //設定されているプロパティが21世紀か確認する。
        //Yearが2001~2100ならtrue、それ以外ならfalseを返す。
        public bool Is21Century => 2001 <= Year && Year <= 2100;


        //5.1.3
        //public YearMonth AddOneMonth(int month) {
        //    var y1 = new YearMonth();
        //}

        //5.1.4
        //public override string ToString() =>;
        
            }
}

