namespace Test01_01 {
    //点数集計クラス
    public class ScoreCounter {
        
        private IEnumerable<Student> _score;

        // コンストラクタ
        public ScoreCounter(string filePath) {
            _score = ReadScore(filePath);
        }

        
        private static IEnumerable<Student> ReadScore(string filePath) {
            var students = new List<Student>();　//リスト
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines) {
                var items = line.Split(','); //カンマ区切りで分割
                var student = new Student {
                    Name = items[0],
                    Subject = items[1],
                    Score = int.Parse(items[2])
                };
                students.Add(student);
            }
            return students;
        }

        //メソッドの概要：
        public IDictionary<string, int> GetPerStudentScore() {
            var dict = new Dictionary<string, int>();
            foreach (var student in _score) {
                //既に科目名が辞書のキーに登録されているか?
                if (dict.ContainsKey(student.Subject))
                    //登録されている場合
                    dict[student.Subject] += student.Score; //売り上げを足しこみ
                else
                    //未登録の場合
                    dict[student.Subject] = student.Score; //新規に売り上げを登録
            }
            return dict;
        }
    }
}
