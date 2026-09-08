using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static CarReportSystem.CarReport;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CarReportSystem {
    public class CarReportRepository {
        public List<CarReport> GetAll() {

            var carreports = new List<CarReport>();

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
                carreports.Add(new CarReport {
                    Id = reader.GetInt32(0),
                    Date = DateTime.ParseExact(
                        reader.GetString(1),
                        "yyyy-mm-dd",
                        CultureInfo.InvariantCulture),

                    Author = reader.GetString(2),
                    Maker = (CarReport.MakerGroup)reader.GetInt32(3),
                    CarName = reader.GetString(4),
                    Report = reader.GetString(5),
                    Picture = reader.IsDBNull(6)
                              ? null : BytesToImage(reader.GetFieldValue<byte[]>(6))
                });
                
            }
            return carreports;
        }

        public int Add(DateTime date,string author, MakerGroup maker,string carname,string report, Image? Picture) {
            using var connection = Database.GetConnection();
            connection.Open();
            using var command = connection.CreateCommand();
            command.CommandText =
                """
                INSERT INTO CarReports
                (Date, Author, Maker, CarName,Report, Picture)
                VALUES
                (&date, $author, $maker, $carname, $report, $picture);

                SELECT last_insert_rowid();

                """;

            command.Parameters.AddWithValue("$date", date);
            command.Parameters.AddWithValue("$author", author);
            command.Parameters.AddWithValue("$maker", maker);
            command.Parameters.AddWithValue("$carname", carname);
            command.Parameters.AddWithValue("$report", report);
            command.Parameters.AddWithValue("$picture", Picture);

            //一つの値を返すSQLを実行する
            var result = command.ExecuteScalar();

            if (result is null) {
                throw new InvalidOperationException("登録した商品のIDを取得できませんでした。");
            }

            // SQLiteのINTERGERはlongとして帰るため、intへ変換する
            return Convert.ToInt32((long)result);
            
        }

        public void Update(CarReport carReport) {
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
            WHERE Id = $id;
            """;

            command.Parameters.AddWithValue("$date", carReport.Date);
            command.Parameters.AddWithValue("$author", carReport.Author);
            command.Parameters.AddWithValue("$maker", carReport.Maker);
            command.Parameters.AddWithValue("$carname", carReport.CarName);
            command.Parameters.AddWithValue("$report", carReport.Report);
            command.Parameters.AddWithValue("$picture", carReport.Picture);

            //更新対象が0なら対象が存在しない
            if (command.ExecuteNonQuery() == 0)
                throw new InvalidOperationException("修正対象の商品が見つかりませんでした。");
        }

        public void Delete(int id) {
            using var connection = Database.GetConnection();
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText =
            """
            DELETE FROM Products
            WHERE Id = $id;
            """;

            command.Parameters.AddWithValue("$id", id);
            command.ExecuteNonQuery();
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
