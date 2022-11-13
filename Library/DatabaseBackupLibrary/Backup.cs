using DatabaseBackupLibrary.Extensions;
using DatabaseBackupLibrary.ValueObject;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using ZipLibrary;

namespace DatabaseBackupLibrary
{
    public class Backup
    {
        private readonly ConnectionString connectionString;

        public Backup(string connectionString)
        {
            this.connectionString = new ConnectionString(connectionString);
        }

        public void Execute(string folderPath, string password)
        {
            var backupFile = new BackupFile(new DirectoryInfo(folderPath), this.connectionString);

            DeleteTempFile(backupFile);
            CreateBackupFile(backupFile);
            CreateZipFile(backupFile, password);
            FileCopy(backupFile);
            DeleteTempFile(backupFile);
        }

        private void CreateBackupFile(BackupFile backupFile)
        {
            // SQLサーバに接続する
            using (var con = new SqlConnection())
            {
                con.ConnectionString = this.connectionString.Value;
                con.Open();

                // DBをバックアップするSQL作成
                var sql = $"BACKUP DATABASE {this.connectionString.InitialCatalog} TO DISK = '{backupFile.TempFilePath}' WITH FORMAT," +
                            $"NAME = 'Full Backup of {this.connectionString.InitialCatalog}';";
                using (var sqlCommand = new SqlCommand(sql, con))
                {
                    using (var adapter = new SqlDataAdapter(sqlCommand))
                    {
                        // バックアップ開始
                        var dt = new DataTable();
                        adapter.Fill(dt);
                    }
                }                    

                // SQLサーバのDBから切断する
                con.Close();
            }
                
        }

        private void CreateZipFile(BackupFile backupFile, string password)
        {
            ZipFile.CreateFromDirectory(backupFile.TempFolderPath, backupFile.TempZipFilePath, password);
        }

        private void FileCopy(BackupFile backupFile)
        {
            File.Copy(backupFile.TempZipFilePath, backupFile.BackupZipFilePath);
        }

        private void DeleteTempFile(BackupFile backupFile)
        {
            new DirectoryInfo(backupFile.TempFolderPath).DeleteAllFile();
            new DirectoryInfo(backupFile.TempZipFolderPath).DeleteAllFile();
        }
    }
}
