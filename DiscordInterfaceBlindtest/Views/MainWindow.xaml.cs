using System.Windows;

namespace DiscordInterfaceBlindtest.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.MainFrame.Content = new FirstView();
        }
    }
}
