using System.Windows;

namespace 中考仿真实验重制版4._9
{
    /// <summary>
    /// Whats.xaml 的交互逻辑
    /// </summary>
    public partial class Whats : Window
    {
        public Whats()
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
