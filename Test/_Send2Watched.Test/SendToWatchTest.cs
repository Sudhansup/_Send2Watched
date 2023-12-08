using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using _Send2Watched;
using System.Diagnostics;
using System.Reflection;

namespace _Send2Watched.Test
{
    [TestClass]
    public class SendToWatchTest
    {
        [TestMethod]
        public void TestSendToWatched()
        {
            string root_temp_path = Path.GetTempPath();
            Console.WriteLine(root_temp_path);

            var test_folder = AssemblyName.GetAssemblyName(Assembly.GetExecutingAssembly().Location).Name + "_" 
                + Guid.NewGuid().ToString();
            var test_dir_full_path = Path.Combine(root_temp_path, test_folder);
            Directory.CreateDirectory(test_dir_full_path);

            var test_file_name = Guid.NewGuid().ToString() + ".txt";
            var test_file_full_path = Path.Combine(test_dir_full_path, test_file_name);
            var fs = new FileStream(test_file_full_path, FileMode.Create);
            fs.Close();
            File.WriteAllText(test_file_full_path, "Sample test data");

            var res = _Send2Watched.Program.Send_to_watched(new string[] { test_dir_full_path });
            Console.WriteLine(res);
            var _watched_test_dir_full_path = Path.Combine(root_temp_path, _Send2Watched.Program.newDirName);
            Process.Start("explorer.exe", _watched_test_dir_full_path);
            Assert.IsTrue(Directory.Exists(_watched_test_dir_full_path));
        }
    }
}
