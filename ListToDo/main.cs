using System.IO;
using System;

namespace ToDo
{
    class App
    {
        static void Main()
        {
            var exeutingFolder = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            Console.WriteLine(exeutingFolder);
            Console.ReadLine();
            FileInfo fil = new FileInfo(exeutingFolder + "");
            if (fil.Exists)
            {

            }
        }
    }
}