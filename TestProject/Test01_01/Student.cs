namespace Test01_01 {
    //学生クラス
    public class Student {
        //学生の名前
        public string Name { get; private set; } = string.Empty;
        //科目名
        public string Subject { get; private set; } = string.Empty;
        //点数
        public int Score { get; private set; } = 0; 
    }
}
