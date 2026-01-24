using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstApplication
{
    public static class Files
    {
        public static void workWithFiles()
        {
            string filePath = @"C:\Users\Salma\Desktop\Desktop\GitHub\Software-Development\Languages\C#\LanguageBlocks\MyFirstApplication\test\test.txt";
            FileInfo fileInfo = new FileInfo(filePath);
            if (fileInfo.Exists)
            {
                Util.printValue(fileInfo.DirectoryName);
            }
            /*
             * output
             * C:\Users\Salma\Desktop\Desktop\GitHub\Software-Development\Languages\C#\LanguageBlocks\MyFirstApplication\test
             */

            // creae directory
            string directoryPath = @"C:\Users\Salma\Desktop\Desktop\GitHub\Software-Development\Languages\C#\LanguageBlocks\MyFirstApplication\test\test-directory";
            Directory.CreateDirectory(directoryPath);
            string[] directoryFiles = Directory.GetFiles(directoryPath);
            foreach (string path in directoryFiles)
            {
                Util.printValue(path);
            }
            /*
             * output
             * C:\Users\Salma\Desktop\Desktop\GitHub\Software-Development\Languages\C#\LanguageBlocks\MyFirstApplication\test\test-directory\something.txt
             */

            // directory info
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
            directoryInfo.CreateSubdirectory(@"test3");
            DirectoryInfo[] directories = directoryInfo.GetDirectories();
            foreach (DirectoryInfo directory in directories)
            {
                Util.printValue(directory.FullName);
            }
            directoryInfo.Delete(true); // recursive deletion
            /*
             * output
             * C:\Users\Salma\Desktop\Desktop\GitHub\Software-Development\Languages\C#\LanguageBlocks\MyFirstApplication\test\test-directory\test3
             */

            // get drive info
            DriveInfo driveInfo = new DriveInfo("G:");

            // file stream
            string filePath2 = @"C:\Users\Salma\Desktop\Desktop\GitHub\Software-Development\Languages\C#\LanguageBlocks\MyFirstApplication\test\test2.txt";
            byte[] content = System.Text.Encoding.ASCII.GetBytes("something");
            FileStream fileStream = new FileStream(filePath2, FileMode.Create, FileAccess.Write);
            fileStream.Write(content, 0, content.Length);

            // stream reader and stream writer
            using (StreamWriter streamWriter = new StreamWriter(fileStream))
            {
                streamWriter.WriteLine("something else");
                streamWriter.Close();
            } // streamWriter.Close() called automatically here
            System.Console.ReadKey();
            fileStream.Close();
            File.Delete(filePath2);
        }
    }
}
