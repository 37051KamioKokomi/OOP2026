using Microsoft.Data.Sqlite;
using System.Drawing.Imaging;
using System.Globalization;
using static CarReportSystem.CarReport;

namespace CarReportSystem {
    public class CarReportRepository {
        public List<CarReport> GetAll() {

            var reports = new List<CarReport>();

            using var connection = Database.GetConnection();
            connection.Open();

            using var command = connection.CreateCommand();

            command.CommandText =
                """
                SELECT Id, Date, Author, Maker, CarName, Report, Picture
                FROM CarReports
                ORDER BY Id;
                """;

            using var reader = command.ExecuteReader();

            while (reader.Read()) {
                reports.Add(new CarReport {
                    Id = reader.GetInt32(0),
                    Date = DateTime.ParseExact(
                        reader.GetString(1),
                        "yyyy-MM-dd",
                        CultureInfo.InvariantCulture),

                    Author = reader.GetString(2),
                    Maker = (CarReport.MakerGroup)reader.GetInt32(3),
                    CarName = reader.GetString(4),
                    Report = reader.GetString(5),
                    Picture = reader.IsDBNull(6)
                              ? null : BytesToImage(reader.GetFieldValue<byte[]>(6))
                });
                
            }
            return reports;
        }

        public int Add(CarReport reports) {
            //DateTime date,string author, MakerGroup maker,string carname,string report, Image? Picture
            using var connection = Database.GetConnection();
            connection.Open();
            using var command = connection.CreateCommand();
            command.CommandText =
                """
                INSERT INTO CarReports
                (Date, Author, Maker, CarName, Report, Picture)
                VALUES
                ($date, $author, $maker, $carname, $report, $picture);

                SELECT last_insert_rowid();

                """;

            SetCommandParametaers(reports, command);

            //一つの値を返すSQLを実行する
            var result = command.ExecuteScalar();

            if (result is null) {
                throw new InvalidOperationException("登録した商品のIDを取得できませんでした。");
            }

            // SQLiteのINTERGERはlongとして帰るため、intへ変換する
            return Convert.ToInt32((long)result);

        }

        private static void SetCommandParametaers(CarReport reports, SqliteCommand command) {
            command.Parameters.AddWithValue("$date", reports.Date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
            command.Parameters.AddWithValue("$author", reports.Author);
            command.Parameters.AddWithValue("$maker", reports.Maker);
            command.Parameters.AddWithValue("$carname", reports.CarName);
            command.Parameters.AddWithValue("$report", reports.Report);

            // Update 用の Id パラメータを追加
            command.Parameters.AddWithValue("$id", reports.Id);
            //command.Parameters.AddWithValue("$picture", Picture);

            byte[]? pictureData = ImageToBytes(reports.Picture);

            var pictureParamater = command.Parameters.Add("$picture", SqliteType.Blob);

            if (pictureData is not null) {
                pictureParamater.Value = pictureData;
            } else {
                pictureParamater.Value = DBNull.Value;
            }
        }

        public void Update(CarReport reports) {
            //接続オブジェクトを生成する。
            using var connection = Database.GetConnection();
            connection.Open();
            using var command = connection.CreateCommand();

            command.CommandText =
                """
            UPDATE CarReports
            SET Date = $date,
                Author = $author,
                Maker = $maker,
                CarName = $carname,
                Report = $report,
                Picture = $picture
            WHERE Id = $id;
            """;

            SetCommandParametaers(reports, command);

            
            

            //更新対象が0なら対象が存在しない
            if (command.ExecuteNonQuery() == 0)
                throw new InvalidOperationException("修正対象のレポートが見つかりませんでした。");
        }

        public void Delete(int id) {
            using var connection = Database.GetConnection();
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText =
            """
            DELETE FROM CarReports
            WHERE Id = $id;
            """;


            command.Parameters.AddWithValue("$id", id);

            if (command.ExecuteNonQuery() == 0)
                throw new InvalidCastException("削除対象のレポートが見つかりませんでした。");
            
        }

        // ImageをSQLiteへ保存できるbyte[]へ変換する
        private static byte[]? ImageToBytes(Image? image) {
            if (image is null) return null;

            using var stream = new MemoryStream();
            // DBへはPNG形式で保存
            image.Save(stream, ImageFormat.Png);
            return stream.ToArray();
        }

        // SQLiteのBLOB（byte[]）をImageへ変換する
        private static Image BytesToImage(byte[] data) {
            using var stream = new MemoryStream(data);
            using var image = Image.FromStream(stream);
            // MemoryStream破棄後も利用できるようBitmapとしてコピーする。
            return new Bitmap(image);
        }
    }
}
