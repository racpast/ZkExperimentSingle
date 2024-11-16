using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace 中考仿真实验重制版4._9
{
    public class PublicContent
    {
        public static void OpenProcess(string path, string para = "", bool shellExecute = true, bool showWin = true)
        {
            if (File.Exists(path))
            {
                new Process
                {
                    StartInfo = new ProcessStartInfo(path, para)
                    {
                        UseShellExecute = shellExecute,
                        CreateNoWindow = !showWin,
                        Verb = "runas"
                    }
                }.Start();
                return;
            }
            HandyControl.Controls.MessageBox.Show("实验程序不完整！请重新下载。", "错误", MessageBoxButton.OK, MessageBoxImage.Hand, MessageBoxResult.None);
            Application.Current.Shutdown();
        }
        public static int clicktimes = 0;
        public static Dictionary<int, string> BackgroundToKey = new Dictionary<int, string>();

    }
}
