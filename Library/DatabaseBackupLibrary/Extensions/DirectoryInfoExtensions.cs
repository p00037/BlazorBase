using System.IO;

namespace DatabaseBackupLibrary.Extensions
{
    public static class DirectoryInfoExtensions
    {
        public static void DeleteAllFile(this DirectoryInfo source)
        {
            FileInfo[] files = source.GetFiles();
            foreach (FileInfo file in files)
            {
                file.Delete();
            }
        }
    }
}
