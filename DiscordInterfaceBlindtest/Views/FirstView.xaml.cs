using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DiscordInterfaceBlindtest.ViewModels;

namespace DiscordInterfaceBlindtest.Views
{
    /// <summary>
    /// Logique d'interaction pour FirstView.xaml
    /// </summary>
    public partial class FirstView : Page
    {
        public FirstView()
        {
            this.DataContext = new FirstViewModel();
            InitializeComponent();
        }
    }
}
