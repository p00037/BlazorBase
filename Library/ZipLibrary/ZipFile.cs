using System;
using System.Collections.Generic;
using System.Text;

namespace ZipLibrary
{
    public static class ZipFile
    {
        public static void CreateFromDirectory(string directoryPath, string filePath, string password = "")
        {
            //作成するZIP書庫のパス
            //ファイルが既に存在している場合は、上書きされる
            string zipFileName = filePath;
            //圧縮するフォルダのパス
            string sourceDirectory = directoryPath;
            //サブディレクトリも圧縮するかどうか
            bool recurse = true;

            //FastZipオブジェクトの作成
            ICSharpCode.SharpZipLib.Zip.FastZip fastZip =
                new ICSharpCode.SharpZipLib.Zip.FastZip();
            //空のフォルダも書庫に入れるか。デフォルトはfalse
            fastZip.CreateEmptyDirectories = true;
            //ZIP64を使うか。デフォルトはDynamicで、状況に応じてZIP64を使う
            //（大きなファイルはZIP64でしか圧縮できないが、対応していないアーカイバもある）
            fastZip.UseZip64 = ICSharpCode.SharpZipLib.Zip.UseZip64.Dynamic;
            //パスワードを設定するには次のようにする
            fastZip.Password = password;

            //圧縮してZIP書庫を作成
            fastZip.CreateZip(zipFileName, sourceDirectory, recurse, "");
        }


        public static void ExtractToDirectory(string filePath,string directoryPath, string password = "")
        {
            //展開するZIP書庫のパス
            string zipFileName = filePath;
            //展開したファイルを保存するフォルダ（存在しないと作成される）
            string targetDirectory = directoryPath;
            //展開するファイルのフィルタ
            string fileFilter = "";

            //FastZipオブジェクトの作成
            ICSharpCode.SharpZipLib.Zip.FastZip fastZip =
                new ICSharpCode.SharpZipLib.Zip.FastZip();
            //属性を復元するか。デフォルトはfalse
            fastZip.RestoreAttributesOnExtract = true;
            //ファイル日時を復元するか。デフォルトはfalse
            fastZip.RestoreDateTimeOnExtract = true;
            //空のフォルダも作成するか。デフォルトはfalse
            fastZip.CreateEmptyDirectories = true;

            //パスワードが設定されているとき
            //パスワードが設定されている書庫をパスワードを指定せずに展開しようとすると、
            //　例外ZipExceptionがスローされる
            fastZip.Password = password;

            //ZIP書庫を展開する
            fastZip.ExtractZip(zipFileName, targetDirectory, fileFilter);
        }
    }
}
