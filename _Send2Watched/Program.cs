using System.Diagnostics;
using System.IO;
using System.Linq;


namespace _Send2Watched
{
    internal class Program
    {
        internal const string newDirName = "_Watched";

        internal static void Main(string[] args)
        {
            //Debugger.Launch();
            Send_to_watched(args);
        }

        internal static string[] Send_to_watched(string[] args)
        {
            foreach (var inputPath in args)
            {
                if (!string.IsNullOrEmpty(inputPath))
                {
                    DirectoryInfo dfi = new DirectoryInfo(inputPath);
                    var endfileOrDirectoryName = Path.GetFileName(inputPath);
                    var destPath = Path.Combine(dfi.Parent.FullName.ToString(), newDirName, endfileOrDirectoryName);
                    if (!Directory.Exists(destPath)) { Directory.CreateDirectory(Path.GetDirectoryName(destPath)); }
                    dfi.MoveTo(destPath);
                }
            }
            return args;
        }

        internal void Eliminate_dupe_dirname(string destPath, string dirname_tocheck)
        {
            foreach (var item in new DirectoryInfo(destPath).GetFiles("*", SearchOption.TopDirectoryOnly))
            {
                if(item.Name  ==  item.DirectoryName && item.Name == dirname_tocheck)
                {
                    //TODO:

                }
            }
        }
    }
}
