using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class DirectoryTraversal
{
    static void Main(string[] args)
    {
        //regardin RECURSION comment bellow the program, will be done after 31.MAY.2015 :)
        //http://stackoverflow.com/questions/837488/how-can-i-get-the-applications-path-in-a-net-console-application
        // to get the location the assembly is executing from
        //(not neccesarily where the it normally resides on disk)
        // in the case of the using shadow copies, for instance in NUnit tests, 
        // this will be in a temp directory.
        string startPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
        //once you have the path you get the directory with:
        var directory = Path.GetDirectoryName(startPath);
        Console.WriteLine(directory);
        string[] filePaths = Directory.GetFiles(directory);
        List<FileInfo> files = filePaths.Select(path => new FileInfo(path)).ToList();//Katya Marincheva
        var sorted =
           files.OrderBy(file => file.Length).GroupBy(file => file.Extension).OrderByDescending(group => group.Count()).ThenBy(group => group.Key);
        string resultPath = "../../result.txt";
        using (var writer = new StreamWriter(resultPath, false))
        {
            foreach (var extensionGroup in sorted)
            {
                writer.WriteLine(extensionGroup.Key);
                foreach (var fileInfo in extensionGroup)
                {
                    writer.WriteLine("--{0} - {1:F3}kb", fileInfo.Name, fileInfo.Length / 1024.0);
                }
            }
        }
    }
}

//RECURSION
// http://stackoverflow.com/questions/929276/how-to-recursively-list-all-the-files-in-a-directory-in-c
//static void DirSearch(string sDir)
//   {
//       try
//       {
//           foreach (string d in Directory.GetDirectories(sDir))
//           {
//               foreach (string f in Directory.GetFiles(d))
//               {
//                   Console.WriteLine(f);
//               }
//               DirSearch(d);
//           }
//       }
//       catch (System.Exception excpt)
//       {
//           Console.WriteLine(excpt.Message);
//       }
//   }