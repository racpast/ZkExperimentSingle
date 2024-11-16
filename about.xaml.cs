using System.Windows;

namespace 中考仿真实验重制版4._9
{
    /// <summary>
    /// about.xaml 的交互逻辑
    /// </summary>
    public partial class about : Window
    {
        public about()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            base.Close();
            Application.Current.MainWindow.Show();
        }
    }
}
