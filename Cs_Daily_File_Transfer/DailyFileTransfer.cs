using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cs_Daily_File_Transfer
{
    
    class ModTimeCheck
    {
        static void Main(string[] args)
        {
            string sourcePath = "C:\\LocalSourceFiles\\Cs_Daily_File_Transfer\\Daily";
            string destPath = "C:\\LocalSourceFiles\\Cs_Daily_File_Transfer\\Home_Office";
            string fileExt = "*.txt";
            string[] txtFiles = Directory.GetFiles(sourcePath, fileExt);

            foreach (var file in txtFiles)
            {
                if (modTimeCheck(file))
                {
                    string fileName = Path.GetFileName(file);
                    File.Copy(file, Path.Combine(destPath, fileName));

                    Console.WriteLine("Copying ... {0}", fileName);
                }
            }

            Console.WriteLine("\nFile Transfer Complete ... Press ENTER");
            Console.ReadLine();
        }

        public static bool modTimeCheck(string fileName)
        {
            DateTime currentTime = DateTime.Now;

            FileInfo fileNameInfo = new FileInfo(fileName);

            if (fileNameInfo.LastWriteTime.AddDays(1) >= DateTime.Now)
                return true;
            else
                return false;
        }

    }
}
