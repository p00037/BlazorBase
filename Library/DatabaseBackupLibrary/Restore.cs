using DatabaseBackupLibrary.Extensions;
using DatabaseBackupLibrary.ValueObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using ZipLibrary;

namespace DatabaseBackupLibrary
{
    public class Restore
    {
        private readonly TempFolder tempFolder = new TempFolder();
        private readonly ConnectionString connectionString;

        public Restore(string connectionString)
        {
            this.connectionString = new ConnectionString(connectionString);
        }

        public void Execute(string zipFilePath, string password)
        {
            DeleteAllFile();
            UnZipFile(zipFilePath, password);
            RestoreDataBase();
            DeleteAllFile();
        }

        private void DeleteAllFile()
        {
            new DirectoryInfo(this.tempFolder.RestoreFolderPath).DeleteAllFile();
        }

        private void UnZipFile(string filePath, string password)
        {
            ZipFile.ExtractToDirectory(filePath, this.tempFolder.RestoreFolderPath, password);
        }

        private void RestoreDataBase()
        {
            // SQLサーバのマスタDBに接続する
            using (var con = new SqlConnection())
            {


                con.ConnectionString = this.connectionString.MasterConnectionString;
                con.Open();

                // リストア(復元)SQLはDB接続しているセッションが存在すると失敗するので、
                // 事前に全てのDB接続を切断して置くする必要があります。
                KillUser(con);

                // テストDBをリストア(復元)するSQL作成
                var sql = $"RESTORE DATABASE {this.connectionString.InitialCatalog} FROM DISK = '{GetBakFilePath()}' WITH REPLACE;";
                using (var sqlCommand = new SqlCommand(sql, con))
                {
                    using (var adapter = new SqlDataAdapter(sqlCommand))
                    {
                        // リストア(復元)開始
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                    }
                }
                // SQLサーバのマスタDBから切断する
                con.Close();
            }
        }

        private void KillUser(SqlConnection con)
        {
            // 全てのDB接続セッション取得SQL作成
            var sql = @"SELECT spid FROM master..sysprocesses,master..sysdatabases " +
                        $"WHERE master..sysprocesses.dbid = master..sysdatabases.dbid AND name = '{this.connectionString.InitialCatalog}';";
            using (var sqlCommand = new SqlCommand(sql, con))
            {
                using (var adapter = new SqlDataAdapter(sqlCommand))
                {
                    // 全てのDB接続セッション取得
                    var dt = new DataTable();
                    adapter.Fill(dt);

                    foreach (DataRow dataRow in dt.Rows)
                    {
                        KillSpid(con, dataRow[0].ToString());
                    }
                }
            }
        }

        private void KillSpid(SqlConnection con, string spid)
        {
            // 個々のDB接続セッションを強制切断SQL作成
            var sql = $"KILL {spid}";
            using (var sqlCommand = new SqlCommand(sql, con))
            {
                using (var adapter = new SqlDataAdapter(sqlCommand))
                {
                    // 個々のDB接続セッションを強制切断
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                }
            }
        }

        private string GetBakFilePath()
        {
            List<FileInfo> files = new DirectoryInfo(tempFolder.RestoreFolderPath).GetFiles("*.bak").ToList();

            if (!files.Any())
            {
                throw new Exception("復元できるファイルではありません。");
            }

            return files.First().FullName;
        }
    }
}
