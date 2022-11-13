using System.IO;
using System.Reflection;

namespace DatabaseBackupLibrary.ValueObject
{
    class TempFolder
    {
        string appFolderPath;
        DirectoryInfo baseTempFolder;
        DirectoryInfo backupFolder;
        DirectoryInfo backupZipFolder;
        DirectoryInfo restoreFolder;

        public TempFolder()
        {
            Assembly assembly = Assembly.GetEntryAssembly();
            this.appFolderPath = new DirectoryInfo(assembly.Location).Parent.FullName;
            this.baseTempFolder = new DirectoryInfo($"{appFolderPath}\\Temp");
            this.backupFolder = new DirectoryInfo($"{this.baseTempFolder.FullName}\\Backup");
            this.backupZipFolder = new DirectoryInfo($"{this.baseTempFolder.FullName}\\BackupZip");
            this.restoreFolder = new DirectoryInfo($"{this.baseTempFolder.FullName}\\Restore");

            this.baseTempFolder.Create();
            this.backupFolder.Create();
            this.backupZipFolder.Create();
            this.restoreFolder.Create();
        }

        //public DirectoryInfo BaseFolder => this.baseTempFolder;
        public string BaseFolderPaht => this.baseTempFolder.FullName;
        //public DirectoryInfo BackupFolder => this.backupFolder;
        public string BackupFolderPath => this.backupFolder.FullName;
        //public DirectoryInfo BackupZipFolder => this.backupZipFolder;
        public string BackupZipFolderPath => this.backupZipFolder.FullName;
        //public DirectoryInfo RestoreFolder => this.restoreFolder;
        public string RestoreFolderPath => this.restoreFolder.FullName;
    }
}
