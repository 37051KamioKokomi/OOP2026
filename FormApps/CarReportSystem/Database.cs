using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReportSystem {
    internal class Database {
        private static readonly string DatabasePath =
            Path.Combine(AppContext.BaseDirectory, "carreport.db");

        private static readonly string ConnectionString =
            $"Data Source={DatabasePath}";

        public static SqliteConnection GetConnection()
            => new SqliteConnection(ConnectionString);

        public static void Initialize() {
            //接続して CREATE TABLE IF NOT EXISTS を実行
            using var connection = GetConnection();
            connection.Open();
            using var command = CreateCommand();

        }
        //CREATE TABLE 
    }
}
