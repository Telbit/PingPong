using System;
using System.Windows;
using System.Windows.Input;

namespace BlahaPong.View
{
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void OnePlayer(object sender, RoutedEventArgs e)
        {
            
            MainWindow win = new MainWindow();
            this.Close();
            win.Show();

        }
        
        private void TwoPlayer(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("2P");
        }
        
        private void Credits(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("CRED");
        }
        
        private void Exit(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("EX");
        }
    }
}