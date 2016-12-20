using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cs_Daily_File_Transfer
{
    public class ModTimeCheck
    {
        public static bool modTimeCheck()
        {
            DateTime mT = File.GetLastWriteTime(sourcePath);
            DateTime currentTime = DateTime.Now;

            string[] txtFiles = Directory.GetFiles(sourcePath, fileExt);

            if (mT.AddDays(1) >= currentTime)
                return true;
            else
                return false;
        }
    }

    public class MoveFiles
    {
        public string move_files()
        {
            string sourcePath = "C:\\LocalSourceFiles\\Cs_Daily_File_Transfer\\Daily";
            string destPath = "C:\\LocalSourceFiles\\Cs_Daily_File_Transfer\\Home_Office";
            string fileExt = "*.txt";

            ModTimeCheck mTC = new ModTimeCheck();

            if (mTC.modTimeCheck(true))
            {
                foreach (var item in txtFiles)
                {
                    File.Copy(item, Path.Combine(destPath, Path.GetFileName(item)));
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MoveFiles mF = new MoveFiles();
            mF.move_files();



            Console.ReadKey();
        }
    }
}
