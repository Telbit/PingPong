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
            MessageBox.Show("BlahaEntertainment Production 2020\n - Bende\n - Dani\n - Tompi");
        }
        
        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}