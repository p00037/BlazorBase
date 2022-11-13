using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DatabaseBackupLibrary.ValueObject
{
    class BackupFile
    {
        private readonly TempFolder tempFolder = new TempFolder();
        private readonly DirectoryInfo saveFolderInfo;
        private readonly string fileName; 

        public BackupFile(DirectoryInfo saveFolderInfo, ConnectionString connectionString)
        {
            this.saveFolderInfo = saveFolderInfo;
            this.fileName = $"{connectionString.InitialCatalog}{DateTime.Now.ToString("yyyyMMddHHmmss")}";
        }

        public string TempFilePath => $"{this.tempFolder.BackupFolderPath}\\{this.fileName}.bak";

        public string TempFolderPath => $"{this.tempFolder.BackupFolderPath}";

        public string TempZipFilePath => $"{this.tempFolder.BackupZipFolderPath}\\{this.fileName}.zip";

        public string TempZipFolderPath => $"{this.tempFolder.BackupZipFolderPath}";

        public string BackupZipFilePath => $"{saveFolderInfo.FullName}\\{this.fileName}.zip";
    }
}
