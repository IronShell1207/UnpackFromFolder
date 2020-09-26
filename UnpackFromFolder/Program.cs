using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnpackFromFolder
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.Write("If the path is correct press Y to continue moving \nOr press other button to change the path: ");
            var ButtonCD = Console.ReadKey().Key;
            var pathC = Environment.CurrentDirectory;
            if (ButtonCD != ConsoleKey.Y)
            {
                Console.Write("\nSelected directory: ");
                pathC = BrouseFolder();
                
            }
            Console.WriteLine("\n"+pathC+"\nPress any button to continue...");
            Console.ReadKey();
            FolderReplaces(pathC);
            Console.WriteLine("Press any button to close the app");
            Console.ReadKey();
        }// 
        static string BrouseFolder()
        {
            FolderBrowserDialog dc = new FolderBrowserDialog
            {
                Description = "Select folder"
            };
            dc.ShowDialog();
            return dc.SelectedPath;
        }
        static void FolderReplaces(string path)
        {
            var dirs = new DirectoryInfo(path).GetDirectories();
            foreach (DirectoryInfo dir in dirs)
            {
                Console.WriteLine("Current directory: " + dir.FullName);
                var files = dir.GetFiles();
                foreach (FileInfo file in files)
                {
                    Console.WriteLine("Move " + file.FullName + " to " + path);
                    file.MoveTo(path+@"\"+file.Name);
                }
                Console.WriteLine(dir.FullName+" deleted");
                dir.Delete();
            }
        }
    }
}
